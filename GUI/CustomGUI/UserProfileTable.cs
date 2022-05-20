using CoreTweet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Twitter_CSharp.GUI.CustomGUI;

namespace Twitter_CSharp {
    class UserProfileTable : TableLayoutPanel {
        public PictureboxUrl UserIcon { get; set; }
        public FlowLayoutPanel StatusButtons { get; set; }
        public TextBox UserScreenNameBox { get; set; }
        public TextBox UserDescriptionBox { get; set; }
        public PictureBox Reply_image { get; set; }
        public FavoritePictureBox Favorite_image { get; set; }
        public RetweetPictureBox Retweet_image { get; set; }
        public ReplyCountBox ReplyCount { get; set; }
        public FavoriteCountBox FavoriteCount { get; set; }
        public RetweetCountBox RetweetCount { get; set; }
        private TableLayoutPanel UserDescriptionsTable { get; set; }

        public UserProfileTable() {
            Panel UserProfilePanel = new Panel();
            UserIcon = new PictureboxUrl();
            FlowLayoutPanel UserInfoLayout = new FlowLayoutPanel();
            UserDescriptionsTable = new TableLayoutPanel();
            UserScreenNameBox = new TextBox();
            UserDescriptionBox = new TextBox();
            ReplyCount = new ReplyCountBox();
            FavoriteCount = new FavoriteCountBox();
            RetweetCount = new RetweetCountBox();

            this.ColumnCount = 2;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.Controls.Add(UserProfilePanel, 1, 0);
            this.Controls.Add(UserIcon, 0, 0);
            this.Dock = DockStyle.Top;
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "UserProfileTable";
            this.RowCount = 1;
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.Size = new Size(280, 170);
            this.TabIndex = 0;
            // 
            // UserProfilePanel
            // 
            UserProfilePanel.Controls.Add(UserDescriptionsTable);
            UserProfilePanel.Dock = DockStyle.Fill;
            UserProfilePanel.Location = new System.Drawing.Point(67, 3);
            UserProfilePanel.Name = "UserProfilePanel";
            UserProfilePanel.TabIndex = 0;
            // 
            // UserDescriptionsTable
            // 
            UserDescriptionsTable.ColumnCount = 1;
            UserDescriptionsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            UserDescriptionsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            UserDescriptionsTable.Controls.Add(UserInfoLayout, 0, 0);
            UserDescriptionsTable.Dock = DockStyle.Fill;
            UserDescriptionsTable.Location = new System.Drawing.Point(0, 0);
            UserDescriptionsTable.Name = "UserDescriptionsTable";
            UserDescriptionsTable.RowCount = 2;
            UserDescriptionsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            UserDescriptionsTable.Size = new System.Drawing.Size(240, 100);
            UserDescriptionsTable.TabIndex = 0;
            // 
            // UserIcon
            // 
            UserIcon.Dock = DockStyle.Top;
            UserIcon.Location = new System.Drawing.Point(3, 3);
            UserIcon.Name = "UserIcon";
            UserIcon.Size = new System.Drawing.Size(64, 64);
            UserIcon.TabIndex = 1;
            UserIcon.TabStop = false;
            ((System.ComponentModel.ISupportInitialize)(UserIcon)).EndInit();
            //
            //UserInfoLayout
            //
            UserInfoLayout.Dock = DockStyle.Fill;
            UserInfoLayout.Controls.Add(UserScreenNameBox);
            UserInfoLayout.Controls.Add(UserDescriptionBox);
            // 
            // UserScreenNameBox
            // 
            UserScreenNameBox.Dock = DockStyle.Top;
            UserScreenNameBox.Location = new Point(0, 0);
            UserScreenNameBox.Name = "UserScreenNameBox";
            UserScreenNameBox.ReadOnly = true;
            UserScreenNameBox.Width = UserInfoLayout.Width - 20;
            UserScreenNameBox.TabIndex = 0;
            // 
            // UserDescriptionBox
            //
            UserDescriptionBox.Dock = DockStyle.Top;
            UserDescriptionBox.Name = "UserDescriptionBox";
            UserDescriptionBox.ReadOnly = true;
            UserDescriptionBox.Multiline = true;
            UserDescriptionBox.ScrollBars = ScrollBars.None;
            UserDescriptionBox.Width = UserInfoLayout.Width - 20;
            UserDescriptionBox.Height = UserInfoLayout.Height - 50;
            UserDescriptionBox.TabIndex = 1;
            //
            //FavoriteCount
            //
            FavoriteCount.BorderStyle = BorderStyle.None;
            FavoriteCount.Name = "FavoriteCount";
            FavoriteCount.AutoSize = true;
            FavoriteCount.Size = new Size(20, 24);
            FavoriteCount.Font = new Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FavoriteCount.Text = "0";
            //
            //RetweetCount
            //
            RetweetCount.BorderStyle = BorderStyle.None;
            RetweetCount.Name = "FavoriteCount";
            RetweetCount.AutoSize = true;
            RetweetCount.Size = new Size(20, 24);
            RetweetCount.Font = new Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            RetweetCount.Text = "0";
            //
            //ReplyCount
            //
            ReplyCount.BorderStyle = BorderStyle.None;
            ReplyCount.Name = "FavoriteCount";
            ReplyCount.AutoSize = true;
            ReplyCount.Size = new Size(20, 24);
            ReplyCount.Font = new Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ReplyCount.Text = "0";
        }

        public void BuildActionStatus(Status status) {
            UserDescriptionsTable.ColumnCount = 3;
            UserDescriptionsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            StatusButtons = new FlowLayoutPanel();
            StatusButtons.Dock = DockStyle.Top;
            StatusButtons.AutoSize = true;
            StatusButtons.AutoScroll = true;

            Reply_image = new PictureBox();
            Reply_image.Size = new Size(24, 24);
            Reply_image.Image = Properties.Resources.reply_image;

            Favorite_image = new FavoritePictureBox();
            Favorite_image.Size = new Size(24, 24);

            if ((bool)status.IsFavorited) {
                Favorite_image.Image = Properties.Resources.favorirte_true_image;
                Favorite_image.IsFavorited = true;

            }
            else {
                Favorite_image.Image = Properties.Resources.favorite_false_image;
                Favorite_image.IsFavorited = false;
            }

            Retweet_image = new RetweetPictureBox();
            Retweet_image.Size = new Size(24, 24);

            if ((bool)status.IsRetweeted) {
                Retweet_image.Image = Properties.Resources.retweet_true_image;
            }
            else {
                Retweet_image.Image = Properties.Resources.retweet_false_image;
            }

            FavoriteCount.Text = status.FavoriteCount.ToString();
            RetweetCount.Text = status.RetweetCount.ToString();

            StatusButtons.Controls.Add(Reply_image);
            
            StatusButtons.Controls.Add(Favorite_image);
            StatusButtons.Controls.Add(FavoriteCount);

            StatusButtons.Controls.Add(Retweet_image);
            StatusButtons.Controls.Add(RetweetCount);

            UserDescriptionsTable.Controls.Add(StatusButtons, 0, 1);
        }
    }
}
