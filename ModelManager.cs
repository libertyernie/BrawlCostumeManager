using System;
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

namespace BrawlCharacterManager {
	public partial class ModelManager : UserControl {
		/// <summary>
		/// The string between "Fit" and the number.
		/// </summary>
		private string _charString;

		private string _delayedPath;

		public ModelManager() {
			InitializeComponent();
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

		private void button1_Click(object sender, EventArgs e) {
			LoadFile("C:\\Users\\Isaac\\Desktop\\BrawlHacks\\Textures\\RecolorProject\\ToonLink\\Brown\\FitToonLink06.pac");
		}

		public void LoadFile(string path) {
			_charString = getCharString(path);

			comboBox1.Items.Clear();
			modelPanel1.ClearAll();
			modelPanel1.Invalidate();
			this.Text = new FileInfo(path).Name;

			ResourceNode root = NodeFactory.FromFile(null, path);
			List<MDL0Node> models = findAllMDL0s(root);
			if (models.Count > 0) {
				comboBox1.Items.AddRange(models.ToArray());
				comboBox1.SelectedIndex = 0;
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
			model._renderBones = false;
			model._renderPolygons = CheckState.Checked;
			model._renderVertices = false;
			model._renderBox = false;

			foreach (string texname in Constants.TexturesToDisable) {
				MDL0TextureNode tex = model.TextureGroup.FindChild(texname, false) as MDL0TextureNode;
				if (tex != null) {
					tex.Enabled = false;
				}
			}

			modelPanel1.ClearAll();
			modelPanel1.AddTarget((IRenderedObject)model);

			if (Constants.PolygonsToDisable.ContainsKey(_charString)) {
				foreach (int polygonNum in Constants.PolygonsToDisable[_charString]) {
					MDL0ObjectNode poly = model.PolygonGroup.FindChild("polygon" + polygonNum, false) as MDL0ObjectNode;
					poly._render = false;
				}
			}

			Vector3 min, max;
			((IRenderedObject)model).GetBox(out min, out max);
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
	}
}
