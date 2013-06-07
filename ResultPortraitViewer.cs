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
	public class ResultPortraitViewer : PortraitViewer {
		public override int PortraitWidth {
			get { return 128; }
		}
		public override int PortraitHeight {
			get { return 160; }
		}

		private ResourceNode[] bres_cache;

		public ResultPortraitViewer() : base() {
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

			ResourceNode bres = bres_cache[charNum];
			if (bres == null) {
				string f = "menu/common/char_bust_tex/MenSelchrFaceB" + charNum.ToString("D2") + "0.brres";
				if (new FileInfo(f).Exists) {
					bres_cache[charNum] = bres = (BRESNode)NodeFactory.FromFile(null, f);
				}

				if (bres == null) {
					label1.Text = "MenSelchrFaceB" + charNum.ToString("D2") + "0: not found";
					return null;
				}
			}

			string str = "Textures(NW4R)/MenSelchrFaceB." + tex_number;
			label1.Text = bres.ToString().Replace(".brres", "") + ": " + str;
			ResourceNode get_node = bres.FindChild(str, false);
			if (get_node is TEX0Node) {
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
			bres_cache = new ResourceNode[47];
		}

		protected override void saveButton_Click(object sender, EventArgs e) {
			for (int i = 0; i < bres_cache.Length; i++) {
				if (bres_cache[i] != null && bres_cache[i].IsDirty) {
					bres_cache[i].Merge();
					bres_cache[i].Export("menu/common/char_bust_tex/MenSelchrFaceB" + i.ToString("D2") + "0.brres");
				}
			}
		}
	}
}
