using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Twitter_CSharp {
    class TweetTextBox : TextBox {
        public long Reply_tweet_id { get; set; }
        public bool Isreplying { get; set; }

        public TweetTextBox() {
            this.Reply_tweet_id = 0;
            this.Isreplying = false;
        }
    }
}
