using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrawlLib.SSBB.ResourceNodes;

namespace BrawlCharacterManager {
	public class CSSPortraitViewer : PortraitViewer {
		/// <summary>
		/// The common5 currently being used. If using sc_selcharacter.pac instead, this will be null.
		/// </summary>
		private ResourceNode common5;
		/// <summary>
		/// Either the sc_selcharacter_en archive within common5.pac or the sc_selcharacter.pac file.
		/// </summary>
		private ResourceNode sc_selcharacter;

		public CSSPortraitViewer() : base() {
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

		public override void UpdateDirectory() {
			try {
				common5 = null;
				sc_selcharacter = NodeFactory.FromFile(null, "menu2/sc_selcharacter.pac");
			} catch (IOException) {
				try {
					common5 = NodeFactory.FromFile(null, "system/common5.pac");
					sc_selcharacter = common5.FindChild("sc_selcharacter_en", false);
				} catch (IOException) {
					common5 = null;
					sc_selcharacter = null;
					label1.Text = "Could not load sc_selcharacter or common5.";
				}
			}
		}

		protected override void saveButton_Click(object sender, EventArgs e) {
			if (sc_selcharacter == null) {
				return;
			}

			if (common5 != null) {
				common5.Merge();
				common5.Export("system/common5.pac");
			} else {
				sc_selcharacter.Merge();
				sc_selcharacter.Export("menu2/sc_selcharacter_out.pac");
			}
		}
	}
}
