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
using BrawlLib;

namespace BrawlCostumeManager {
	public partial class CostumeManager : Form {
		private static string DASH = "-";
		private static string TITLE = "Brawl Costume Manager";

		private List<PortraitViewer> portraitViewers;
		public bool Use_cBliss;
		public bool Swap_Wario;

		public CostumeManager() {
			InitializeComponent();
			try {
				Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			} catch (Exception) {}
			portraitViewers = new List<PortraitViewer> {cssPortraitViewer1, resultPortraitViewer1, battlePortraitViewer1};

			if (!new DirectoryInfo("fighter").Exists && new DirectoryInfo("/private/wii/app/RSBE/pf/fighter").Exists) {
				System.Environment.CurrentDirectory = "/private/wii/app/RSBE/pf";
			}

			readDir();
		}

		private void readDir() {
			if (!Directory.Exists("fighter") && Directory.Exists(System.Environment.CurrentDirectory + "/private/wii/app/RSBE/pf")) {
				System.Environment.CurrentDirectory += "/private/wii/app/RSBE/pf";
				readDir();
				return;
			}

			Text = TITLE + " - " + System.Environment.CurrentDirectory;

			int selectedIndex = listBox1.SelectedIndex;
			listBox1.Items.Clear();
			listBox1.Items.Add(DASH);
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
			if (ff == null) return;
			int portraitNum = ff.CostumeNum;
			string charName = Constants.CharactersByCSSOrder[ff.CharNum];
			if (!Use_cBliss) {
				if (Constants.PortraitToCostumeMappings.ContainsKey(charName)) {
					int[] mappings = Constants.PortraitToCostumeMappings[charName];
					portraitNum = Array.IndexOf(mappings, ff.CostumeNum);
				}
			}
			if (charName == "wario" && Swap_Wario) {
				portraitNum = (portraitNum + 6) % 12;
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
			listBox2.Items.Clear();
			if (charname == DASH) {
				foreach (FileInfo f in new DirectoryInfo(".").EnumerateFiles()) {
					string name = f.Name.ToLower();
					if (name.EndsWith(".pac") || name.EndsWith(".pcs")) {
						listBox2.Items.Add(new FighterFile(f.Name, 1, 1));
					}
				}
			} else {
				int charNum = Array.IndexOf(Constants.CharactersByCSSOrder, charname);
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

		private void swapPortraitsForWarioStylesToolStripMenuItem_Click(object sender, EventArgs e) {
			Swap_Wario = swapPortraitsForWarioStylesToolStripMenuItem.Checked;
			foreach (PortraitViewer p in portraitViewers) {
				RefreshPortraits();
			}
		}

		private void aboutBrawlCostumeManagerToolStripMenuItem_Click(object sender, EventArgs e) {
			new About(Icon).Show();
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
			if (DialogResult.Yes == MessageBox.Show(
				"Are you sure you want to delete " + pac.Name + "/" + pcs.Name + "?",
				"Confirm", MessageBoxButtons.YesNo)) {
				modelManager1.LoadFile(null);
				if (pac.Exists) pac.Delete();
				if (pcs.Exists) pcs.Delete();
				updateCostumeSelectionPane();
			}
		}

		private void copyToToolStripMenuItem_Click(object sender, EventArgs e) {
			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "PAC Archive (*.pac)|*.pac|" +
					"Compressed PAC Archive (*.pcs)|*.pcs|" +
					"Archive Pair (*.pair)|*.pair";
				if (dlg.ShowDialog(this) == DialogResult.OK) {
					modelManager1.WorkingRoot.Export(dlg.FileName);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			if (flowLayoutPanel1.Visible) {
				flowLayoutPanel1.Visible = false;
				button1.Text = "<";
			} else {
				flowLayoutPanel1.Visible = true;
				button1.Text = ">";
			}
		}

		private void updateSSSStockIconsToolStripMenuItem_Click(object sender, EventArgs e) {
			cssPortraitViewer1.UpdateSSSStockIcons();
		}

		private void copyToOtherPacpcsToolStripMenuItem_Click(object sender, EventArgs e) {
			string charfile = ((FighterFile)listBox2.SelectedItem).FullName;
			if (charfile.EndsWith(".pac", StringComparison.InvariantCultureIgnoreCase)) {
				modelManager1.WorkingRoot.Export(charfile.Substring(0, charfile.Length - 4) + ".pcs");
				updateCostumeSelectionPane();
			} else if (charfile.EndsWith(".pcs", StringComparison.InvariantCultureIgnoreCase)) {
				modelManager1.WorkingRoot.Export(charfile.Substring(0, charfile.Length - 4) + ".pac");
				updateCostumeSelectionPane();
			} else {
				MessageBox.Show("Not a .pac or .pcs file");
			}
		}
	}
}
