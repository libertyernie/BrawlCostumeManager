using BrawlLib;
using BrawlLib.SSBB.ResourceNodes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlCostumeManager {
	public class AdditionalTextureData {
		public Size Size { get; private set; }
		public Func<int, int, string> PathFunc { get; private set; }
		public delegate void VD(AdditionalTextureData sender);
		public VD OnUpdate;

		private static OpenFileDialog _openDlg = new OpenFileDialog();
		private static SaveFileDialog _saveDlg = new SaveFileDialog();

		public string this[int charNum, int costumeNum] {
			get {
				return PathFunc(charNum, costumeNum);
			}
		}

		private TEX0Node _texture;
		public TEX0Node Texture {
			get {
				return _texture;
			}
			set {
				_texture = value;
				if (_texture != null) {
					Bitmap bitmap = new Bitmap(_texture.GetImage(0), Size);
					/*Form f = new Form();
					Panel p = new Panel() { BackgroundImage = bitmap, Dock = DockStyle.Fill };
					f.Controls.Add(p);
					f.ShowDialog();*/
					Panel.BackgroundImage = bitmap;
				} else {
					Panel.BackgroundImage = null;
				}
			}
		}
		public void TextureFrom(ResourceNode sc_selcharacter, int charNum, int costumeNum) {
			Texture = sc_selcharacter == null ? null : sc_selcharacter.FindChild(this[charNum, costumeNum], false) as TEX0Node;
		}

		private Panel _panel;
		public Panel Panel {
			get {
				if (_panel == null) {
					_panel = new Panel() { Size = Size, AllowDrop = true, Margin = Padding.Empty };
					_panel.DragEnter += _panel_DragEnter;
					_panel.DragDrop += _panel_DragDrop;
					_panel.ContextMenuStrip = new ContextMenuStrip();

					var replace = new ToolStripMenuItem() { Text = "Replace" };
					replace.Click += replace_Click;
					_panel.ContextMenuStrip.Items.Add(replace);
					var export = new ToolStripMenuItem() { Text = "Export" };
					export.Click += export_Click;
					_panel.ContextMenuStrip.Items.Add(export);
				}
				return _panel;
			}
		}

		void export_Click(object sender, EventArgs e) {
			_saveDlg.Filter = ExportFilters.TEX0;
			_saveDlg.FilterIndex = 1;
			if (_saveDlg.ShowDialog() == DialogResult.OK) {
				int fIndex = _saveDlg.FilterIndex;

				//Fix extension
				string fileName = ApplyExtension(_saveDlg.FileName, _saveDlg.Filter, fIndex - 1);
				Texture.Export(fileName);
			}
		}

		void replace_Click(object sender, EventArgs e) {
			_openDlg.Filter = ExportFilters.TEX0;
			if (_openDlg.ShowDialog() == DialogResult.OK) {
				string fileName = _openDlg.FileName;
				Texture.Replace(fileName);
				if (OnUpdate != null) {
					OnUpdate(this);
				}
			}
		}

		void _panel_DragEnter(object sender, DragEventArgs e) {
			if (_texture != null && e.Data.GetDataPresent(DataFormats.FileDrop)) {
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

		void _panel_DragDrop(object sender, DragEventArgs e) {
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
					if (dlg.ShowDialog(null, _texture) == DialogResult.OK) {
						if (OnUpdate != null) {
							OnUpdate(this);
						}
					}
				}
			}
		}

		public AdditionalTextureData(int width, int height, string path)
			: this(width, height, (x, y) => path) {
		}

		public AdditionalTextureData(int width, int height, Func<int, string> PathFunc)
			: this(width, height, (x, y) => PathFunc(x)) {
		}

		public AdditionalTextureData(int width, int height, Func<int, int, string> PathFunc) {
			this.Size = new Size(width, height);
			this.PathFunc = PathFunc;
		}

		/// <summary>
		/// Method lifted directly from BrawlBox.
		/// </summary>
		public static string ApplyExtension(string path, string filter, int filterIndex) {
			int tmp;
			if ((Path.HasExtension(path)) && (!int.TryParse(Path.GetExtension(path), out tmp))) return path;

			int index = filter.IndexOfOccurance('|', filterIndex * 2);
			if (index == -1) return path;

			index = filter.IndexOf('.', index);
			int len = Math.Max(filter.Length, filter.IndexOfAny(new char[] { ';', '|' })) - index;

			string ext = filter.Substring(index, len);

			if (ext.IndexOf('*') >= 0) return path;

			return path + ext;
		}
	}
}
