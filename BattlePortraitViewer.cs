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
		public override ResourceNode PortraitRootFor(int charNum, int costumeNum) {
			string tex_number = (charNum * 10 + costumeNum + 1).ToString("D3");
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
			return bres;
		}
		public override ResourceNode TEX0For(ResourceNode node, int charNum, int costumeNum) {
			return node.FindChild("Textures(NW4R)", false).Children[0];
		}

		private ResourceNode[] bres_cache;

		public BattlePortraitViewer() : base() {
			UpdateDirectory();
		}

		public override void UpdateDirectory() {
			if (bres_cache != null) {
				foreach (ResourceNode node in bres_cache) {
					if (node != null) node.Dispose();
				}
			}
			bres_cache = new ResourceNode[471];
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
