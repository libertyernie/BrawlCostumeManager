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

			/*var regex = new System.Text.RegularExpressions.Regex(@"[01][0-9]\.(pac|pcs)");
			DirectoryInfo fighter = new DirectoryInfo("C:\\Brawl\\fighter");
			foreach (DirectoryInfo chardir in fighter.EnumerateDirectories()) {
				foreach (FileInfo file in chardir.EnumerateFiles()) {
					if (regex.Match(file.Name.ToLower()).Success) {
						listBox1.Items.Add(file);
					}
				}
			}*/

			foreach (string charname in Constants.CharacterNames) {
				int upperBound = (charname.ToLower() == "wario") ? 12 : 10;
				for (int i = 0; i < upperBound; i++) {
					string pathNoExt = charname + "/fit" + charname + i.ToString("D2");
					listBox1.Items.Add(pathNoExt + ".pac");
					listBox1.Items.Add(pathNoExt + ".pcs");
					if (charname.ToLower() == "kirby") {
						foreach (string hatchar in Constants.KirbyHats) {
							listBox1.Items.Add("kirby/fitkirby" + hatchar + i.ToString("D2") + ".pac");
						}
					}
				}
			}
		}

		public void LoadFile(string path) {
			modelManager1.LoadFile(path);
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			object selected = listBox1.SelectedItem;
			string path;
			if (selected is FileInfo) {
				path = (selected as FileInfo).FullName;
			} else {
				path = selected.ToString();
			}
			LoadFile(path);
		}
	}
}
