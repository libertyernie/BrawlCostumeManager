﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.OpenGL;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlCostumeManager {
	public partial class ModelManager : UserControl {
		public const string LOCAL_BRAWL_ROOT = @"C:\Brawl";

		/// <summary>
		/// The string between "Fit" and the number.
		/// </summary>
		private string _charString;
		/// <summary>
		/// In case the file needs to be reloaded.
		/// </summary>
		private string _path;

	    /// <summary>
	    /// Should be disposed when you switch to a new file.
	    /// </summary>
		ResourceNode _root;

		public ResourceNode WorkingRoot {
			get {
				return _root;
			}
		}

		public Size? ModelPreviewSize {
			get {
				return Dock == DockStyle.Fill ? (Size?)null : modelPanel1.Size;
			}
			set {
				if (value == null) {
					modelPanel1.Dock = DockStyle.Fill;
				} else {
					modelPanel1.Dock = DockStyle.None;
					modelPanel1.Size = value.Value;
				}
			}
		}

		public bool ZoomOut;
		public bool UseExceptions;

		private string _delayedPath;

		public ModelManager() {
			InitializeComponent();
			UseExceptions = true;

			modelPanel1.DragEnter += modelPanel1_DragEnter;
			modelPanel1.DragDrop += modelPanel1_DragDrop;
		}

		void modelPanel1_DragEnter(object sender, DragEventArgs e) {
			if (_path != null && e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (s.Length == 1) { // Can only drag and drop one file
					string filename = s[0].ToLower();
					if (filename.EndsWith(".pac") || filename.EndsWith(".pcs")) {
						e.Effect = DragDropEffects.Copy;
					}
				}
			}
		}

		void modelPanel1_DragDrop(object sender, DragEventArgs e) {
			if (e.Effect == DragDropEffects.Copy) {
				string newpath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
				using (ResourceNode newroot = NodeFactory.FromFile(null, newpath)) {
					if (newroot is ARCNode) {
						string basePath = _path;
						if (Path.HasExtension(basePath)) {
							basePath = basePath.Substring(0, basePath.LastIndexOf('.'));
						}
						FileInfo pac = new FileInfo(basePath + ".pac");
						FileInfo pcs = new FileInfo(basePath + ".pcs");

						bool cont = true;
						if (pac.Exists || pcs.Exists) {
							cont = (DialogResult.OK == MessageBox.Show(
								"Replace " + pac.Name + "/" + pcs.Name + "?",
								"Overwrite?",
								MessageBoxButtons.OKCancel));
						}
						if (!cont) return;

						if (_root != null) {
							_root.Dispose();
							_root = null;
						}
						pac.Directory.Create();
						(newroot as ARCNode).ExportPAC(pac.FullName);
						(newroot as ARCNode).ExportPCS(pcs.FullName);

						if (ParentForm is CostumeManager) {
							(ParentForm as CostumeManager).updateCostumeSelectionPane();
						}

						LoadFile(_path);
					} else {
						MessageBox.Show("Invalid format: root node is not an ARC archive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		public void LoadFileDelayed(string delayedPath) {
			this._delayedPath = delayedPath;
			if (!String.IsNullOrWhiteSpace(_delayedPath)) {
				var tmp_timer = new System.Timers.Timer(1000);
				tmp_timer.AutoReset = false;
				tmp_timer.Elapsed += new System.Timers.ElapsedEventHandler(initializeModelPanel);
				tmp_timer.Enabled = true;
			}
		}

		private void initializeModelPanel(object o, System.Timers.ElapsedEventArgs target) {
			LoadFile(_delayedPath);
		}

		public void RefreshModel() {
			LoadFile(_path);
		}

		public void LoadFile(string path) {
			if (_root != null) {
				_root.Dispose();
				_root = null;
			}
			if (path == null) {
				return;
			}

			_path = path;
			_charString = getCharString(path);

			comboBox1.Items.Clear();
			modelPanel1.ClearAll();
			modelPanel1.Invalidate();
			this.Text = new FileInfo(path).Name;

			try {
				if (!File.Exists(path)) path = LOCAL_BRAWL_ROOT + '\\' + path.Substring(path.IndexOf("fighter"));
				_root = NodeFactory.FromFile(null, path);
				List<MDL0Node> models = findAllMDL0s(_root);
				if (models.Count > 0) {
					comboBox1.Items.AddRange(models.ToArray());
					comboBox1.SelectedIndex = 0;
				}
			} catch (IOException) {
				
			}
		}

		private static string getCharString(string path) {
			string working = path.ToLower();
			working = working.Substring(working.LastIndexOf("fit")+3);
			int length = 0;
			foreach (char c in working) {
				if (c >= '0' && c <= '9') {
					break;
				} else {
					length++;
				}
			}
			working = working.Substring(0, length);
			return working;
		}

		public void LoadModel(MDL0Node model) {
			model.Populate();
			model._renderBones = false;
			model._renderPolygons = true;
			model._renderWireframe = false;
			model._renderVertices = false;
			model._renderBox = false;
			model.ApplyCHR(null, 0);
			model.ApplySRT(null, 0);

			if (UseExceptions) foreach (string texname in TexturesToDisable) {
				MDL0TextureNode tex = model.TextureGroup.FindChild(texname, false) as MDL0TextureNode;
				if (tex != null) {
					tex.Enabled = false;
				}
			}

			modelPanel1.ClearAll();
			modelPanel1.AddTarget((IRenderedObject)model);

			if (UseExceptions && PolygonsToDisable.ContainsKey(_charString)) {
				foreach (int polygonNum in PolygonsToDisable[_charString]) {
					MDL0ObjectNode poly = model.PolygonGroup.FindChild("polygon" + polygonNum, false) as MDL0ObjectNode;
					if (poly != null) poly._render = false;
				}
			}

			Vector3 min, max;
			((IRenderedObject)model).GetBox(out min, out max);
			if (ZoomOut) {
				min._x += 20;
				max._x -= 20;
			}
			modelPanel1.SetCamWithBox(min, max);
		}

		private List<MDL0Node> findAllMDL0s(ResourceNode root) {
			List<MDL0Node> list = new List<MDL0Node>();
			if (root is MDL0Node) {
				list.Add((MDL0Node)root);
			} else {
				foreach (ResourceNode node in root.Children) {
					list.AddRange(findAllMDL0s(node));
				}
			}
			return list;
		}

		private MDL0Node findFirstMDL0(ResourceNode root) {
			if (root is MDL0Node) {
				return (MDL0Node)root;
			}
			foreach (ResourceNode node in root.Children) {
				MDL0Node result = findFirstMDL0(node);
				if (result != null) {
					return result;
				}
			}
			return null;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			object item = comboBox1.SelectedItem;
			if (item is MDL0Node) {
				LoadModel(item as MDL0Node);
			}
		}



		public static string[] TexturesToDisable = {
			"SamusTexASpc", "SamusTexBSpc", "SamusRef", "SamusTexC", "SamusTexD", "SamusTexDSpc", "Spe", // remove sphere
			"Yoshi_Egg", // remove egg
			"PlyKirby5KEyeYellow.1", // remove Final Smash eyes
			"Pikachu_eyesYellow.00", // remove Final Smash eyes
			"PeachTexEyeHigh", "PeachTexEyeWhite", "PeachTexEyeYellow", // remove black eyes
			"ZeldaEyeHigh", // remove black eyes
			"IceclimberTexCYellow.00", // remove Final Smash eyes
			"FitPikminRef", "FitPikminRef05", // remove helmet
			"FitLucas_EyeYellow.00",
			"FitPurin00EyeYellow.00",
//			"FitToonLink_EyeWhite.0", "FitToonLink_EyeYellow", // remove FS eyes (and eye whites, so you can see the pupils)
			"FitSonicBodyMask", "FitSonicHeadMask", "FitSonicEyeHighlight", // remove gray Sonic
//			"FitSonicEnv01", "FitSonicEnv04", "FitSonicSphere", // remove sphere
		};

		public static Dictionary<string, int[]> PolygonsToDisable = new Dictionary<string, int[]> {
			{"mario", new int[] {4,5,6,7,12,13}}, // open eyelids
			{"luigi", new int[] {5,8,9,10,11,12,17}}, // open eyelids
			{"ness", new int[] {1,2,5,6}}, // remove wild "intro" hair and FS eyes
			{"zelda", new int[] {19,21,25}}, // open eyelids
			{"olimar", new int[] {5}}, // "close" eyelids (normal facial expression for Olimar)
			{"sonic", new int[] {10,11,14,15,16,18,20,21,22,24,26,27,28,29,30}}, // open eyelids, remove sphere, etc.
			{"dedede", new int[] {19}}, // remove inflated Dedede
		};

		public Bitmap GrabScreenshot(bool withTransparency) {
			return modelPanel1.GrabScreenshot(withTransparency);
		}
	}
}
