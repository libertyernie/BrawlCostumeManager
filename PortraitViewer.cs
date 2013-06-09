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
using BrawlLib;

namespace BrawlCostumeManager {
	public abstract partial class PortraitViewer : UserControl {

		private static OpenFileDialog _openDlg;
		private static SaveFileDialog _saveDlg;
		static PortraitViewer() {
			_openDlg = new OpenFileDialog();
			_saveDlg = new SaveFileDialog();
		}

		/// <summary>
		/// Method lifted directly from BrawlBox.
		/// </summary>
		public static string ApplyExtension(string path, string filter, int filterIndex) {
			int tmp;
			if ((Path.HasExtension(path)) && (!int.TryParse(Path.GetExtension(path), out tmp)))
				return path;

			int index = filter.IndexOfOccurance('|', filterIndex * 2);
			if (index == -1)
				return path;

			index = filter.IndexOf('.', index);
			int len = Math.Max(filter.Length, filter.IndexOfAny(new char[] { ';', '|' })) - index;

			string ext = filter.Substring(index, len);

			if (ext.IndexOf('*') >= 0)
				return path;

			return path + ext;
		}

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
						|| filename.EndsWith(".tex0") || filename.EndsWith(".brres")) {
						e.Effect = DragDropEffects.Copy;
					}
				}
			}
		}

		void panel1_DragDrop(object sender, DragEventArgs e) {
			if (e.Effect == DragDropEffects.Copy) {
				Replace((e.Data.GetData(DataFormats.FileDrop) as string[])[0]);
			}
		}

		public void Replace(string filename) {
			var ig = StringComparison.CurrentCultureIgnoreCase;
			if (filename.EndsWith(".tex0", ig) || filename.EndsWith(".brres", ig)) {
				using (ResourceNode node = NodeFactory.FromFile(null, filename)) {
					TEX0Node tex0;
					if (node is TEX0Node) {
						tex0 = (TEX0Node)node;
					} else {
						tex0 = (TEX0Node)node.FindChild("Textures(NW4R)", false).Children[0];
					}
					string tempFile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
					tex0.Export(tempFile);
					Replace(tempFile); // call self with new file
					File.Delete(tempFile);
				}
			} else {
				using (TextureConverterDialog dlg = new TextureConverterDialog()) {
					dlg.ImageSource = filename;
					if (dlg.ShowDialog(null, tex0) == DialogResult.OK) {
						UpdateImage(_charNum, _costumeNum);
					}
				}
			}
		}

		protected abstract void saveButton_Click(object sender, EventArgs e);

		private void replaceToolStripMenuItem_Click(object sender, EventArgs e) {
			_openDlg.Filter = ExportFilters.TEX0;
			if (_openDlg.ShowDialog() == DialogResult.OK) {
				string fileName = _openDlg.FileName;
				Replace(fileName);
			}
		}

		/// <summary>
		/// From BrawlBox (mostly - some simplification)
		/// </summary>
		private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
			_saveDlg.Filter = ExportFilters.TEX0;
			_saveDlg.FilterIndex = 1;
			if (_saveDlg.ShowDialog() == DialogResult.OK) {
				int fIndex = _saveDlg.FilterIndex;

				//Fix extension
				string fileName = ApplyExtension(_saveDlg.FileName, _saveDlg.Filter, fIndex - 1);
				tex0.Export(fileName);
			}
		}
	}
}
