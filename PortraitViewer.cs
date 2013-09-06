using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrawlLib.SSBB.ResourceNodes;
using System.IO;
using BrawlLib;

namespace BrawlCostumeManager {
	public abstract partial class PortraitViewer : UserControl {

		protected ControlCollection AdditionalControls {
			get {
				return additionalTexturesPanel.Controls;
			}
		}

		public abstract int PortraitWidth {
			get;
		}
		public abstract int PortraitHeight {
			get;
		}
		public abstract ResourceNode PortraitRootFor(int charNum, int costumeNum);
		public abstract ResourceNode TEX0For(ResourceNode brres, int charNum, int costumeNum);

		protected AdditionalTextureData texture;

		// In case the image needs to be reloaded after replacing the texture
		protected int _charNum, _costumeNum;

		public PortraitViewer() {
			InitializeComponent();
			texture = new AdditionalTextureData(PortraitWidth, PortraitHeight, TEX0For);
			additionalTexturesPanel.Controls.Add(texture.Panel);
			texture.OnUpdate = delegate(AdditionalTextureData sender) {
				UpdateImage(_charNum, _costumeNum);
			};

			_charNum = -1;
			_costumeNum = -1;
		}

		public virtual bool UpdateImage(int charNum, int costumeNum) {
			_charNum = charNum;
			_costumeNum = costumeNum;
			ResourceNode bres = PortraitRootFor(charNum, costumeNum);
			if (bres != null) label1.Text = bres.RootNode.Name;
			texture.TextureFrom(bres, charNum, costumeNum);
			return texture.Texture != null;
		}

		public abstract void UpdateDirectory();

		protected abstract void saveButton_Click(object sender, EventArgs e);
	}
}
