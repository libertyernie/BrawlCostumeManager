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
		public override ResourceNode PortraitRootFor(int charNum, int costumeNum) {
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
			return bres;
		}
		public override ResourceNode TEX0For(ResourceNode brres, int charNum, int costumeNum) {
			string path = "Textures(NW4R)/MenSelchrFaceB." + (charNum * 10 + costumeNum + 1).ToString("D3");
			return brres.FindChild(path, false);
		}

		private ResourceNode[] bres_cache;

		public ResultPortraitViewer() : base() {
			UpdateDirectory();
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
