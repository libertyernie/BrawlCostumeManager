﻿using System;
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
				accessLibraries();
			} catch (Exception e) {
				MessageBox.Show(null, e.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Application.Run(new CostumeManager());
		}

		private static void accessLibraries() {
			var D = BrawlLib.Properties.Settings.Default;
			if (D.GetType().GetProperty("HideMDL0Errors") != null) {
				D.GetType().InvokeMember("HideMDL0Errors", System.Reflection.BindingFlags.SetProperty, null, D, new object[] { true });
			}
			var Q = new BrawlManagerLib.CollapsibleSplitter();
		}
	}
}
