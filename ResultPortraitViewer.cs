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
	public partial class ResultPortraitViewer : UserControl {
		private ResourceNode[] bres_array;
		private TEX0Node tex0;

		public ResultPortraitViewer() {
			InitializeComponent();

			panel1.DragEnter += panel1_DragEnter;
			panel1.DragDrop += panel1_DragDrop;

			bres_array = new ResourceNode[47];
			for (int i = 0; i < 47; i++) {
				try {
					bres_array[i] = (BRESNode)NodeFactory.FromFile(null, "menu/common/char_bust_tex/MenSelchrFaceB" + i.ToString("D2") + "0.brres");
				} catch (IOException) {
					bres_array[i] = null;
				}
			}
		}

		public void UpdateImage(int charNum, int costumeNum) {
			string tex_number = (charNum*10 + costumeNum + 1).ToString("D3");

			tex0 = null;
			panel1.BackgroundImage = null;

			ResourceNode bres = bres_array[charNum];
			if (bres == null) {
				return;
			}

			string str = "Textures(NW4R)/MenSelchrFaceB." + tex_number;
			label1.Text = bres.ToString() + "/" + str;
			ResourceNode get_node = bres.FindChild(str, false);
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
			for (int i = 0; i < bres_array.Length; i++) {
				if (bres_array[i] != null && bres_array[i].IsDirty) {
					bres_array[i].Rebuild();
					bres_array[i].Export("menu/common/char_bust_tex/out_MenSelchrFaceB" + i.ToString("D2") + "0.brres");
				}
			}
		}
	}
}
