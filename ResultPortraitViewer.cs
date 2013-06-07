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

		private ResourceNode[] bres_array;

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

			ResourceNode bres = bres_array[charNum];
			if (bres == null) {
				label1.Text = "MenSelchrFaceB" + charNum.ToString("D2") + "0.brres: not found";
				return null;
			}

			string str = "Textures(NW4R)/MenSelchrFaceB." + tex_number;
			label1.Text = bres.ToString() + ": " + str;
			ResourceNode get_node = bres.FindChild(str, false);
			if (get_node is TEX0Node) {
				return tex0 = (TEX0Node)get_node;
			} else {
				label1.Text += " (tex0 not found)";
				return null;
			}
		}

		public override void UpdateDirectory() {
			bres_array = new ResourceNode[47];
			using (ProgressWindow progress = new ProgressWindow(this, "Loading result portraits", System.Environment.CurrentDirectory, false)) {
				progress.Begin(0, 47, 0);
				for (int i = 0; i < 47; i++) {
					progress.Update(i);
					string f = "menu/common/char_bust_tex/MenSelchrFaceB" + i.ToString("D2") + "0.brres";
					if (new FileInfo(f).Exists) {
						bres_array[i] = (BRESNode)NodeFactory.FromFile(null, f);
					}
				}
			}
		}

		protected override void saveButton_Click(object sender, EventArgs e) {
			for (int i = 0; i < bres_array.Length; i++) {
				if (bres_array[i] != null && bres_array[i].IsDirty) {
					bres_array[i].Merge();
					bres_array[i].Export("menu/common/char_bust_tex/MenSelchrFaceB" + i.ToString("D2") + "0.brres");
				}
			}
		}
	}
}
