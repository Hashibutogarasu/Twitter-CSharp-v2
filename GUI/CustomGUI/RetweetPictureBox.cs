using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Twitter_CSharp {
    class RetweetPictureBox : PictureBox {
        public bool IsRetweeted { get; set; }
        public long LastRetweetedId { get; set; }
    }
}
