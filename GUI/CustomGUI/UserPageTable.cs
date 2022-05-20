using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Twitter_CSharp.GUI.CustomGUI;

namespace Twitter_CSharp {
    class UserPageTable : TableLayoutPanel {

        private TableLayoutPanel InfoTable;
        private TableLayoutPanel IconTable;
        public PictureboxUrl UserIcon { get; set; }
        private TableLayoutPanel DescriptionTable;
        public TextBox ScreenName { get; set; }
        private FlowLayoutPanel ScreenNameFlowLayout;
        public FollowUnfollowButton FollowUnfollowButton { get; set; }
        public AutoSizeTextBox Description { get; set; }
        public PictureboxUrl Header { get; set; }
        public FlowLayoutPanel TimelinePanel { get; set; }

        public UserPageTable(FlowLayoutPanel flowlayoutpanel) {
            this.InfoTable = new TableLayoutPanel();
            this.IconTable = new TableLayoutPanel();
            this.UserIcon = new PictureboxUrl();
            this.DescriptionTable = new TableLayoutPanel();
            this.ScreenName = new TextBox();
            this.ScreenNameFlowLayout = new FlowLayoutPanel();
            this.FollowUnfollowButton = new FollowUnfollowButton();
            this.Description = new AutoSizeTextBox();
            this.Header = new PictureboxUrl();
            this.TimelinePanel = new FlowLayoutPanel();
            this.SuspendLayout();
            this.InfoTable.SuspendLayout();
            this.IconTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).BeginInit();
            this.DescriptionTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).BeginInit();
            this.SuspendLayout();
            // 
            // UserTable
            // 
            //this.AutoScroll = true;
            this.AutoSize = true;
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new ColumnStyle());
            this.Controls.Add(this.InfoTable, 0, 1);
            this.Controls.Add(this.Header, 0, 0);
            this.Controls.Add(this.TimelinePanel, 0, 2);
            this.Dock = DockStyle.Fill;
            this.Location = new Point(0, 0);
            this.Name = "UserTable";
            this.RowCount = 3;
            this.RowStyles.Add(new RowStyle());
            this.RowStyles.Add(new RowStyle());
            this.RowStyles.Add(new RowStyle());
            this.Size = new Size(flowlayoutpanel.Width - 35, 400);
            this.TabIndex = 1;
            // 
            // InfoTable
            // 
            this.InfoTable.ColumnCount = 2;
            this.InfoTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
            this.InfoTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.InfoTable.Controls.Add(this.IconTable, 0, 0);
            this.InfoTable.Controls.Add(this.DescriptionTable, 1, 0);
            this.InfoTable.Dock = DockStyle.Top;
            this.InfoTable.Location = new Point(3, 83);
            this.InfoTable.Name = "InfoTable";
            this.InfoTable.RowCount = 1;
            this.InfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 207F));
            this.InfoTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 207F));
            this.InfoTable.Size = new Size(flowlayoutpanel.Width - 35, 207);
            this.InfoTable.TabIndex = 2;
            // 
            // IconTable
            // 
            this.IconTable.AutoSize = true;
            this.IconTable.ColumnCount = 1;
            this.IconTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.IconTable.Controls.Add(this.UserIcon, 0, 0);
            this.IconTable.Dock = DockStyle.Fill;
            this.IconTable.Location = new Point(3, 3);
            this.IconTable.Name = "IconTable";
            this.IconTable.RowCount = 2;
            this.IconTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            this.IconTable.RowStyles.Add(new RowStyle());
            this.IconTable.Size = new Size(58, 201);
            this.IconTable.TabIndex = 0;
            // 
            // UserIcon
            // 
            this.UserIcon.Dock = DockStyle.Fill;
            this.UserIcon.Location = new Point(3, 3);
            this.UserIcon.Name = "UserIcon";
            this.UserIcon.Size = new Size(52, 58);
            this.UserIcon.TabIndex = 0;
            this.UserIcon.TabStop = false;
            // 
            // DescriptionTable
            // 
            this.DescriptionTable.AutoSize = true;
            this.DescriptionTable.ColumnCount = 1;
            this.DescriptionTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.DescriptionTable.Controls.Add(this.ScreenNameFlowLayout, 0, 0);
            this.DescriptionTable.Controls.Add(this.Description, 0, 1);
            this.DescriptionTable.Dock = DockStyle.Fill;
            this.DescriptionTable.Location = new Point(67, 3);
            this.DescriptionTable.Name = "DescriptionTable";
            this.DescriptionTable.RowCount = 2;
            this.DescriptionTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.DescriptionTable.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            this.DescriptionTable.Size = new Size(608, 201);
            this.DescriptionTable.TabIndex = 1;
            //
            //ScreenNameFlowLayout
            //
            this.ScreenNameFlowLayout.BorderStyle = BorderStyle.None;
            this.ScreenNameFlowLayout.Dock = DockStyle.Fill;
            this.ScreenNameFlowLayout.Location = new Point(3, 3);
            this.ScreenNameFlowLayout.Size = new Size(602, 16);
            this.ScreenNameFlowLayout.Name = "ScreenName";
            this.ScreenNameFlowLayout.Controls.Add(this.ScreenName);
            this.ScreenNameFlowLayout.Controls.Add(this.FollowUnfollowButton);
            // 
            // ScreenName
            // 
            this.ScreenName.BorderStyle = BorderStyle.None;
            this.ScreenName.Dock = DockStyle.Left;
            this.ScreenName.Location = new Point(3, 3);
            this.ScreenName.Name = "ScreenName";
            this.ScreenName.ReadOnly = true;
            this.ScreenName.Size = new Size(flowlayoutpanel.Width - IconTable.Width - 150, 16);
            this.ScreenName.TabIndex = 0;
            //
            //FollowUnfollowButton
            //
            this.FollowUnfollowButton.Name = "FollowUnfollowButton";
            this.FollowUnfollowButton.AutoSize = true;
            this.FollowUnfollowButton.Location = new Point(flowlayoutpanel.Width - IconTable.Width - 160, 0);
            this.FollowUnfollowButton.Text = "フォロー";
            this.FollowUnfollowButton.Visible = false; //
            // 
            // Description
            //
            this.Description.AutoSize = true;
            this.Description.BorderStyle = BorderStyle.None;
            //this.Description.Dock = DockStyle.Fill;
            this.Description.Location = new Point(3, 53);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = flowlayoutpanel.Width - IconTable.Width - 60;
            this.Description.Height = flowlayoutpanel.Height - IconTable.Height;
            this.Description.ScrollBars = ScrollBars.Vertical;
            this.Description.TabIndex = 1;
            // 
            // Header
            // 
            this.Header.Dock = DockStyle.Fill;
            this.Header.Location = new Point(3, 3);
            this.Header.Name = "Header";
            this.Header.Size = new Size(flowlayoutpanel.Width - 35, 74);
            this.Header.TabIndex = 3;
            this.Header.TabStop = false;
            // 
            // TimelinePanel
            // 
            //this.TimelinePanel.AutoScroll = true;
            this.TimelinePanel.AutoSize = true;
            this.TimelinePanel.Dock = DockStyle.Fill;
            this.TimelinePanel.Location = new Point(0, 296);
            this.TimelinePanel.Name = "TimelinePanel";
            //this.TimelinePanel.Size = new Size(flowlayoutpanel.Width - 28, 101);
            this.TimelinePanel.TabIndex = 4;
            // 
            // TestGUI
            // 
            this.Dock = DockStyle.Fill;
            this.Name = "UserView";
            this.Text = "UserView";
            this.ResumeLayout(false);
            this.InfoTable.ResumeLayout(false);
            this.InfoTable.PerformLayout();
            this.IconTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).EndInit();
            this.DescriptionTable.ResumeLayout(false);
            this.DescriptionTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
