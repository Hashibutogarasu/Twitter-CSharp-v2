using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Twitter_CSharp {
    class CountLabel : Label {
        public int Count { get; set; }

        public CountLabel() {
            this.Count = 0;
        }
    }
}
