using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrawlCostumeManager
{
    public abstract class PortraitViewer : UserControl
    {
        public abstract void UpdateDirectory();

        public abstract bool UpdateImage(int charNum, int costumeNum);
    }
}
