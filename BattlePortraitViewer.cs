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

		private ResourceNode[] battle_bres_array;

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

			ResourceNode bres = battle_bres_array[charNum * 10 + costumeNum + 1];
			if (bres == null) {
				label1.Text = "InfFace" + tex_number + ".brres: not found";
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
			battle_bres_array = new ResourceNode[470];
			for (int i = 0; i < 470; i++) {
				try {
					// could be cleaned up to skip certain unused numbers
					battle_bres_array[i] = (BRESNode)NodeFactory.FromFile(null, "info/portrite/InfFace" + i.ToString("D3") + ".brres");
				} catch (IOException) {
					battle_bres_array[i] = null;
				}
			}
		}

		protected override void saveButton_Click(object sender, EventArgs e) {
			for (int i = 0; i < battle_bres_array.Length; i++) {
				if (battle_bres_array[i] != null && battle_bres_array[i].IsDirty) {
					battle_bres_array[i].Rebuild();
					battle_bres_array[i].Export("info/portrite/InfFace" + i.ToString("D3") + ".brres");
				}
			}
		}
	}
}
