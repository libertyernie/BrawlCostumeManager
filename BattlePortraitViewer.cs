using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;

namespace BrawlCostumeManager {
	public class BattlePortraitViewer : PortraitViewer {
		public override int PortraitWidth {
			get { return 48; }
		}
		public override int PortraitHeight {
			get { return 56; }
		}

		private ResourceNode[] bres_cache;

		public BattlePortraitViewer() : base() {
			UpdateDirectory();
		}

		protected override TEX0Node get_node(int charNum, int costumeNum) {
			string tex_number = (charNum*10 + costumeNum + 1).ToString("D3");

			tex0 = null;
			panel1.BackgroundImage = null;

			if (costumeNum < 0) {
				label1.Text = "No portrait mapping";
				return null;
			}

			int index = charNum * 10 + costumeNum + 1;
			ResourceNode bres = bres_cache[index];
			if (bres == null) {
				string f = "info/portrite/InfFace" + tex_number + ".brres";
				if (new FileInfo(f).Exists) {
					bres_cache[index] = bres = (BRESNode)NodeFactory.FromFile(null, f);
				}

				if (bres == null) {
					label1.Text = "InfFace" + tex_number + ".brres: not found";
					return null;
				}
			}

			ResourceNode get_node = bres.FindChild("Textures(NW4R)", false).Children[0];
			if (get_node is TEX0Node) {
				label1.Text = "InfFace" + tex_number + ".brres";
				return tex0 = (TEX0Node)get_node;
			} else {
				label1.Text += " (tex0 not found)";
				return null;
			}
		}

		public override void UpdateDirectory() {
			if (bres_cache != null) {
				foreach (ResourceNode node in bres_cache) {
					if (node != null) node.Dispose();
				}
			}
			bres_cache = new ResourceNode[470];
		}

		protected override void saveButton_Click(object sender, EventArgs e) {
			for (int i = 0; i < bres_cache.Length; i++) {
				if (bres_cache[i] != null && bres_cache[i].IsDirty) {
					bres_cache[i].Merge();
					bres_cache[i].Export("info/portrite/InfFace" + i.ToString("D3") + ".brres");
				}
			}
		}
	}
}
