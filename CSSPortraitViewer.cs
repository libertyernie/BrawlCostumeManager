using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrawlLib.SSBB.ResourceNodes;
using System.Windows.Forms;

namespace BrawlCostumeManager {
	public class CSSPortraitViewer : PortraitViewer {
		public override int PortraitWidth {
			get { return 128; }
		}
		public override int PortraitHeight {
			get { return 160; }
		}
		public override ResourceNode TEX0For(ResourceNode brres, int charNum, int costumeNum) {
			string tex_number = (charNum * 10 + costumeNum + 1).ToString("D3");
			string path = "char_bust_tex_lz77/MiscData[" + charNum + "]/Textures(NW4R)/MenSelchrFaceB." + tex_number;
			return brres.FindChild(path, false);
		}
		public override ResourceNode PortraitRootFor(int charNum, int costumeNum) {
			return sc_selcharacter;
		}

		private bool _namePortraitPreview;
		public bool NamePortraitPreview {
			get {
				return _namePortraitPreview;
			}
			set {
				_namePortraitPreview = value;
				UpdateImage(_charNum, _costumeNum);
			}
		}

		private static PortraitViewerTextureData[] additionalTextureData = {
			new PortraitViewerTextureData(128, 32, (i,j) => "MiscData[30]/Textures(NW4R)/MenSelchrChrNm." + i.ToString("D2") + "1"),
			new PortraitViewerTextureData(80, 56, (i,j) => "MiscData[70]/Textures(NW4R)/MenSelchrChrFace.0" + (i + 1).ToString("D2")),
			new PortraitViewerTextureData(32, 32, (i,j) => "MiscData[90]/Textures(NW4R)/InfStc." + (i*10 + j + 1).ToString("D3")),
			new PortraitViewerTextureData(56, 14, (i,j) => "MiscData[70]/Textures(NW4R)/MenSelchrChrNmS.0" + (i + 1).ToString("D2")),
		};

		private string _openFilePath;

		/// <summary>
		/// The common5 currently being used. If using sc_selcharacter.pac instead, this will be null.
		/// </summary>
		private ResourceNode common5;
		/// <summary>
		/// Either the sc_selcharacter_en archive within common5.pac or the sc_selcharacter.pac file.
		/// </summary>
		private ResourceNode sc_selcharacter;
		private ToolStripMenuItem copyPreview;

		public CSSPortraitViewer() : base() {
			int a = additionalTextureData.Length;
			foreach (var atd in additionalTextureData) {
				AdditionalControls.Add(atd.Panel);
				atd.OnUpdate = delegate(PortraitViewerTextureData sender) {
					UpdateImage(_charNum, _costumeNum);
				};
			}
			UpdateDirectory();
			label1.Text = (common5 != null ? "common5" : "sc_selcharacter");

            copyPreview = new ToolStripMenuItem("Copy preview");
			copyPreview.Click += delegate(object sender, EventArgs e) { Clipboard.SetImage(texture.Panel.BackgroundImage); };
            texture.Panel.ContextMenuStrip.Items.Add(copyPreview);
		}

		public override bool UpdateImage(int charNum, int costumeNum) {
            bool success = base.UpdateImage(charNum, costumeNum);
			if (success) {
				foreach (var atd in additionalTextureData) {
					atd.TextureFrom(sc_selcharacter, charNum, costumeNum);
				}
                if (NamePortraitPreview) OverlayName();
				return true;
			} else {
				foreach (var atd in additionalTextureData) {
					atd.Texture = null;
				}
				return false;
			}
		}

		private void OverlayName() {
			Image orig = this.texture.Panel.BackgroundImage;

			Bitmap name = new Bitmap(additionalTextureData[0].Texture.GetImage(0));
			Bitmap swapped = BitmapUtilities.AlphaSwap(name);
			Bitmap blurred = BitmapUtilities.BlurCombine(swapped, Color.Black);

			Bitmap overlaid = new Bitmap(orig.Width, orig.Height);
			Graphics g = Graphics.FromImage(overlaid);
			g.DrawImage(orig,
				new Rectangle(0, 0, 128, 128),
				new Rectangle(0, 0, 128, 128),
				GraphicsUnit.Pixel);
			g.DrawImage(blurred, new Point[] {
				new Point(0, 98),
				new Point(131, 98),
				new Point(-3, 127)
			});
			this.texture.Panel.BackgroundImage = overlaid;
		}

		public override void UpdateDirectory() {
			if (File.Exists("menu2/sc_selcharacter.pac")) {
				string path = "menu2/sc_selcharacter.pac";
				common5 = null;
				sc_selcharacter = NodeFactory.FromFile(null, path);
				_openFilePath = path;
			} else if (File.Exists("menu2/sc_selcharacter_en.pac")) {
				string path = "menu2/sc_selcharacter_en.pac";
				common5 = null;
				sc_selcharacter = NodeFactory.FromFile(null, path);
				_openFilePath = path;
			} else if (File.Exists("system/common5.pac")) {
				string path = "system/common5.pac";
				common5 = NodeFactory.FromFile(null, path);
				sc_selcharacter = common5.FindChild("sc_selcharacter_en", false);
				_openFilePath = path;
			} else if (File.Exists("system/common5_en.pac")) {
				string path = "system/common5_en.pac";
				common5 = NodeFactory.FromFile(null, path);
				sc_selcharacter = common5.FindChild("sc_selcharacter_en", false);
				_openFilePath = path;
			} else {
				common5 = null;
				sc_selcharacter = null;
				label1.Text = "Could not load sc_selcharacter or common5(_en).";
			}
		}

		protected override void saveButton_Click(object sender, EventArgs e) {
			if (sc_selcharacter == null) {
				return;
			}

			if (common5 != null) {
				common5.Merge();
				common5.Export(_openFilePath);
			} else {
				sc_selcharacter.Merge();
				sc_selcharacter.Export(_openFilePath);
			}
		}

		public void UpdateSSSStockIcons() {
			if (common5 == null) {
				MessageBox.Show(this.FindForm(), "common5.pac is not loaded - can't update automatically.\n" +
					"After saving sc_selcharacter.pac,  update the icons manually by replacing sc_selmap's " +
					"MiscData[40] with sc_selcharacter's MiscData[90].", "Cannot perform operation",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else {
				ResourceNode css_stockicons = sc_selcharacter.FindChild("MiscData[90]", false);
				string tempFile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".brres";
				css_stockicons.Export(tempFile);
				ResourceNode sss_stockicons = common5.FindChild("sc_selmap_en/MiscData[40]", false);
				sss_stockicons.Replace(tempFile);
				try {
					File.Delete(tempFile);
				} catch (Exception) { }
			}
		}
	}
}
