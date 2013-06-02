using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlCharacterManager {
	public partial class CostumeManager : Form {
		public CostumeManager() {
			InitializeComponent();
			readDir();
		}

		private void readDir() {
			foreach (string charname in Constants.CharactersByCSSOrder) {
				if (charname != null) listBox1.Items.Add(charname);
			}
		}

		public void LoadFile(string path) {
			modelManager1.LoadFile(path);
		}

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
			object selected = listBox2.SelectedItem;
			string path;
			if (selected is FighterFile) {
				FighterFile ff = (FighterFile)selected;
				cssPortraitViewer1.UpdateImage(ff.CharNum, ff.CostumeNum);
				resultPortraitViewer1.UpdateImage(ff.CharNum, ff.CostumeNum);
				path = ff.FullName;
			} else if (selected is FileInfo) {
				path = (selected as FileInfo).FullName;
			} else {
				path = selected.ToString();
			}
			LoadFile(path);
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			string charname = listBox1.SelectedItem.ToString();
			int charNum = Array.IndexOf(Constants.CharactersByCSSOrder, charname);
			listBox2.Items.Clear();
			int upperBound = (charname.ToLower() == "wario") ? 12 : 10;
			for (int i = 0; i < upperBound; i++) {
				string pathNoExt = "fighter/" + charname + "/fit" + charname + i.ToString("D2");
				listBox2.Items.Add(new FighterFile(pathNoExt + ".pac", charNum, i));
				listBox2.Items.Add(new FighterFile(pathNoExt + ".pcs", charNum, i));
				if (charname.ToLower() == "kirby") {
					foreach (string hatchar in Constants.KirbyHats) {
						listBox2.Items.Add(new FighterFile("fighter/kirby/fitkirby" + hatchar + i.ToString("D2") + ".pac", charNum, i));
					}
				}
			}
			listBox2.SelectedIndex = 0;
		}
	}
}
