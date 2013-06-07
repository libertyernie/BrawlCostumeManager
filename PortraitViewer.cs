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
	public abstract partial class PortraitViewer : UserControl {
		public abstract int PortraitWidth {
			get;
		}
		public abstract int PortraitHeight {
			get;
		}

		protected TEX0Node tex0;

		// In case the image needs to be reloaded after replacing the texture
		protected int _charNum, _costumeNum;

		public PortraitViewer() {
			InitializeComponent();
			panel1.Size = new System.Drawing.Size(PortraitWidth, PortraitHeight);

			_charNum = -1;
			_costumeNum = -1;

			panel1.DragEnter += panel1_DragEnter;
			panel1.DragDrop += panel1_DragDrop;
		}

		public void UpdateImage(int charNum, int costumeNum) {
			panel1.BackgroundImage = null;
			_charNum = -1;
			_costumeNum = -1;

			tex0 = (TEX0Node)get_node(charNum, costumeNum);
			if (tex0 != null) {
				Bitmap bitmap = tex0.GetImage(0);
				panel1.BackgroundImage = bitmap;

				_charNum = charNum;
				_costumeNum = costumeNum;
			}
		}

		protected abstract TEX0Node get_node(int charNum, int costumeNum);

		public abstract void UpdateDirectory();

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
				using (TextureConverterDialog dlg = new TextureConverterDialog()) {
					dlg.ImageSource = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
					if (dlg.ShowDialog(null, tex0) == DialogResult.OK) {
						UpdateImage(_charNum, _costumeNum);
					}
				}
			}
		}

		protected abstract void saveButton_Click(object sender, EventArgs e);
	}
}
