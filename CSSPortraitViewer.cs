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
		private TEX0Node tex0;

		public CSSPortraitViewer() {
			InitializeComponent();

			panel1.DragEnter += panel1_DragEnter;
			panel1.DragDrop += panel1_DragDrop;

			try {
				common5 = null;
				sc_selcharacter = NodeFactory.FromFile(null, "menu2/sc_selcharacter.pac");
			} catch (IOException) {
				try {
					common5 = NodeFactory.FromFile(null, "system/common5.pac");
					sc_selcharacter = common5.FindChild("sc_selcharacter_en", false);
				} catch (IOException) {
					label1.Text = "Could not load sc_selcharacter or common5.";
				}
			}

/*			bres_array = new BRESNode[47];
			if (sc_selcharacter != null) {
				for (int i = 0; i < 47; i++) {
					bres_array[i] = (BRESNode)sc_selcharacter.FindChild("char_bust_tex_lz77/MiscData[" + i + "]", false);
				}
			}*/
		}

		public void UpdateImage(int charNum, int costumeNum) {
			string tex_number = (charNum*10 + costumeNum + 1).ToString("D3");

			tex0 = null;
			panel1.BackgroundImage = null;

			if (common5 != null) {
				label1.Text = "common5.pac/sc_selcharacter_en/";
			} else if (sc_selcharacter != null) {
				label1.Text = "sc_selcharacter.pac/";
			} else {
				return;
			}

			string str1 = "char_bust_tex_lz77/MiscData[" + charNum + "]";
			string str2 = "Textures(NW4R)/MenSelchrFaceB." + tex_number;
			label1.Text += str1 + "/" + str2;
			ResourceNode get_node = sc_selcharacter.FindChild(str1 + "/" + str2, false);
			if (get_node is TEX0Node) {
				tex0 = (TEX0Node)get_node;
				Bitmap bitmap = tex0.GetImage(0);
				panel1.BackgroundImage = bitmap;
			} else {
				label1.Text += " (tex0 not found)";
			}

		}

		void panel1_DragEnter(object sender, DragEventArgs e) {
			if (tex0 != null && e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (s.Length == 1) { // Can only drag and drop one file
					string filename = s[0].ToLower();
					if (filename.EndsWith(".png") || filename.EndsWith(".gif")
						|| filename.EndsWith(".tif") || filename.EndsWith(".tiff")) {
						e.Effect = DragDropEffects.Copy;
					}
				}
			}
		}

		void panel1_DragDrop(object sender, DragEventArgs e) {
			if (e.Effect == DragDropEffects.Copy) {
				Bitmap bitmap = new Bitmap((e.Data.GetData(DataFormats.FileDrop) as string[])[0]);
				if (bitmap.Height == 160 && bitmap.Width == 128) {
					tex0.Replace(bitmap);
					panel1.BackgroundImage = tex0.GetImage(0);
				} else {
					MessageBox.Show("Character portraits must be 128x160.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void saveButton_Click(object sender, EventArgs e) {
			if (sc_selcharacter == null) {
				return;
			}

			/* Trying to make brres files like this leads to crashing :(
			for (int i = 0; i < bres_array.Length; i++) {
				if (bres_array[i] != null && bres_array[i].IsDirty) {
					bres_array[i].Rebuild();
					bres_array[i].Export("menu/common/char_bust_tex/out_MenSelchrFaceB" + i.ToString("D2") + "0.brres");
				}
			}*/
			if (common5 != null) {
				common5.Merge();
				common5.Export("system/common5.pac");
			} else {
				sc_selcharacter.Merge();
				sc_selcharacter.Export("menu2/sc_selcharacter_out.pac");
			}
		}
	}
}
