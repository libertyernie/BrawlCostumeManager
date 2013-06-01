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
		public CostumeManager(string path) {
			InitializeComponent();
			modelManager1.LoadFileDelayed(path);

			foreach (string charname in Constants.CharactersByCSSOrder) {
				if (charname != null) listBox1.Items.Add(charname);
			}
		}

		public void LoadFile(string path) {
			modelManager1.LoadFile(path);
		}

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
			int charnum = Array.IndexOf(Constants.CharactersByCSSOrder, listBox1.SelectedItem);
			cssPortraitViewer1.UpdateImage(charnum, listBox2.SelectedIndex / 2);
			object selected = listBox2.SelectedItem;
			string path;
			if (selected is FileInfo) {
				path = (selected as FileInfo).FullName;
			} else {
				path = selected.ToString();
			}
			LoadFile(path);
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			string charname = listBox1.SelectedItem.ToString();
			listBox2.Items.Clear();
			int upperBound = (charname.ToLower() == "wario") ? 12 : 10;
			for (int i = 0; i < upperBound; i++) {
				string pathNoExt = "fighter/" + charname + "/fit" + charname + i.ToString("D2");
				listBox2.Items.Add(pathNoExt + ".pac");
				listBox2.Items.Add(pathNoExt + ".pcs");
				if (charname.ToLower() == "kirby") {
					foreach (string hatchar in Constants.KirbyHats) {
						listBox2.Items.Add("fighter/kirby/fitkirby" + hatchar + i.ToString("D2") + ".pac");
					}
				}
			}
			listBox2.SelectedIndex = 0;
		}
	}
}
