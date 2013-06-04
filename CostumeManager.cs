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

namespace BrawlCostumeManager {
	public partial class CostumeManager : Form {
		private List<PortraitViewer> portraitViewers;
		public bool Use_cBliss;

		public CostumeManager() {
			InitializeComponent();
			portraitViewers = new List<PortraitViewer> {cssPortraitViewer1, resultPortraitViewer1};
			readDir();
		}

		private void readDir() {
			listBox1.Items.Clear();
			foreach (string charname in Constants.CharactersByCSSOrder) {
				if (charname != null) listBox1.Items.Add(charname);
			}
			foreach (PortraitViewer p in portraitViewers) {
				p.UpdateDirectory();
			}
		}

		public void LoadFile(string path) {
			modelManager1.LoadFile(path);
		}

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
			FighterFile ff = (FighterFile)listBox2.SelectedItem;
			string path = ff.FullName;
			LoadFile(path);
			RefreshPortraits();
		}

		public void RefreshPortraits() {
			FighterFile ff = (FighterFile)listBox2.SelectedItem;
			int portraitNum = ff.CostumeNum;
			if (!Use_cBliss) {
				string charName = Constants.CharactersByCSSOrder[ff.CharNum];
				if (Constants.PortraitToCostumeMappings.ContainsKey(charName)) {
					int[] mappings = Constants.PortraitToCostumeMappings[charName];
					portraitNum = Array.IndexOf(mappings, ff.CostumeNum);
				}
			}
			foreach (PortraitViewer p in portraitViewers) {
				p.UpdateImage(ff.CharNum, portraitNum);
			}
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

		private void changeDirectory_Click(object sender, EventArgs e) {
			FolderBrowserDialog fbd = new FolderBrowserDialog();
//			fbd.SelectedPath = CurrentDirectory; // Uncomment this if you want the "change directory" dialog to start with the current directory selected
			if (fbd.ShowDialog() == DialogResult.OK) {
				System.Environment.CurrentDirectory = fbd.SelectedPath;
				readDir();
			}
		}

		private void hidePolygonsCheckbox_Click(object sender, EventArgs e) {
			modelManager1.UseExceptions = hidePolygonsCheckbox.Checked;
			modelManager1.RefreshModel();
		}

		private void cBlissCheckbox_Click(object sender, EventArgs e) {
			Use_cBliss = cBlissCheckbox.Checked;
			foreach (PortraitViewer p in portraitViewers) {
				RefreshPortraits();
			}
		}

		private void aboutBrawlCostumeManagerToolStripMenuItem_Click(object sender, EventArgs e) {
			new About(null).Show();
		}
	}
}
