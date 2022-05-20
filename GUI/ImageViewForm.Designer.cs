
namespace Twitter_CSharp
{
    partial class ImageViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureView = new System.Windows.Forms.PictureBox();
            this.FormCloseButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.DownloadDialog = new System.Windows.Forms.SaveFileDialog();
            this.PictureUrl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureView)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureView
            // 
            this.PictureView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureView.Location = new System.Drawing.Point(13, 13);
            this.PictureView.Name = "PictureView";
            this.PictureView.Size = new System.Drawing.Size(501, 305);
            this.PictureView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureView.TabIndex = 0;
            this.PictureView.TabStop = false;
            // 
            // FormCloseButton
            // 
            this.FormCloseButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FormCloseButton.Location = new System.Drawing.Point(0, 370);
            this.FormCloseButton.Name = "FormCloseButton";
            this.FormCloseButton.Size = new System.Drawing.Size(526, 23);
            this.FormCloseButton.TabIndex = 2;
            this.FormCloseButton.Text = "閉じる";
            this.FormCloseButton.UseVisualStyleBackColor = true;
            this.FormCloseButton.Click += new System.EventHandler(this.FormCloseButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DownloadButton.Location = new System.Drawing.Point(0, 347);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(526, 23);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "ダウンロード";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // PictureUrl
            // 
            this.PictureUrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PictureUrl.Location = new System.Drawing.Point(0, 324);
            this.PictureUrl.Name = "PictureUrl";
            this.PictureUrl.ReadOnly = true;
            this.PictureUrl.Size = new System.Drawing.Size(526, 23);
            this.PictureUrl.TabIndex = 0;
            // 
            // ImageViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.FormCloseButton;
            this.ClientSize = new System.Drawing.Size(526, 393);
            this.Controls.Add(this.PictureUrl);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.FormCloseButton);
            this.Controls.Add(this.PictureView);
            this.Name = "ImageViewForm";
            this.ShowIcon = false;
            this.Text = "画像";
            ((System.ComponentModel.ISupportInitialize)(this.PictureView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureView;
        private System.Windows.Forms.Button FormCloseButton;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.SaveFileDialog DownloadDialog;
        private System.Windows.Forms.TextBox PictureUrl;
    }
}