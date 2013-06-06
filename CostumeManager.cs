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
		private static string TITLE = "Brawl Costume Manager";

		private List<PortraitViewer> portraitViewers;
		public bool Use_cBliss;

		public CostumeManager() {
			InitializeComponent();
			portraitViewers = new List<PortraitViewer> {cssPortraitViewer1, resultPortraitViewer1};

			if (!new DirectoryInfo("fighter").Exists && new DirectoryInfo("/private/wii/app/RSBE/pf/fighter").Exists) {
				System.Environment.CurrentDirectory = "/private/wii/app/RSBE/pf";
			}

			readDir();
		}

		private void readDir() {
			Text = TITLE + " - " + System.Environment.CurrentDirectory;

			int selectedIndex = listBox1.SelectedIndex;
			listBox1.Items.Clear();
			foreach (string charname in Constants.CharactersByCSSOrder) {
				if (charname != null) listBox1.Items.Add(charname);
			}
			foreach (PortraitViewer p in portraitViewers) {
				p.UpdateDirectory();
			}
			if (selectedIndex >= 0) {
				listBox1.SelectedIndex = selectedIndex;
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

		public void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			updateCostumeSelectionPane();
		}

		public void updateCostumeSelectionPane() {
			int selectedIndex = listBox2.SelectedIndex;

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
			listBox2.SelectedIndex = (selectedIndex < listBox2.Items.Count) ? selectedIndex : 0;
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

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
			listBox2.SelectedIndex = listBox2.IndexFromPoint(listBox2.PointToClient(Cursor.Position));
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
			string toDelete = (listBox2.SelectedItem as FighterFile).FullName;
			if (Path.HasExtension(toDelete)) {
				toDelete = toDelete.Substring(0, toDelete.LastIndexOf('.'));
			}
			FileInfo pac = new FileInfo(toDelete + ".pac");
			FileInfo pcs = new FileInfo(toDelete + ".pcs");
			modelManager1.LoadFile(null);
			pac.Delete();
			pcs.Delete();
			updateCostumeSelectionPane();
		}
	}
}
