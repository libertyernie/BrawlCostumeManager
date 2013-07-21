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

		protected ControlCollection AdditionalControls {
			get {
				return additionalTexturesPanel.Controls;
			}
		}

		public abstract int PortraitWidth {
			get;
		}
		public abstract int PortraitHeight {
			get;
		}
		public abstract ResourceNode PortraitRootFor(int charNum, int costumeNum);
		public abstract string PortraitPathFor(int charNum, int costumeNum);

		protected AdditionalTextureData texture;

		// In case the image needs to be reloaded after replacing the texture
		protected int _charNum, _costumeNum;

		public PortraitViewer() {
			InitializeComponent();
			texture = new AdditionalTextureData(PortraitWidth, PortraitHeight, PortraitPathFor);
			additionalTexturesPanel.Controls.Add(texture.Panel);
			texture.Panel.ContextMenuStrip = contextMenuStrip1;
			texture.OnUpdate = delegate(AdditionalTextureData sender) {
					UpdateImage(_charNum, _costumeNum);
				};

			_charNum = -1;
			_costumeNum = -1;
		}

		public virtual bool UpdateImage(int charNum, int costumeNum) {
			_charNum = charNum;
			_costumeNum = costumeNum;
			ResourceNode bres = PortraitRootFor(charNum, costumeNum);
			label1.Text = bres.RootNode.Name;
			texture.TextureFrom(bres, charNum, costumeNum);
			return texture.Texture != null;
		}

		public abstract void UpdateDirectory();

		protected abstract void saveButton_Click(object sender, EventArgs e);

		private void replaceToolStripMenuItem_Click(object sender, EventArgs e) {
			_openDlg.Filter = ExportFilters.TEX0;
			if (_openDlg.ShowDialog() == DialogResult.OK) {
				string fileName = _openDlg.FileName;
				texture.Replace(fileName);
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
				texture.Texture.Export(fileName);
			}
		}
	}
}
