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
		public string Prefix { get; private set; }
		public Func<int, int, string> SuffixFunc { get; private set; }
		public event EventHandler OnUpdate;

		public string this[int charNum, int costumeNum] {
			get {
				return Prefix + SuffixFunc(charNum, costumeNum);
			}
		}

		private TEX0Node _texture;
		public TEX0Node Texture {
			set {
				_texture = value;
				if (_texture != null) {
					Bitmap bitmap = new Bitmap(_texture.GetImage(0), Size);
					Panel.BackgroundImage = bitmap;
				} else {
					Panel.BackgroundImage = null;
				}
			}
		}
		public void TextureFrom(ResourceNode sc_selcharacter, int charNum, int costumeNum) {
			Texture = sc_selcharacter.FindChild(this[charNum, costumeNum], false) as TEX0Node;
		}

		private Panel _panel;
		public Panel Panel {
			get {
				if (_panel == null) {
					_panel = new Panel() { Size = Size, AllowDrop = true };
					_panel.DragEnter += _panel_DragEnter;
					_panel.DragDrop += _panel_DragDrop;
				}
				return _panel;
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

		private void Replace(string filename) {
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
						OnUpdate.Invoke(this, new EventArgs());
					}
				}
			}
		}

		public AdditionalTextureData(int width, int height, string prefix, Func<int, string> SuffixFunc)
		: this(width, height, prefix, (x,y) => SuffixFunc(x)) {
		}

		public AdditionalTextureData(int width, int height, string prefix, Func<int, int, string> SuffixFunc) {
			this.Size = new Size(width, height);
			this.Prefix = prefix;
			this.SuffixFunc = SuffixFunc;
		}
	}
}
