using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Twitter_CSharp {
    class PictureboxUrl : PictureBox {
        public string Url { get; set; }

        public PictureboxUrl() {
            Url = "";
        }
    }
}
