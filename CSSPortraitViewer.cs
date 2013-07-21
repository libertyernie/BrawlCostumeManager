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

		private static AdditionalTextureData[] additionalTextureData = {
			new AdditionalTextureData(128, 32, "MiscData[30]/Textures(NW4R)/MenSelchrChrNm.", i => i.ToString("D2") + "1"),
			new AdditionalTextureData(80, 56, "MiscData[70]/Textures(NW4R)/MenSelchrChrFace.0", i => (i + 1).ToString("D2")),
			new AdditionalTextureData(32, 32, "MiscData[90]/Textures(NW4R)/InfStc.", (i,j) => (i*10 + j + 1).ToString("D3")),
			new AdditionalTextureData(56, 14, "MiscData[70]/Textures(NW4R)/MenSelchrChrNmS.0", i => (i + 1).ToString("D2")),
		};

		private TEX0Node[] additionalTextures;
		private string _openFilePath;

		/// <summary>
		/// The common5 currently being used. If using sc_selcharacter.pac instead, this will be null.
		/// </summary>
		private ResourceNode common5;
		/// <summary>
		/// Either the sc_selcharacter_en archive within common5.pac or the sc_selcharacter.pac file.
		/// </summary>
		private ResourceNode sc_selcharacter;

		public CSSPortraitViewer() : base() {
			int a = additionalTextureData.Length;
			additionalTextures = new TEX0Node[a];
			foreach (var atd in additionalTextureData) {
				AdditionalControls.Add(atd.Panel);
				atd.OnUpdate += new EventHandler(delegate(object sender, EventArgs ea) {
					UpdateImage(_charNum, _costumeNum);
				});
			}
			UpdateDirectory();
		}

		protected override TEX0Node get_node(int charNum, int costumeNum) {
			string tex_number = (charNum * 10 + costumeNum + 1).ToString("D3");

			tex0 = null;
			panel1.BackgroundImage = null;

			if (costumeNum < 0) {
				label1.Text = "No portrait mapping";
				return null;
			}

			if (common5 != null) {
				label1.Text = "common5: ";
			} else if (sc_selcharacter != null) {
				label1.Text = "sc_selcharacter.pac: ";
			} else {
				return null;
			}

			string str1 = "char_bust_tex_lz77/MiscData[" + charNum + "]";
			string str2 = "Textures(NW4R)/MenSelchrFaceB." + tex_number;
			label1.Text += str2;
			ResourceNode get_node = sc_selcharacter.FindChild(str1 + "/" + str2, false);
			if (get_node is TEX0Node) {
				return (TEX0Node)get_node;
			} else {
				label1.Text += " (tex0 not found)";
				return null;
			}
		}

		public override bool UpdateImage(int charNum, int costumeNum) {
			if (base.UpdateImage(charNum, costumeNum)) {
				foreach (var atd in additionalTextureData) {
					atd.TextureFrom(sc_selcharacter, charNum, costumeNum);
				}
				return true;
			} else {
				foreach (var atd in additionalTextureData) {
					atd.Texture = null;
				}
				return false;
			}
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
	}
}
