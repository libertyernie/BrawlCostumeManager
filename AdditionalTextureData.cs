using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlCostumeManager {
	public class AdditionalTextureData {
		public Size Size { get; private set; }
		public string Prefix { get; private set; }
		public Func<int, int, string> SuffixFunc { get; private set; }

		public string this[int charNum, int costumeNum] {
			get {
				return Prefix + SuffixFunc(charNum, costumeNum);
			}
		}

		private Panel _panel;
		public Panel Panel {
			get {
				if (_panel == null) {
					_panel = new Panel() { Size = Size };
				}
				return _panel;
			}
		}

		public AdditionalTextureData(int width, int height, string prefix, Func<int, string> SuffixFunc) {
			this.Size = new Size(width, height);
			this.Prefix = prefix;
			this.SuffixFunc = (x,y) => SuffixFunc(x);
		}

		public AdditionalTextureData(int width, int height, string prefix, Func<int, int, string> SuffixFunc) {
			this.Size = new Size(width, height);
			this.Prefix = prefix;
			this.SuffixFunc = SuffixFunc;
		}
	}
}
