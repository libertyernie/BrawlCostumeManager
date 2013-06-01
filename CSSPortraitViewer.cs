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

namespace BrawlCharacterManager {
	public partial class CSSPortraitViewer : UserControl {
		private ResourceNode common5;

		public CSSPortraitViewer() {
			InitializeComponent();
			try {
				common5 = NodeFactory.FromFile(null, "system/common5_en.pac");
				sUpdateImage(1, 0);
			} catch (DirectoryNotFoundException) {

			}
		}

		public void sUpdateImage(int charNum, int costumeNum) {
			string str = "sc_selcharacter_en/char_bust_tex_lz77/MiscData["
			+ charNum
			+ "]/Textures(NW4R)/MenSelchrFaceB."
			+ (charNum*10 + costumeNum + 1).ToString("D3");
			ResourceNode MenSelchrFaceB_001 = common5.FindChild(str, true);
			if (MenSelchrFaceB_001 is TEX0Node) {
				TEX0Node tex0 = (TEX0Node)MenSelchrFaceB_001;
				Bitmap bitmap = tex0.GetImage(0);
				BackgroundImage = bitmap;
			}
//			Invalidate();
		}
	}
}
