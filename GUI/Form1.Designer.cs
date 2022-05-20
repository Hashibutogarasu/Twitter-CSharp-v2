
namespace Twitter_CSharp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.KeySettingPanel = new System.Windows.Forms.Panel();
            this.OauthButton = new System.Windows.Forms.Button();
            this.AccessTokenSecret = new System.Windows.Forms.TextBox();
            this.AccessToken = new System.Windows.Forms.TextBox();
            this.ApiKeySecret = new System.Windows.Forms.TextBox();
            this.ApiKey = new System.Windows.Forms.TextBox();
            this.MainForm = new System.Windows.Forms.TabControl();
            this.TweetPage = new System.Windows.Forms.TabPage();
            this.ClearReply = new System.Windows.Forms.Button();
            this.ImagesResetButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ImageSelector = new System.Windows.Forms.Button();
            this.TweetButton = new System.Windows.Forms.Button();
            this.TweetTextBox = new Twitter_CSharp.TweetTextBox();
            this.TimeLinePage = new System.Windows.Forms.TabPage();
            this.TimeLinePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NoticePage = new System.Windows.Forms.TabPage();
            this.NoticePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchPage = new System.Windows.Forms.TabPage();
            this.SearchResultLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.UserSearchPage = new System.Windows.Forms.TabPage();
            this.UserSearchResultLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.UserSearchButton = new System.Windows.Forms.Button();
            this.UserSearchBox = new System.Windows.Forms.TextBox();
            this.UserPage = new System.Windows.Forms.TabPage();
            this.UserPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.KeySettingPage = new System.Windows.Forms.TabPage();
            this.LogPage = new System.Windows.Forms.TabPage();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.RateLimitPage = new System.Windows.Forms.TabPage();
            this.TextSearch = new System.Windows.Forms.TextBox();
            this.RateLimitBox = new System.Windows.Forms.TextBox();
            this.ModeTextBox = new System.Windows.Forms.TextBox();
            this.ImageFileSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.FormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ImagePreviewPanel = new System.Windows.Forms.Panel();
            this.PictureFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.PreviewLabel = new Twitter_CSharp.CountLabel();
            this.TweetIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FollowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnFollowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JumpToUserPageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenUrlItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TweetTextContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ReplyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FavItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RetItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaverContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveTweetItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TweetSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.UserReload = new System.Windows.Forms.ToolStripMenuItem();
            this.KeySettingPanel.SuspendLayout();
            this.MainForm.SuspendLayout();
            this.TweetPage.SuspendLayout();
            this.TimeLinePage.SuspendLayout();
            this.NoticePage.SuspendLayout();
            this.SearchPage.SuspendLayout();
            this.UserSearchPage.SuspendLayout();
            this.UserPage.SuspendLayout();
            this.KeySettingPage.SuspendLayout();
            this.LogPage.SuspendLayout();
            this.RateLimitPage.SuspendLayout();
            this.FormLayout.SuspendLayout();
            this.ImagePreviewPanel.SuspendLayout();
            this.TweetIconContextMenuStrip.SuspendLayout();
            this.TweetTextContextMenuStrip.SuspendLayout();
            this.SaverContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeySettingPanel
            // 
            this.KeySettingPanel.Controls.Add(this.OauthButton);
            this.KeySettingPanel.Controls.Add(this.AccessTokenSecret);
            this.KeySettingPanel.Controls.Add(this.AccessToken);
            this.KeySettingPanel.Controls.Add(this.ApiKeySecret);
            this.KeySettingPanel.Controls.Add(this.ApiKey);
            this.KeySettingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeySettingPanel.Location = new System.Drawing.Point(3, 3);
            this.KeySettingPanel.Name = "KeySettingPanel";
            this.KeySettingPanel.Size = new System.Drawing.Size(315, 305);
            this.KeySettingPanel.TabIndex = 1;
            // 
            // OauthButton
            // 
            this.OauthButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OauthButton.Location = new System.Drawing.Point(4, 120);
            this.OauthButton.Name = "OauthButton";
            this.OauthButton.Size = new System.Drawing.Size(298, 23);
            this.OauthButton.TabIndex = 5;
            this.OauthButton.Text = "認証";
            this.OauthButton.UseVisualStyleBackColor = true;
            this.OauthButton.Click += new System.EventHandler(this.OauthButton_Click);
            // 
            // AccessTokenSecret
            // 
            this.AccessTokenSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessTokenSecret.Location = new System.Drawing.Point(4, 90);
            this.AccessTokenSecret.Name = "AccessTokenSecret";
            this.AccessTokenSecret.PlaceholderText = "AccessTokenSecret";
            this.AccessTokenSecret.Size = new System.Drawing.Size(298, 23);
            this.AccessTokenSecret.TabIndex = 4;
            // 
            // AccessToken
            // 
            this.AccessToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccessToken.Location = new System.Drawing.Point(4, 61);
            this.AccessToken.Name = "AccessToken";
            this.AccessToken.PlaceholderText = "AccessToken";
            this.AccessToken.Size = new System.Drawing.Size(298, 23);
            this.AccessToken.TabIndex = 3;
            // 
            // ApiKeySecret
            // 
            this.ApiKeySecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApiKeySecret.Location = new System.Drawing.Point(4, 32);
            this.ApiKeySecret.Name = "ApiKeySecret";
            this.ApiKeySecret.PlaceholderText = "ApiKeySecret";
            this.ApiKeySecret.Size = new System.Drawing.Size(298, 23);
            this.ApiKeySecret.TabIndex = 2;
            // 
            // ApiKey
            // 
            this.ApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApiKey.Location = new System.Drawing.Point(4, 3);
            this.ApiKey.Name = "ApiKey";
            this.ApiKey.PlaceholderText = "ApiKey";
            this.ApiKey.Size = new System.Drawing.Size(298, 23);
            this.ApiKey.TabIndex = 1;
            // 
            // MainForm
            // 
            this.MainForm.Controls.Add(this.TweetPage);
            this.MainForm.Controls.Add(this.TimeLinePage);
            this.MainForm.Controls.Add(this.NoticePage);
            this.MainForm.Controls.Add(this.SearchPage);
            this.MainForm.Controls.Add(this.UserSearchPage);
            this.MainForm.Controls.Add(this.UserPage);
            this.MainForm.Controls.Add(this.KeySettingPage);
            this.MainForm.Controls.Add(this.LogPage);
            this.MainForm.Controls.Add(this.RateLimitPage);
            this.MainForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainForm.Location = new System.Drawing.Point(3, 3);
            this.MainForm.Name = "MainForm";
            this.MainForm.SelectedIndex = 0;
            this.MainForm.Size = new System.Drawing.Size(329, 339);
            this.MainForm.TabIndex = 0;
            this.MainForm.Selected += new System.Windows.Forms.TabControlEventHandler(this.MainFormSelected);
            // 
            // TweetPage
            // 
            this.TweetPage.Controls.Add(this.ClearReply);
            this.TweetPage.Controls.Add(this.ImagesResetButton);
            this.TweetPage.Controls.Add(this.ClearButton);
            this.TweetPage.Controls.Add(this.ImageSelector);
            this.TweetPage.Controls.Add(this.TweetButton);
            this.TweetPage.Controls.Add(this.TweetTextBox);
            this.TweetPage.Location = new System.Drawing.Point(4, 24);
            this.TweetPage.Name = "TweetPage";
            this.TweetPage.Size = new System.Drawing.Size(321, 311);
            this.TweetPage.TabIndex = 4;
            this.TweetPage.Text = "ツイート";
            this.TweetPage.UseVisualStyleBackColor = true;
            // 
            // ClearReply
            // 
            this.ClearReply.Location = new System.Drawing.Point(219, 285);
            this.ClearReply.Name = "ClearReply";
            this.ClearReply.Size = new System.Drawing.Size(99, 23);
            this.ClearReply.TabIndex = 5;
            this.ClearReply.Text = "返信をキャンセル";
            this.ClearReply.UseVisualStyleBackColor = true;
            this.ClearReply.Click += new System.EventHandler(this.ClearReply_Click);
            // 
            // ImagesResetButton
            // 
            this.ImagesResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImagesResetButton.Location = new System.Drawing.Point(113, 256);
            this.ImagesResetButton.Name = "ImagesResetButton";
            this.ImagesResetButton.Size = new System.Drawing.Size(100, 23);
            this.ImagesResetButton.TabIndex = 2;
            this.ImagesResetButton.Text = "画像をクリア";
            this.ImagesResetButton.UseVisualStyleBackColor = true;
            this.ImagesResetButton.Click += new System.EventHandler(this.ImagesResetButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearButton.Location = new System.Drawing.Point(219, 256);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(99, 23);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "リセット";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ImageSelector
            // 
            this.ImageSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ImageSelector.Location = new System.Drawing.Point(3, 256);
            this.ImageSelector.Name = "ImageSelector";
            this.ImageSelector.Size = new System.Drawing.Size(104, 23);
            this.ImageSelector.TabIndex = 1;
            this.ImageSelector.Text = "画像を選択";
            this.ImageSelector.UseVisualStyleBackColor = true;
            this.ImageSelector.Click += new System.EventHandler(this.SelectImage);
            // 
            // TweetButton
            // 
            this.TweetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TweetButton.Enabled = false;
            this.TweetButton.Location = new System.Drawing.Point(3, 285);
            this.TweetButton.Name = "TweetButton";
            this.TweetButton.Size = new System.Drawing.Size(210, 23);
            this.TweetButton.TabIndex = 4;
            this.TweetButton.Text = "ツイート";
            this.TweetButton.UseVisualStyleBackColor = true;
            this.TweetButton.Click += new System.EventHandler(this.TweetButton_Click);
            // 
            // TweetTextBox
            // 
            this.TweetTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TweetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TweetTextBox.Isreplying = false;
            this.TweetTextBox.Location = new System.Drawing.Point(0, 0);
            this.TweetTextBox.Multiline = true;
            this.TweetTextBox.Name = "TweetTextBox";
            this.TweetTextBox.PlaceholderText = "ツイートするテキストをここに入力...";
            this.TweetTextBox.Reply_tweet_id = ((long)(0));
            this.TweetTextBox.Size = new System.Drawing.Size(321, 250);
            this.TweetTextBox.TabIndex = 0;
            this.TweetTextBox.TextChanged += new System.EventHandler(this.TweetTextChanged);
            // 
            // TimeLinePage
            // 
            this.TimeLinePage.Controls.Add(this.TimeLinePanel);
            this.TimeLinePage.Location = new System.Drawing.Point(4, 24);
            this.TimeLinePage.Name = "TimeLinePage";
            this.TimeLinePage.Padding = new System.Windows.Forms.Padding(3);
            this.TimeLinePage.Size = new System.Drawing.Size(321, 311);
            this.TimeLinePage.TabIndex = 0;
            this.TimeLinePage.Text = "ホーム";
            this.TimeLinePage.UseVisualStyleBackColor = true;
            // 
            // TimeLinePanel
            // 
            this.TimeLinePanel.AutoScroll = true;
            this.TimeLinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeLinePanel.Location = new System.Drawing.Point(3, 3);
            this.TimeLinePanel.Name = "TimeLinePanel";
            this.TimeLinePanel.Size = new System.Drawing.Size(315, 305);
            this.TimeLinePanel.TabIndex = 0;
            // 
            // NoticePage
            // 
            this.NoticePage.Controls.Add(this.NoticePanel);
            this.NoticePage.Location = new System.Drawing.Point(4, 24);
            this.NoticePage.Name = "NoticePage";
            this.NoticePage.Padding = new System.Windows.Forms.Padding(3);
            this.NoticePage.Size = new System.Drawing.Size(321, 311);
            this.NoticePage.TabIndex = 1;
            this.NoticePage.Text = "通知";
            this.NoticePage.UseVisualStyleBackColor = true;
            // 
            // NoticePanel
            // 
            this.NoticePanel.AutoScroll = true;
            this.NoticePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoticePanel.Location = new System.Drawing.Point(3, 3);
            this.NoticePanel.Name = "NoticePanel";
            this.NoticePanel.Size = new System.Drawing.Size(315, 305);
            this.NoticePanel.TabIndex = 0;
            // 
            // SearchPage
            // 
            this.SearchPage.Controls.Add(this.SearchResultLayout);
            this.SearchPage.Controls.Add(this.SearchButton);
            this.SearchPage.Controls.Add(this.SearchTextBox);
            this.SearchPage.Location = new System.Drawing.Point(4, 24);
            this.SearchPage.Name = "SearchPage";
            this.SearchPage.Padding = new System.Windows.Forms.Padding(3);
            this.SearchPage.Size = new System.Drawing.Size(321, 311);
            this.SearchPage.TabIndex = 5;
            this.SearchPage.Text = "検索";
            this.SearchPage.UseVisualStyleBackColor = true;
            // 
            // SearchResultLayout
            // 
            this.SearchResultLayout.AutoScroll = true;
            this.SearchResultLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SearchResultLayout.Location = new System.Drawing.Point(3, 36);
            this.SearchResultLayout.Name = "SearchResultLayout";
            this.SearchResultLayout.Size = new System.Drawing.Size(315, 272);
            this.SearchResultLayout.TabIndex = 2;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(234, 7);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(81, 23);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "検索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(7, 7);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(221, 23);
            this.SearchTextBox.TabIndex = 0;
            // 
            // UserSearchPage
            // 
            this.UserSearchPage.Controls.Add(this.UserSearchResultLayout);
            this.UserSearchPage.Controls.Add(this.UserSearchButton);
            this.UserSearchPage.Controls.Add(this.UserSearchBox);
            this.UserSearchPage.Location = new System.Drawing.Point(4, 24);
            this.UserSearchPage.Name = "UserSearchPage";
            this.UserSearchPage.Size = new System.Drawing.Size(321, 311);
            this.UserSearchPage.TabIndex = 6;
            this.UserSearchPage.Text = "ユーザー検索";
            this.UserSearchPage.UseVisualStyleBackColor = true;
            // 
            // UserSearchResultLayout
            // 
            this.UserSearchResultLayout.AutoScroll = true;
            this.UserSearchResultLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserSearchResultLayout.Location = new System.Drawing.Point(0, 36);
            this.UserSearchResultLayout.Name = "UserSearchResultLayout";
            this.UserSearchResultLayout.Size = new System.Drawing.Size(321, 275);
            this.UserSearchResultLayout.TabIndex = 2;
            // 
            // UserSearchButton
            // 
            this.UserSearchButton.Location = new System.Drawing.Point(234, 7);
            this.UserSearchButton.Name = "UserSearchButton";
            this.UserSearchButton.Size = new System.Drawing.Size(81, 23);
            this.UserSearchButton.TabIndex = 1;
            this.UserSearchButton.Text = "検索";
            this.UserSearchButton.UseVisualStyleBackColor = true;
            this.UserSearchButton.Click += new System.EventHandler(this.UserSearchButton_Click);
            // 
            // UserSearchBox
            // 
            this.UserSearchBox.Location = new System.Drawing.Point(7, 7);
            this.UserSearchBox.Name = "UserSearchBox";
            this.UserSearchBox.Size = new System.Drawing.Size(221, 23);
            this.UserSearchBox.TabIndex = 0;
            // 
            // UserPage
            // 
            this.UserPage.Controls.Add(this.UserPanel);
            this.UserPage.Location = new System.Drawing.Point(4, 24);
            this.UserPage.Name = "UserPage";
            this.UserPage.Size = new System.Drawing.Size(321, 311);
            this.UserPage.TabIndex = 7;
            this.UserPage.Text = "ユーザーページ";
            this.UserPage.UseVisualStyleBackColor = true;
            // 
            // UserPanel
            // 
            this.UserPanel.AutoScroll = true;
            this.UserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPanel.Location = new System.Drawing.Point(0, 0);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(321, 311);
            this.UserPanel.TabIndex = 0;
            // 
            // KeySettingPage
            // 
            this.KeySettingPage.Controls.Add(this.KeySettingPanel);
            this.KeySettingPage.Location = new System.Drawing.Point(4, 24);
            this.KeySettingPage.Name = "KeySettingPage";
            this.KeySettingPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeySettingPage.Size = new System.Drawing.Size(321, 311);
            this.KeySettingPage.TabIndex = 2;
            this.KeySettingPage.Text = "キー設定";
            this.KeySettingPage.UseVisualStyleBackColor = true;
            // 
            // LogPage
            // 
            this.LogPage.Controls.Add(this.LogBox);
            this.LogPage.Location = new System.Drawing.Point(4, 24);
            this.LogPage.Name = "LogPage";
            this.LogPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogPage.Size = new System.Drawing.Size(321, 311);
            this.LogPage.TabIndex = 3;
            this.LogPage.Text = "ログ";
            this.LogPage.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.SystemColors.Control;
            this.LogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox.Location = new System.Drawing.Point(3, 3);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(315, 305);
            this.LogBox.TabIndex = 0;
            // 
            // RateLimitPage
            // 
            this.RateLimitPage.BackColor = System.Drawing.SystemColors.Control;
            this.RateLimitPage.Controls.Add(this.TextSearch);
            this.RateLimitPage.Controls.Add(this.RateLimitBox);
            this.RateLimitPage.Location = new System.Drawing.Point(4, 24);
            this.RateLimitPage.Name = "RateLimitPage";
            this.RateLimitPage.Padding = new System.Windows.Forms.Padding(3);
            this.RateLimitPage.Size = new System.Drawing.Size(321, 311);
            this.RateLimitPage.TabIndex = 8;
            this.RateLimitPage.Text = "制限";
            // 
            // TextSearch
            // 
            this.TextSearch.Location = new System.Drawing.Point(6, 6);
            this.TextSearch.Name = "TextSearch";
            this.TextSearch.Size = new System.Drawing.Size(309, 23);
            this.TextSearch.TabIndex = 1;
            // 
            // RateLimitBox
            // 
            this.RateLimitBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RateLimitBox.Location = new System.Drawing.Point(3, 35);
            this.RateLimitBox.Multiline = true;
            this.RateLimitBox.Name = "RateLimitBox";
            this.RateLimitBox.ReadOnly = true;
            this.RateLimitBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RateLimitBox.Size = new System.Drawing.Size(315, 273);
            this.RateLimitBox.TabIndex = 2;
            // 
            // ModeTextBox
            // 
            this.ModeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModeTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ModeTextBox.Location = new System.Drawing.Point(0, 345);
            this.ModeTextBox.Multiline = true;
            this.ModeTextBox.Name = "ModeTextBox";
            this.ModeTextBox.ReadOnly = true;
            this.ModeTextBox.Size = new System.Drawing.Size(684, 55);
            this.ModeTextBox.TabIndex = 0;
            // 
            // FormLayout
            // 
            this.FormLayout.ColumnCount = 2;
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.FormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormLayout.Controls.Add(this.MainForm, 0, 0);
            this.FormLayout.Controls.Add(this.ImagePreviewPanel, 1, 0);
            this.FormLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormLayout.Location = new System.Drawing.Point(0, 0);
            this.FormLayout.Name = "FormLayout";
            this.FormLayout.RowCount = 1;
            this.FormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormLayout.Size = new System.Drawing.Size(684, 345);
            this.FormLayout.TabIndex = 1;
            // 
            // ImagePreviewPanel
            // 
            this.ImagePreviewPanel.Controls.Add(this.PictureFlowLayout);
            this.ImagePreviewPanel.Controls.Add(this.PreviewLabel);
            this.ImagePreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePreviewPanel.Location = new System.Drawing.Point(343, 3);
            this.ImagePreviewPanel.Name = "ImagePreviewPanel";
            this.ImagePreviewPanel.Size = new System.Drawing.Size(338, 339);
            this.ImagePreviewPanel.TabIndex = 1;
            // 
            // PictureFlowLayout
            // 
            this.PictureFlowLayout.AutoScroll = true;
            this.PictureFlowLayout.Location = new System.Drawing.Point(4, 24);
            this.PictureFlowLayout.Name = "PictureFlowLayout";
            this.PictureFlowLayout.Size = new System.Drawing.Size(325, 308);
            this.PictureFlowLayout.TabIndex = 5;
            // 
            // PreviewLabel
            // 
            this.PreviewLabel.AutoSize = true;
            this.PreviewLabel.Count = 0;
            this.PreviewLabel.Location = new System.Drawing.Point(3, 6);
            this.PreviewLabel.Name = "PreviewLabel";
            this.PreviewLabel.Size = new System.Drawing.Size(72, 15);
            this.PreviewLabel.TabIndex = 0;
            this.PreviewLabel.Text = "選択した画像";
            this.PreviewLabel.TextChanged += new System.EventHandler(this.PreviewLabelChanged);
            // 
            // TweetIconContextMenuStrip
            // 
            this.TweetIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FollowItem,
            this.UnFollowItem,
            this.JumpToUserPageItem});
            this.TweetIconContextMenuStrip.Name = "TweetIconContextMenuStrip";
            this.TweetIconContextMenuStrip.ShowImageMargin = false;
            this.TweetIconContextMenuStrip.Size = new System.Drawing.Size(148, 70);
            // 
            // FollowItem
            // 
            this.FollowItem.Name = "FollowItem";
            this.FollowItem.Size = new System.Drawing.Size(147, 22);
            this.FollowItem.Text = "フォロー";
            this.FollowItem.Click += new System.EventHandler(this.FavRetClick);
            // 
            // UnFollowItem
            // 
            this.UnFollowItem.Name = "UnFollowItem";
            this.UnFollowItem.Size = new System.Drawing.Size(147, 22);
            this.UnFollowItem.Text = "フォロー解除";
            this.UnFollowItem.Click += new System.EventHandler(this.FavRetClick);
            // 
            // JumpToUserPageItem
            // 
            this.JumpToUserPageItem.Name = "JumpToUserPageItem";
            this.JumpToUserPageItem.Size = new System.Drawing.Size(147, 22);
            this.JumpToUserPageItem.Text = "ユーザーページへ移動";
            this.JumpToUserPageItem.Click += new System.EventHandler(this.JumpToUserPage);
            // 
            // ReloadItem
            // 
            this.ReloadItem.Name = "ReloadItem";
            this.ReloadItem.Size = new System.Drawing.Size(113, 22);
            this.ReloadItem.Text = "更新";
            this.ReloadItem.Click += new System.EventHandler(this.ReloadItem_Click);
            // 
            // OpenUrlItem
            // 
            this.OpenUrlItem.Name = "OpenUrlItem";
            this.OpenUrlItem.Size = new System.Drawing.Size(113, 22);
            this.OpenUrlItem.Text = "Twitterで開く";
            this.OpenUrlItem.Click += new System.EventHandler(this.OpenTweetUrl);
            // 
            // TweetTextContextMenuStrip
            // 
            this.TweetTextContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReplyItem,
            this.ReloadItem,
            this.FavItem,
            this.RetItem,
            this.OpenUrlItem});
            this.TweetTextContextMenuStrip.Name = "TweetTextContextMenuStrip";
            this.TweetTextContextMenuStrip.ShowImageMargin = false;
            this.TweetTextContextMenuStrip.Size = new System.Drawing.Size(114, 114);
            // 
            // ReplyItem
            // 
            this.ReplyItem.Name = "ReplyItem";
            this.ReplyItem.Size = new System.Drawing.Size(113, 22);
            this.ReplyItem.Text = "返信";
            this.ReplyItem.Click += new System.EventHandler(this.ReplyClick);
            // 
            // FavItem
            // 
            this.FavItem.Name = "FavItem";
            this.FavItem.Size = new System.Drawing.Size(113, 22);
            this.FavItem.Text = "いいね";
            this.FavItem.Click += new System.EventHandler(this.FavRetClick);
            // 
            // RetItem
            // 
            this.RetItem.Name = "RetItem";
            this.RetItem.Size = new System.Drawing.Size(113, 22);
            this.RetItem.Text = "リツイート";
            this.RetItem.Click += new System.EventHandler(this.FavRetClick);
            // 
            // SaverContextMenu
            // 
            this.SaverContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveTweetItem,
            this.UserReload});
            this.SaverContextMenu.Name = "contextMenuStrip1";
            this.SaverContextMenu.ShowImageMargin = false;
            this.SaverContextMenu.Size = new System.Drawing.Size(156, 70);
            // 
            // SaveTweetItem
            // 
            this.SaveTweetItem.Name = "SaveTweetItem";
            this.SaveTweetItem.Size = new System.Drawing.Size(155, 22);
            this.SaveTweetItem.Text = "ツイートを保存";
            // 
            // UserReload
            // 
            this.UserReload.Name = "UserReload";
            this.UserReload.Size = new System.Drawing.Size(155, 22);
            this.UserReload.Text = "更新";
            this.UserReload.Click += new System.EventHandler(this.ReloadItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 400);
            this.Controls.Add(this.ModeTextBox);
            this.Controls.Add(this.FormLayout);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 439);
            this.MinimumSize = new System.Drawing.Size(356, 439);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Twitter C#";
            this.KeySettingPanel.ResumeLayout(false);
            this.KeySettingPanel.PerformLayout();
            this.MainForm.ResumeLayout(false);
            this.TweetPage.ResumeLayout(false);
            this.TweetPage.PerformLayout();
            this.TimeLinePage.ResumeLayout(false);
            this.NoticePage.ResumeLayout(false);
            this.SearchPage.ResumeLayout(false);
            this.SearchPage.PerformLayout();
            this.UserSearchPage.ResumeLayout(false);
            this.UserSearchPage.PerformLayout();
            this.UserPage.ResumeLayout(false);
            this.KeySettingPage.ResumeLayout(false);
            this.LogPage.ResumeLayout(false);
            this.LogPage.PerformLayout();
            this.RateLimitPage.ResumeLayout(false);
            this.RateLimitPage.PerformLayout();
            this.FormLayout.ResumeLayout(false);
            this.ImagePreviewPanel.ResumeLayout(false);
            this.ImagePreviewPanel.PerformLayout();
            this.TweetIconContextMenuStrip.ResumeLayout(false);
            this.TweetTextContextMenuStrip.ResumeLayout(false);
            this.SaverContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel KeySettingPanel;
        private System.Windows.Forms.Button OauthButton;
        private System.Windows.Forms.TextBox AccessTokenSecret;
        private System.Windows.Forms.TextBox AccessToken;
        private System.Windows.Forms.TextBox ApiKeySecret;
        private System.Windows.Forms.TextBox ApiKey;
        private System.Windows.Forms.TabPage TimeLinePage;
        private System.Windows.Forms.TabPage NoticePage;
        private System.Windows.Forms.TabPage KeySettingPage;
        private System.Windows.Forms.TabPage LogPage;
        private System.Windows.Forms.FlowLayoutPanel TimeLinePanel;
        private System.Windows.Forms.FlowLayoutPanel NoticePanel;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.TabPage TweetPage;
        private System.Windows.Forms.Button TweetButton;
        private TweetTextBox TweetTextBox;
        private System.Windows.Forms.Button ImageSelector;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.OpenFileDialog ImageFileSelectDialog;
        private System.Windows.Forms.Button ImagesResetButton;
        private System.Windows.Forms.TextBox ModeTextBox;
        private System.Windows.Forms.ToolStripMenuItem ReloadItem;
        private System.Windows.Forms.TableLayoutPanel FormLayout;
        private System.Windows.Forms.Panel ImagePreviewPanel;
        private CountLabel PreviewLabel;
        private System.Windows.Forms.ToolStripMenuItem FavItem;
        private System.Windows.Forms.ToolStripMenuItem RetItem;
        private System.Windows.Forms.ToolStripMenuItem FollowItem;
        private System.Windows.Forms.ToolStripMenuItem UnFollowItem;
        private System.Windows.Forms.ToolStripMenuItem ReplyItem;
        private System.Windows.Forms.ToolStripMenuItem OpenUrlItem;
        private System.Windows.Forms.ContextMenuStrip TweetIconContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip TweetTextContextMenuStrip;
        private System.Windows.Forms.Button ClearReply;
        private System.Windows.Forms.FlowLayoutPanel PictureFlowLayout;
        private System.Windows.Forms.TabPage SearchPage;
        private System.Windows.Forms.TabPage UserSearchPage;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.FlowLayoutPanel SearchResultLayout;
        private System.Windows.Forms.TextBox UserSearchBox;
        private System.Windows.Forms.Button UserSearchButton;
        private System.Windows.Forms.FlowLayoutPanel UserSearchResultLayout;
        private System.Windows.Forms.ToolStripMenuItem JumpToUserPageItem;
        private System.Windows.Forms.TabPage UserPage;
        private System.Windows.Forms.FlowLayoutPanel UserPanel;
        public System.Windows.Forms.TabControl MainForm;
        private System.Windows.Forms.TabPage RateLimitPage;
        private System.Windows.Forms.TextBox RateLimitBox;
        private System.Windows.Forms.TextBox TextSearch;
        private System.Windows.Forms.ContextMenuStrip SaverContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveTweetItem;
        private System.Windows.Forms.SaveFileDialog TweetSaveDialog;
        private System.Windows.Forms.ToolStripMenuItem UserReload;
    }
}

