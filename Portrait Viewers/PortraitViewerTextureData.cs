﻿using BrawlLib;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.Wii.Textures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlCostumeManager {
	public class PortraitViewerTextureData {
		/// <summary>
		/// A PortraitViewer always has one texture, but it can have more than one.
        /// Each texture will get its own PortraitViewerTextureData instance, and this
        /// function will return the texture node given the container, character ID, and costume ID.
		/// </summary>
		public Func<ResourceNode, int, int, ResourceNode> GetTEX0Func { get; private set; }

		public Size Size { get; private set; }
		public delegate void VD(PortraitViewerTextureData sender);
		public VD OnUpdate;

		private static OpenFileDialog _openDlg = new OpenFileDialog();
		private static SaveFileDialog _saveDlg = new SaveFileDialog();

		private TEX0Node _texture;
		public TEX0Node Texture {
			get {
				return _texture;
			}
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
		public void TextureFrom(ResourceNode node, int charNum, int costumeNum) {
			Texture = node == null ? null : GetTEX0Func(node, charNum, costumeNum) as TEX0Node;
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
                    var copy = new ToolStripMenuItem() { Text = "Copy Texture" };
                    copy.Click += copy_Click;
                    _panel.ContextMenuStrip.Items.Add(copy);
				}
				return _panel;
			}
		}

		/// <summary>
		/// Constructor for the main texture in the PortraitViewer - getting the TEX0 using the PortraitViewer's TEX0For function
		/// </summary>
		public PortraitViewerTextureData(int width, int height, SinglePortraitViewer parent)
			: this(width, height, parent.MainTEX0For) {
		}

		/// <summary>
		/// For additional textures in the file - getting these TEX0s using lambda functions
		/// which return the path (not the node itself)
		/// </summary>
		public PortraitViewerTextureData(int width, int height, Func<int, int, string> GetTEX0Func)
			: this(width, height, (n, x, y) => n.FindChild(GetTEX0Func(x, y), false)) {
		}

		private PortraitViewerTextureData(int width, int height, Func<ResourceNode, int, int, ResourceNode> GetTEX0Func) {
			this.Size = new Size(width, height);
			this.GetTEX0Func = GetTEX0Func;
		}

		void export_Click(object sender, EventArgs e) {
			_saveDlg.Filter = FileFilters.TEX0;
			_saveDlg.FilterIndex = 1;
			if (_saveDlg.ShowDialog() == DialogResult.OK) {
				int fIndex = _saveDlg.FilterIndex;

				// Fix extension
				string fileName = ApplyExtension(_saveDlg.FileName, _saveDlg.Filter, fIndex - 1);
				Texture.Export(fileName);
			}
		}

		void replace_Click(object sender, EventArgs e) {
			_openDlg.Filter = FileFilters.TEX0;
			if (_openDlg.ShowDialog() == DialogResult.OK) {
				string fileName = _openDlg.FileName;
				Replace(fileName, true);
				if (OnUpdate != null) {
					OnUpdate(this);
				}
			}
		}

        void copy_Click(object sender, EventArgs e)
        {
            //Clipboard.SetImage(Texture.GetImage(0));
            using (MemoryStream stream = new MemoryStream())
            {
                Texture.GetImage(0).Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                var data = new DataObject("PNG", stream);
                Clipboard.Clear();
                Clipboard.SetDataObject(data, true);
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
				Replace((e.Data.GetData(DataFormats.FileDrop) as string[])[0], false);
			}
		}

		public void Replace(string filename, bool useTextureConverter) {
			if (Texture == null) return;

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
					Replace(tempFile, useTextureConverter); // call self with new file
					File.Delete(tempFile);
				}
			} else {
				if (useTextureConverter) {
					using (TextureConverterDialog dlg = new TextureConverterDialog()) {
						dlg.ImageSource = filename;
						if (dlg.ShowDialog(null, Texture) == DialogResult.OK) {
							if (OnUpdate != null) OnUpdate(this);
						}
					}
				} else {
					if (Texture.Format == WiiPixelFormat.CMPR) {
						Bitmap bitmap = new Bitmap(filename);
						UnsafeBuffer buffer = TextureConverter.CMPR.GeneratePreview(bitmap);
						BrawlLib.IO.FileMap textureData = TextureConverter.CMPR.EncodeTEX0TextureCached(bitmap, Texture.LevelOfDetail, buffer);
						Texture.ReplaceRaw(textureData);
					} else {
						Texture.Replace(filename);
					}
					if (OnUpdate != null) OnUpdate(this);
				}
			}
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
