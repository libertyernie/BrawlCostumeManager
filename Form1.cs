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
	public partial class Form1 : Form {
		private string _initialPath;

		public Form1(string initialPath) {
			this._initialPath = initialPath;
			if (!String.IsNullOrWhiteSpace(initialPath)) {
				InitializeComponent();
				var tmp_timer = new System.Timers.Timer(1000);
				tmp_timer.AutoReset = false;
				tmp_timer.Elapsed += new System.Timers.ElapsedEventHandler(initializeModelPanel);
				tmp_timer.Enabled = true;
			}
		}

		private void initializeModelPanel(object o, System.Timers.ElapsedEventArgs target) {
			LoadFile(_initialPath);
		}

		private void button1_Click(object sender, EventArgs e) {
			LoadFile("C:\\Users\\Isaac\\Desktop\\BrawlHacks\\Textures\\RecolorProject\\ToonLink\\Brown\\FitToonLink06.pac");
		}

		public void LoadFile(string path) {
			ResourceNode root = NodeFactory.FromFile(null, path);
			ResourceNode modelnode = findFirstMDL0(root);
			if (modelnode is MDL0Node) {
				this.Text = new FileInfo(path).Name;
				MDL0Node model = (MDL0Node)modelnode;

				model._renderBones = false;
				model._renderPolygons = CheckState.Checked;
				model._renderVertices = false;
				model._renderBox = false;

				modelPanel1.ClearAll();
				modelPanel1.AddTarget((IRenderedObject)model);

				Vector3 min, max;
				((IRenderedObject)model).GetBox(out min, out max);
				modelPanel1.SetCamWithBox(min, max);
			}
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
	}
}
