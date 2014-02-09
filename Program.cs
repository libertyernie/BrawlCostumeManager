using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrawlCostumeManager {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try {
				trylib();
			} catch (Exception e) {
				MessageBox.Show(null, "Could not load BrawlManagerLib.dll.", e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var D = BrawlLib.Properties.Settings.Default;
			if (D.GetType().GetProperty("HideMDL0Errors") != null) {
				D.GetType().InvokeMember("HideMDL0Errors", System.Reflection.BindingFlags.SetProperty, null, D, new object[] { true });
			}

			Application.Run(new CostumeManager());
		}

		static void trylib() {
			var Q = new BrawlManagerLib.CollapsibleSplitter();
		}
	}
}
