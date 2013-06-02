using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrawlCharacterManager {
	public class FighterFile {
		private FileInfo path;
		private int charNum, costumeNum;
		public string FullName {
			get {
				return path.FullName;
			}
		}

		public FighterFile(FileInfo path, int charNum, int costumeNum) {
			this.path = path;
			this.charNum = charNum;
			this.costumeNum = costumeNum;
		}

		public FighterFile(string path, int charNum, int costumeNum) :
		this(new FileInfo(path), charNum, costumeNum) {}

		public override string ToString() {
			string name = path.Name;
			if (!path.Exists) {
				name = "(" + name + ")";
			}
			return name;
		}
	}
}
