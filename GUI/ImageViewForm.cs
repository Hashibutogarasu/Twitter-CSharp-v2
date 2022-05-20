using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Twitter_CSharp {
    public partial class ImageViewForm : Form {
        private string image_url { get; set; }

        public ImageViewForm(string url = null, string labelstatus = "") {
            InitializeComponent();

            if (url != null || url != "" || labelstatus == "ツイート画像") {
                Image image = Utils.LoadImageFromURL(url);
                if (image != null) {
                    this.MinimumSize = image.Size;
                    this.image_url = url;
                    this.PictureUrl.Text = url;
                    PictureView.Image = image;
                }
            }
            else {
                Close();
            }
        }

        private void FormCloseButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void DownloadButton_Click(object sender, EventArgs e) {
            WebClient webClient = new WebClient();
            DownloadDialog.FileName = "";
            DownloadDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            DownloadDialog.Filter = "*.png|*.jpg|*.jpeg|*.gif";
            DownloadDialog.FilterIndex = 2;
            DownloadDialog.Title = "保存先のファイルを選択...";
            DownloadDialog.RestoreDirectory = true;

            //ダイアログを表示する
            if (DownloadDialog.ShowDialog() == DialogResult.OK) {
                try {
                    webClient.DownloadFile(image_url, DownloadDialog.FileName);
                    MessageBox.Show("ファイルを保存しました");
                }
                catch (WebException exc) {
                    MessageBox.Show($"ダウンロードに失敗しました:{exc.Message}");
                }
            }
        }
    }
}
