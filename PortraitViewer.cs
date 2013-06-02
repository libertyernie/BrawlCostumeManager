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
	public abstract partial class PortraitViewer : UserControl {
		protected TEX0Node tex0;

		public PortraitViewer() {
			InitializeComponent();

			panel1.DragEnter += panel1_DragEnter;
			panel1.DragDrop += panel1_DragDrop;
		}

		public abstract void UpdateImage(int charNum, int costumeNum);

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

		protected abstract void saveButton_Click(object sender, EventArgs e);
	}
}
