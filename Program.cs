using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrawlCharacterManager {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			string path = null;
			if (args.Count() > 0) {
				path = args[0];
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(path));
		}
	}
}
