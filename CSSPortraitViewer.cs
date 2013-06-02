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
		/// <summary>
		/// The common5 currently being used. If using sc_selcharacter.pac instead, this will be null.
		/// </summary>
		private ResourceNode common5;
		/// <summary>
		/// Either the sc_selcharacter_en archive within common5.pac or the sc_selcharacter.pac file.
		/// </summary>
		private ResourceNode sc_selcharacter;
		private BRESNode brres;
		private TEX0Node tex0;

		public CSSPortraitViewer() {
			InitializeComponent();
			try {
				common5 = null;
				sc_selcharacter = NodeFactory.FromFile(null, "menu2/sc_selcharacter.pac");
				UpdateImage(1, 0);
			} catch (IOException) {
				try {
					common5 = NodeFactory.FromFile(null, "system/common5_en.pac");
					sc_selcharacter = common5.FindChild("sc_selcharacter_en", false);
					UpdateImage(1, 0);
				} catch (IOException) {
					label1.Text = "Could not load sc_selcharacter or common5.";
				}
			}
			
		}

		public void UpdateImage(int charNum, int costumeNum) {
			string tex_number = (charNum*10 + costumeNum + 1).ToString("D3");

			tex0 = null;
			brres = null;
			panel1.BackgroundImage = null;

			if (common5 != null) {
				label1.Text = "common5.pac/sc_selcharacter_en/";
			} else if (sc_selcharacter != null) {
				label1.Text = "sc_selcharacter.pac/";
			}

			string str1 = "char_bust_tex_lz77/MiscData[" + charNum + "]";
			string str2 = "Textures(NW4R)/MenSelchrFaceB." + tex_number;
			label1.Text += str1 + "/" + str2;
			ResourceNode from_common5_brres_node = sc_selcharacter.FindChild(str1, false);
			if (from_common5_brres_node is BRESNode) {
				brres = (BRESNode)from_common5_brres_node;
				ResourceNode from_common5_node = brres.FindChild(str2, false);
				if (from_common5_node is TEX0Node) {
					tex0 = (TEX0Node)from_common5_node;
					Bitmap bitmap = tex0.GetImage(0);
					panel1.BackgroundImage = bitmap;
				} else {
					label1.Text += " (tex0 not found)";
				}
			}

		}
	}
}
