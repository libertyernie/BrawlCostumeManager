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
		/*private ResourceNode[] char_bust_tex_nodes;*/
		private BRESNode from_common5_brres;
		private TEX0Node from_common5_tex0;
		/*private TEX0Node from_char_bust_tex;*/

		public CSSPortraitViewer() {
			InitializeComponent();
			/*char_bust_tex_nodes = new ResourceNode[47];
			for (int i = 0; i < 47; i++) {
				if (Constants.CharactersByCSSOrder[i] != null) {
					char_bust_tex_nodes[i] = NodeFactory.FromFile(null,
						"menu/common/char_bust_tex/MenSelchrFaceB"
						+ (i * 10).ToString("D3") + ".brres");
				}
			}*/
			try {
				common5 = NodeFactory.FromFile(null, "system/common5_en.pac");
				UpdateImage(1, 0);
			} catch (DirectoryNotFoundException) {

			}
		}

		public void UpdateImage(int charNum, int costumeNum) {
			string tex_number = (charNum*10 + costumeNum + 1).ToString("D3");

			from_common5_tex0 = null;
			from_common5_brres = null;
			panel1.BackgroundImage = null;
			string str1 = "sc_selcharacter_en/char_bust_tex_lz77/MiscData[" + charNum + "]";
			string str2 = "Textures(NW4R)/MenSelchrFaceB." + tex_number;
			label1.Text = str1 + "//" + str2;
			ResourceNode from_common5_brres_node = common5.FindChild(str1, false);
			if (from_common5_brres_node is BRESNode) {
				from_common5_brres = (BRESNode)from_common5_brres_node;
				ResourceNode from_common5_node = from_common5_brres.FindChild(str2, false);
				if (from_common5_node is TEX0Node) {
					from_common5_tex0 = (TEX0Node)from_common5_node;
					Bitmap bitmap = from_common5_tex0.GetImage(0);
					panel1.BackgroundImage = bitmap;
				}
			}

/*			from_char_bust_tex = null;
			ResourceNode from_char_bust_tex_node =
				char_bust_tex_nodes[charNum].FindChild("Textures(NW4R)/MenSelchrFaceB." + tex_number, false);
			label1.Text = char_bust_tex_nodes[charNum] + "/Textures(NW4R)/MenSelchrFaceB." + tex_number;
			if (from_char_bust_tex_node is TEX0Node) {
				from_char_bust_tex = (TEX0Node)from_char_bust_tex_node;
				Bitmap bitmap = from_char_bust_tex.GetImage(0);
				panel1.BackgroundImage = bitmap;
			}*/

//			Invalidate();
		}
	}
}
