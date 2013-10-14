using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace SbBjT.Bussines.ReleaseCore
{
    public class ReleaseLabel :IRelease
    {
        public Label Label { get; set; }
        public void Release()
        {
            Label.BackColor = Color.Red;

        }
    }
}
