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
		private TEX0Node tex0;

		public CSSPortraitViewer() {
			InitializeComponent();
			try {
				common5 = NodeFactory.FromFile(null, "system/common5_en.pac");
				UpdateImage(1, 0);
			} catch (DirectoryNotFoundException) {

			}
		}

		public void UpdateImage(int charNum, int costumeNum) {
			tex0 = null;
			panel1.BackgroundImage = null;
			string str = "sc_selcharacter_en/char_bust_tex_lz77/MiscData["
			+ charNum
			+ "]/Textures(NW4R)/MenSelchrFaceB."
			+ (charNum*10 + costumeNum + 1).ToString("D3");
			label1.Text = str;
			ResourceNode MenSelchrFaceB_001 = common5.FindChild(str, true);
			if (MenSelchrFaceB_001 is TEX0Node) {
				tex0 = (TEX0Node)MenSelchrFaceB_001;
				Bitmap bitmap = tex0.GetImage(0);
				panel1.BackgroundImage = bitmap;
			}
//			Invalidate();
		}
	}
}
