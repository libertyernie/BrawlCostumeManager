using BrawlLib.SSBB.ResourceNodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BrawlCostumeManager {
	public static class KirbyCopy {
		public static void Copy(string kirbypath, string hatpath) {
			ResourceNode kirby = NodeFactory.FromFile(null, kirbypath);
			string temphat = Path.GetTempFileName();
			File.Copy(hatpath, temphat, true);
			ResourceNode hat = NodeFactory.FromFile(null, temphat);

			TEX0Node skin = (TEX0Node)kirby.FindChildByType("PlyKirby5KSkin", true, ResourceType.TEX0);
			if (skin == null) throw new Exception("Could not find the texture PlyKirby5KSkin in " + kirbypath);

			string temptex = Path.GetTempFileName();
			skin.Export(temptex);

			TEX0Node hatskin = (TEX0Node)hat.FindChildByType("WpnKirbyKirbyMewtwoCap", true, ResourceType.TEX0);
			if (skin == null) throw new Exception("Could not find the texture WpnKirbyKirbyMewtwoCap in " + hatpath);

			hatskin.Replace(temptex);
			hat.Merge();
			hat.Export(hatpath);

			hat.Dispose();
			kirby.Dispose();

			File.Delete(temphat);
			File.Delete(temptex);
		}
	}
}
