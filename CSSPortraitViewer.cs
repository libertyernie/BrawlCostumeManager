using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlCostumeManager {
	public class CSSPortraitViewer : PortraitViewer {
		public override int PortraitWidth {
			get { return 128; }
		}
		public override int PortraitHeight {
			get { return 160; }
		}

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
			panel2.Visible = true;
			panel3.Visible = true;
			panel4.Visible = true;
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

		public override void UpdateImage(int charNum, int costumeNum) {
			base.UpdateImage(charNum, costumeNum);
			string path;

			path = "MiscData[30]/Textures(NW4R)/MenSelchrChrNm." + charNum.ToString("D2") + "1";
			TEX0Node ChrNm = sc_selcharacter.FindChild(path, false) as TEX0Node;
			if (ChrNm != null) {
				Bitmap bitmap = new Bitmap(ChrNm.GetImage(0), 128, 32);
				panel2.BackgroundImage = bitmap;
			}

			path = "MiscData[70]/Textures(NW4R)/MenSelchrChrFace.0" + (charNum + 1).ToString("D2");
			TEX0Node ChrFace = sc_selcharacter.FindChild(path, false) as TEX0Node;
			if (ChrFace != null) {
				Bitmap bitmap = new Bitmap(ChrFace.GetImage(0), 80, 56);
				panel3.BackgroundImage = bitmap;
			}

			path = "MiscData[70]/Textures(NW4R)/MenSelchrChrNmS.0" + (charNum + 1).ToString("D2");
			TEX0Node ChrNmS = sc_selcharacter.FindChild(path, false) as TEX0Node;
			if (ChrNmS != null) {
				Bitmap bitmap = ChrNmS.GetImage(0);
				panel4.BackgroundImage = bitmap;
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
