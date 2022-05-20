using CoreTweet;
using CoreTweet.Core;
using CoreTweet.Streaming;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twitter_CSharp.GUI.CustomGUI;
using Twitter_CSharp.Properties;

namespace Twitter_CSharp {
    public partial class Form1 : Form {
        private Settings settings = Settings.Default;
        private Tokens tokens;
        private string ScreenName;
        private string OldTitle;
        private List<string> imagefiles = new List<string> { };
        private long ClickedTweetId;
        private long ClickedUserId;
        private string ClickedUserScreenName;
        private User ClickedUser;
        private ImageViewForm imageViewForm;
        private bool TimelinePageAlreadyLoaded = false;
        private bool NoticePageAlreadyLoaded = false;
        private bool IsPortableMode = false;
        private string inifilepath = Directory.GetCurrentDirectory() + "\\Data\\configs.ini";
        private string noimages = "表示可能な画像はありませんでした";
        private string selectedimage = "選択した画像";
        private IniSettings iniSettings = new IniSettings();
        private string dateformat_jpn = "yyyy年 MM月 dd日 HH時 mm分 ss秒";
        private string dateformat = "yyyy-MM-dd-HH-mm-ss";
        private User LastShowedUser;

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        public Form1() {
            InitializeComponent();
            
            OldTitle = this.Text;
            TweetPage.BackColor = this.BackColor;
            TimeLinePage.BackColor = this.BackColor;
            NoticePage.BackColor = this.BackColor;
            SearchPage.BackColor = this.BackColor;
            SearchResultLayout.BackColor = this.BackColor;
            UserSearchPage.BackColor = this.BackColor;
            UserSearchResultLayout.BackColor = this.BackColor;
            UserPage.BackColor = this.BackColor;
            KeySettingPage.BackColor = this.BackColor;
            KeySettingPanel.BackColor = this.BackColor;
            LogPage.BackColor = this.BackColor;
            LogBox.BackColor = this.BackColor;

            Icon = Resources.icon;

            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\Data\\") && File.Exists(inifilepath)) {
                IsPortableMode = true;
            }
            else {
                IsPortableMode = false;
            }

            if (IsPortableMode) {
                iniSettings = new IniSettings().LoadSettings();

                string apikey = iniSettings.ApiKey;
                string apikeysecret = iniSettings.ApiKeySecret;
                string accesstoken = iniSettings.AccessToken;
                string accesstokensecret = iniSettings.AccessTokenSecret;

                if (apikey != "" || apikeysecret != "" || accesstoken != "" || accesstokensecret != "") {
                    ApiKey.Text = apikey;
                    ApiKeySecret.Text = apikeysecret;
                    AccessToken.Text = accesstoken;
                    AccessTokenSecret.Text = accesstokensecret;

                    try {
                        tokens = Tokens.Create(
                        $"{apikey}",
                        $"{apikeysecret}",
                        $"{accesstoken}",
                        $"{accesstokensecret}");

                        UpdateTitle();
                        LogBox.Text += $"読み込み完了。{Environment.NewLine}";
                    }
                    catch (Exception e) {
                        LogBox.Text += $"読み込みエラー:{e}{Environment.NewLine}";
                    }
                }
                else {
                    MessageBox.Show("キーを空白にはできません", "Twitter CSharp");
                }
            }
            else {
                if (settings != null) {
                    ApiKey.Text = settings.ApiKey;
                    ApiKeySecret.Text = settings.ApiKeySecret;
                    AccessToken.Text = settings.AccessToken;
                    AccessTokenSecret.Text = settings.AccessTokenSecret;
                }

                try {
                    tokens = Tokens.Create(
                    $"{settings.ApiKey}",
                    $"{settings.ApiKeySecret}",
                    $"{settings.AccessToken}",
                    $"{settings.AccessTokenSecret}");

                    UpdateTitle();
                    LogBox.Text += $"読み込み完了。{Environment.NewLine}";
                }
                catch (Exception e) {
                    LogBox.Text += $"読み込みエラー:{e}{Environment.NewLine}";
                }
            }
        }

        private async Task BuildList(ListedResponse<Status> statuses, FlowLayoutPanel timeLinePanel) {
            this.Invoke((Action)(() => {
                try {
                    Status[] timeline_array = statuses.ToArray();

                    foreach (Status tl in timeline_array) {
                        UserProfileTable tableLayout = new UserProfileTable();
                        tableLayout.MouseHover += (s, e) => FormUIUpdate(s, e, tl);
                        tableLayout.UserIcon.MouseHover += (s, e) => FormUIUpdate(s, e, tl);
                        tableLayout.UserScreenNameBox.MouseHover += (s, e) => FormUIUpdate(s, e, tl);
                        tableLayout.UserDescriptionBox.MouseHover += (s, e) => FormUIUpdate(s, e, tl);
                        tableLayout.UserIcon.Click += (s, e) => JumpToUserPage(s, e);
                        tableLayout.UserScreenNameBox.BorderStyle = BorderStyle.None;
                        tableLayout.UserDescriptionBox.BorderStyle = BorderStyle.None;
                        tableLayout.UserDescriptionBox.ScrollBars = ScrollBars.Vertical;
                        tableLayout.UserIcon.Url = tl.User.ProfileImageUrl;
                        tableLayout.UserIcon.ContextMenuStrip = TweetIconContextMenuStrip;
                        tableLayout.UserScreenNameBox.ContextMenuStrip = TweetIconContextMenuStrip;
                        tableLayout.ContextMenuStrip = TweetTextContextMenuStrip;
                        tableLayout.UserDescriptionBox.ContextMenuStrip = TweetTextContextMenuStrip;
                        tableLayout.UserIcon.Image = Utils.Adjust(Utils.LoadImageFromURL(tl.User.ProfileImageUrl), tableLayout.UserIcon.Size.Width, tableLayout.UserIcon.Size.Height);
                        tableLayout.UserScreenNameBox.Text = $"{tl.User.Name} @{tl.User.ScreenName}";
                        tableLayout.UserDescriptionBox.Text = tl.Text;

                        tableLayout.BuildActionStatus(tl);
                        tableLayout.Reply_image.Click += (s, e) => ReplyClick(s, e);
                        tableLayout.Favorite_image.Click += (s, e) => Favorite_image_Click(s, e, tl, tableLayout.FavoriteCount);
                        tableLayout.Retweet_image.Click += (s, e) => Retweet_image_Click(s, e, tl);

                        timeLinePanel.Controls.Add(tableLayout);
                    }
                }
                catch {

                }
            }));

            await Task.CompletedTask;
        }

        private async Task BuildList(SearchResult statuses, FlowLayoutPanel timeLinePanel) {
            this.Invoke((Action)(() => {
                try {
                    Status[] timeline_array = statuses.ToArray();

                    foreach (Status tl in timeline_array) {
                        UserProfileTable tableLayout = new UserProfileTable();
                        tableLayout.MouseHover += (s, e) => FormUIUpdate(s, e, tl);
                        tableLayout.UserIcon.MouseHover += (s, e) => FormUIUpdate(s, e, tl);
                        tableLayout.UserScreenNameBox.MouseHover += (s, e) => FormUIUpdate(s, e, tl);
                        tableLayout.UserDescriptionBox.MouseHover += (s, e) => FormUIUpdate(s, e, tl);
                        tableLayout.UserIcon.Click += (s, e) => JumpToUserPage(s, e);
                        tableLayout.UserScreenNameBox.BorderStyle = BorderStyle.None;
                        tableLayout.UserDescriptionBox.BorderStyle = BorderStyle.None;
                        tableLayout.UserDescriptionBox.ScrollBars = ScrollBars.Vertical;
                        tableLayout.UserIcon.Url = tl.User.ProfileImageUrl;
                        tableLayout.UserIcon.ContextMenuStrip = TweetIconContextMenuStrip;
                        tableLayout.UserScreenNameBox.ContextMenuStrip = TweetIconContextMenuStrip;
                        tableLayout.ContextMenuStrip = TweetTextContextMenuStrip;
                        tableLayout.UserDescriptionBox.ContextMenuStrip = TweetTextContextMenuStrip;
                        tableLayout.UserIcon.Image = Utils.Adjust(Utils.LoadImageFromURL(tl.User.ProfileImageUrl), tableLayout.UserIcon.Size.Width, tableLayout.UserIcon.Size.Height);
                        tableLayout.UserScreenNameBox.Text = $"{tl.User.Name} @{tl.User.ScreenName}";
                        tableLayout.UserDescriptionBox.Text = tl.Text;

                        tableLayout.BuildActionStatus(tl);
                        tableLayout.Reply_image.Click += (s, e) => ReplyClick(s, e);
                        tableLayout.Favorite_image.Click += (s, e) => Favorite_image_Click(s, e, tl, tableLayout.FavoriteCount);
                        tableLayout.Retweet_image.Click += (s, e) => Retweet_image_Click(s, e, tl);

                        timeLinePanel.Controls.Add(tableLayout);
                    }
                }
                catch {

                }
            }));

            await Task.CompletedTask;
        }

        private async Task BuildList(ListedResponse<User> statuses, FlowLayoutPanel timeLinePanel) {

            this.Invoke((Action)(() => {

                try {

                    timeLinePanel.Controls.Clear();

                    foreach (User user in statuses) {

                        UserProfileTable tableLayout = new UserProfileTable();
                        tableLayout.MouseHover += (s, e) => FormUIUpdate(s, e, user);
                        tableLayout.UserIcon.MouseHover += (s, e) => FormUIUpdate(s, e, user);
                        tableLayout.UserScreenNameBox.MouseHover += (s, e) => FormUIUpdate(s, e, user);
                        tableLayout.UserDescriptionBox.MouseHover += (s, e) => FormUIUpdate(s, e, user);
                        tableLayout.UserDescriptionBox.ScrollBars = ScrollBars.Vertical;
                        tableLayout.UserIcon.Click += (s, e) => JumpToUserPage(s, e);
                        tableLayout.UserIcon.Url = user.ProfileImageUrl;

                        try {
                            tableLayout.UserIcon.Image = Utils.Adjust(Utils.LoadImageFromURL(user.ProfileImageUrl), tableLayout.UserIcon.Size.Width, tableLayout.UserIcon.Size.Height);
                        }
                        catch {

                        }

                        tableLayout.UserScreenNameBox.BorderStyle = BorderStyle.None;
                        tableLayout.UserDescriptionBox.BorderStyle = BorderStyle.None;
                        tableLayout.UserIcon.ContextMenuStrip = TweetIconContextMenuStrip;
                        tableLayout.UserScreenNameBox.ContextMenuStrip = TweetIconContextMenuStrip;
                        tableLayout.ContextMenuStrip = TweetIconContextMenuStrip;
                        tableLayout.UserDescriptionBox.ContextMenuStrip = TweetIconContextMenuStrip;
                        tableLayout.UserScreenNameBox.Text = $"{user.Name} @{user.ScreenName}";
                        tableLayout.UserDescriptionBox.Text = user.Description;

                        timeLinePanel.Controls.Add(tableLayout);
                    }
                }
                catch {

                }
            }));

            await Task.CompletedTask;
        }

        private void BuildList(User user, FlowLayoutPanel timeLinePanel) {

            UserPageTable userProfileTable = new UserPageTable(timeLinePanel);
            LastShowedUser = user;

            try {

                timeLinePanel.Controls.Clear();

                if (user != null) {
                    userProfileTable.ContextMenuStrip = SaverContextMenu;
                    SaveTweetItem = new ToolStripMenuItem();
                    SaveTweetItem.Name = "SaveTweetItem";
                    SaveTweetItem.Size = new Size(116, 22);
                    SaveTweetItem.Text = "ツイートを保存";
                    SaveTweetItem.Click += (s, e) => SaveAllTweets_Click(s, e, user);
                    userProfileTable.Size = new Size(UserPage.Size.Width - 20, UserPage.Size.Height - 20);
                    userProfileTable.ScreenName.Text = $"{user.Name} @{user.ScreenName}";
                    userProfileTable.Description.Text = user.Description;
                    userProfileTable.Header.Width = userProfileTable.Width - 20;
                    userProfileTable.Header.Image = Utils.LoadImageFromURL(user.ProfileBannerUrl);
                    userProfileTable.Header.SizeMode = PictureBoxSizeMode.Zoom;
                    userProfileTable.Header.Url = user.ProfileBannerUrl;
                    userProfileTable.Header.Click += PicturePreview_Click;
                    userProfileTable.Header.MouseHover += PicturePreviewMouseHovered;
                    userProfileTable.Header.MouseLeave += PicturePreviewMouseLeaved;
                    userProfileTable.UserIcon.Image = Utils.Adjust(Utils.LoadImageFromURL(user.ProfileImageUrl), userProfileTable.UserIcon.Width, userProfileTable.UserIcon.Height);
                    userProfileTable.UserIcon.Url = user.ProfileImageUrl;
                    userProfileTable.UserIcon.Click += PicturePreview_Click;
                    userProfileTable.UserIcon.MouseHover += PicturePreviewMouseHovered;
                    userProfileTable.UserIcon.MouseLeave += PicturePreviewMouseLeaved;
                    userProfileTable.FollowUnfollowButton.Click += (s, e)=> FollowUnfollowButton_Click(s, e, user);

                    Task.Run(async () => {
                        await BuildList(tokens.Statuses.UserTimeline(screen_name: user.ScreenName), userProfileTable.TimelinePanel);                        
                    });

                    userProfileTable.FollowUnfollowButton.Text = "フォロー(解除)";
                }
            }
            catch {

            }

            timeLinePanel.Controls.Add(userProfileTable);
        }

        private void SaveAllTweets_Click(object sender, EventArgs e, User user) {

            LogBox.Text += $"ツイートを保存しています{Environment.NewLine}";

            DateTime datetime = DateTime.Now;
            string now = datetime.ToString(dateformat);

            TweetSaveDialog.FileName = $"{user.ScreenName}-{now}";
            TweetSaveDialog.Filter = "テキストファイル(*.txt;*.text)|*.txt;*.text|すべてのファイル(*.*)|*.*";
            TweetSaveDialog.FilterIndex = 1;

            DialogResult saveresult = TweetSaveDialog.ShowDialog();

            if(saveresult == DialogResult.OK) {
                string FilePath = TweetSaveDialog.FileName;

                Task.Run(async () => {
                    try {
                        ListedResponse<Status> tweets = tokens.Statuses.UserTimeline(screen_name: user.ScreenName, count: 200);
                        string tweetstext = await GetAllTweets(tweets);

                        if (tweets != null && FilePath != null) {
                            string result =
                              $"Name:{user.Name}\n"
                            + $"ScreenName:@{user.ScreenName}\n"
                            + $"---------------------------------------------------------\n"
                            + $"ProfileImageUrl:{user.ProfileImageUrl}\n"
                            //+ $"ProfileImageUrl Base64:{ToBase64(user.ProfileImageUrl)}"
                            + $"---------------------------------------------------------\n"
                            + $"ProfileBannerUrl:{user.ProfileBannerUrl}\n"
                            //+ $"ProfileBannerUrl Base64:{ToBase64(user.ProfileImageUrl)}\n"
                            + $"*********************************************************\n"
                            + $"{tweetstext}\n"
                            + $"*********************************************************\n";

                            File.WriteAllText(FilePath, result);
                            
                            this.Invoke((Action)(() => {
                                LogBox.Text += $"保存しました:{FilePath}{Environment.NewLine}";
                            }));
                        }

                    }
                    catch(Exception ex) {
                        this.Invoke((Action)(() => {
                            LogBox.Text += $"保存できませんでした{ex}{Environment.NewLine}";
                        }));
                    }
                });
            }
        }

        private async Task<string> GetMediasUrlWithBase64(Status status) {
            
            string result = "";
            int count = 0;

            MediaEntity[] medias = status.Entities.Media;

            if(medias != null) {
                foreach (MediaEntity media in medias) {
                    result += $"Media{count}_Url:{media.MediaUrl}\n";
                    result += $"Media{count}_Base64:{ToBase64(media.MediaUrl)}\n";
                    count++;
                }
            }

            await Task.CompletedTask;
            return result;
        }

        private async Task<string> GetAllTweets(ListedResponse<Status> tweets) {
            string result = "";
            int nowcount = 0;

            ProgressDialog pd = new ProgressDialog();
            pd.Title = "ツイートを保存しています";
            pd.Minimum = 0;
            pd.Maximum = tweets.Count;
            pd.Value = 0;

            this.Invoke((Action)(() => {
                pd.Show(this);
            }));

            foreach (Status status in tweets) {

                this.Invoke((Action)(() => {
                    pd.Value = nowcount;
                }));

                result += $"---------------------------------------------------------\n";
                result += $"Id:{status.Id}\n";
                result += $"Text:{status.Text}\n";
                //result += $"{await GetMediasUrlWithBase64(status)}\n";
                result += $"CreatedAt:{status.CreatedAt.ToString(dateformat_jpn)}\n";
                result += $"Url:https://twitter.com{status.User.ScreenName}/status/{status.Id}\n\n";

                nowcount++;
            }

            this.Invoke((Action)(() => {
                pd.Close();
            }));

            await Task.CompletedTask;
            return result;
        }

        private string ToBase64(string url) {
            Image img = Utils.LoadImageFromURL(url);
            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            binFormatter.Serialize(memStream, img);
            byte[] bytes = memStream.GetBuffer();
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        private void FollowUnfollowButton_Click(object sender, EventArgs e, User user) {
            FollowUnfollowButton button = (FollowUnfollowButton)sender;
        }

        private void FormUIUpdate(object sender, EventArgs e, Status status) {

            ClickedTweetId = status.Id;
            ClickedUserId = (long)status.User.Id;
            ClickedUserScreenName = status.User.ScreenName;
            ClickedUser = status.User;
            PreviewLabel.Count = 0;
            PictureFlowLayout.Controls.Clear();

            if (status.Entities.Media != null) {

                MediaEntity[] tweet_images = status.Entities.Media;
                PreviewLabel.Count = tweet_images.Length;

                PictureboxUrl picturebox = new PictureboxUrl();

                foreach (MediaEntity tweet_image in tweet_images) {

                    picturebox = new PictureboxUrl();
                    picturebox.Name = tweet_image.Id.ToString();
                    picturebox.Click += PicturePreview_Click;
                    picturebox.MouseHover += PicturePreviewMouseHovered;
                    picturebox.MouseLeave += PicturePreviewMouseLeaved;
                    picturebox.Size = new Size(150, 90);
                    picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                    picturebox.Image = Utils.LoadImageFromURL(tweet_image.MediaUrl);
                    picturebox.Url = tweet_image.MediaUrl;

                    PictureFlowLayout.Controls.Add(picturebox);
                }

                PreviewLabel.Text = $"ツイート画像 {PreviewLabel.Count}/4";
            }
            else {

                PreviewLabel.Text = noimages;
            }

            ChangeMode();
        }

        private void FormUIUpdate(object sender, EventArgs e, User status) {

            ClickedTweetId = 0;
            ClickedUserId = (long)status.Id;
            ClickedUserScreenName = status.ScreenName;
            ClickedUser = status;
            PreviewLabel.Count = 0;
            PictureFlowLayout.Controls.Clear();

            ChangeMode();
        }

        private void PicturePreviewMouseHovered(object sender, EventArgs e) {

            PictureBox pictureBox = (PictureBox)sender;

            if (pictureBox.Image != null) {

                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                //pictureBox.Click += PicturePreview_Click;
                ModeTextBox.Text = "画像をクリックで拡大表示";
            }
        }

        private void PicturePreviewMouseLeaved(object sender, EventArgs e) {

            PictureBox pictureBox = (PictureBox)sender;

            if (pictureBox.Image != null) {

                pictureBox.BorderStyle = BorderStyle.None;
                //pictureBox.Click -= PicturePreview_Click;
                UpdateMode();
            }
        }

        private void OauthButton_Click(object sender, EventArgs e) {

            try {

                if (settings != null && !IsPortableMode) {

                    settings.ApiKey = ApiKey.Text;
                    settings.ApiKeySecret = ApiKeySecret.Text;
                    settings.AccessToken = AccessToken.Text;
                    settings.AccessTokenSecret = AccessTokenSecret.Text;
                    settings.Save();
                }
                else {

                    iniSettings.ApiKey = ApiKey.Text;
                    iniSettings.ApiKeySecret = ApiKeySecret.Text;
                    iniSettings.AccessToken = AccessToken.Text;
                    iniSettings.AccessTokenSecret = AccessTokenSecret.Text;
                    iniSettings.Save();
                }

                tokens = Tokens.Create(
                    $"{ApiKey.Text}",
                    $"{ApiKeySecret.Text}",
                    $"{AccessToken.Text}",
                    $"{AccessTokenSecret.Text}");

                UpdateTitle();

                TimeLinePanel.Controls.Clear();
                NoticePanel.Controls.Clear();
                try {

                    Task.Run(async () => {

                        await BuildList(tokens.Statuses.HomeTimeline(), TimeLinePanel);
                        await BuildList(tokens.Statuses.MentionsTimeline(), NoticePanel);
                    });
                }
                catch (Exception ex) {

                    LogBox.Text += ex;
                }

                LogBox.Text += $"認証しました{Environment.NewLine}";
            }
            catch (Exception ex) {

                LogBox.Text += $"認証中に次のエラーが発生しました{Environment.NewLine}{ex}";
            }
        }

        private void UpdateTitle() {
            try {

                CoreTweet.Core.ListedResponse<Status> timeline = tokens.Statuses.UserTimeline();
                Status[] timeline_array = timeline.ToArray();
                foreach (Status tl in timeline_array) {

                    this.ScreenName = tl.User.ScreenName;
                }

                if (!IsPortableMode) {

                    this.Text = $"{OldTitle}";
                }
                else {

                    this.Text = $"{OldTitle} Portable";
                }
            }
            catch (Exception e) {

                LogBox.Text += $"読み込みエラー:{e}{Environment.NewLine}";
            }
        }

        public static Image ResizeImage(Image imgToResize, Size size) {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void TweetButton_Click(object sender, EventArgs e) {
            if (imagefiles.Count != 0) {
                try {
                    MediaUploadResult upload_result = new MediaUploadResult();

                    foreach (string filepath in imagefiles) {
                        upload_result = tokens.Media.Upload(media: new FileInfo(filepath));
                    }

                    StatusResponse statusResponce = tokens.Statuses.Update(new {
                        status = TweetTextBox.Text,
                        media_ids = new long[] { upload_result.MediaId }
                    });

                    ModeTextBox.Text = $"ツイートしました{Environment.NewLine}https://twitter.com/{statusResponce.User.ScreenName}/status/{statusResponce.Id}";
                }
                catch (TwitterException) {

                }
            }
            else if (TweetTextBox.Reply_tweet_id != 0 && TweetTextBox.Isreplying) {
                try {
                    StatusResponse statusResponce = tokens.Statuses.Update(new {
                        status = TweetTextBox.Text,
                        in_reply_to_status_id = TweetTextBox.Reply_tweet_id,


                    });

                    ModeTextBox.Text = $"返信しました{Environment.NewLine}https://twitter.com/{statusResponce.User.ScreenName}/status/{statusResponce.Id}";
                }
                catch (TwitterException) {

                }
            }
            else if (TweetTextBox.Reply_tweet_id != 0 && imagefiles.Count != 0 && TweetTextBox.Isreplying) {
                try {
                    MediaUploadResult upload_result = new MediaUploadResult();

                    foreach (string filepath in imagefiles) {
                        upload_result = tokens.Media.Upload(media: new FileInfo(filepath));
                    }

                    StatusResponse statusResponce = tokens.Statuses.Update(new {
                        status = TweetTextBox.Text,
                        media_ids = new long[] { upload_result.MediaId },
                        in_reply_to_status_id = TweetTextBox.Reply_tweet_id
                    });

                    ModeTextBox.Text = $"返信しました{Environment.NewLine}https://twitter.com/{statusResponce.User.ScreenName}/status/{statusResponce.Id}";
                }
                catch (TwitterException) {

                }
            }
            else {
                try {
                    tokens.Statuses.Update(new {
                        status = TweetTextBox.Text
                    });
                }
                catch (TwitterException) {

                }
            }

            ClearImage();
            TweetTextBox.Text = "";
            TweetTextBox.Isreplying = false;
            TweetTextBox.Reply_tweet_id = 0;
        }

        private void SelectImage(object sender, EventArgs e) {
            ImageFileSelectDialog.Title = "アップロードする画像を選択...";
            ImageFileSelectDialog.Filter = "*.png|*.jpg|*.jpeg|*.gif";
            ImageFileSelectDialog.FileName = "";
            ImageFileSelectDialog.RestoreDirectory = true;
            ImageFileSelectDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (ImageFileSelectDialog.ShowDialog() == DialogResult.OK) {
                if (imagefiles.Count < 4) {
                    imagefiles.Add(ImageFileSelectDialog.FileName);
                    LogBox.Text += $"{ImageFileSelectDialog.FileName}を読み込みました{Environment.NewLine}";

                    PictureboxUrl picturebox = new PictureboxUrl();

                    picturebox.Size = new Size(150, 90);
                    picturebox.Image = Utils.Adjust(Image.FromFile(ImageFileSelectDialog.FileName), picturebox.Width, picturebox.Height);
                    picturebox.Url = "";

                    PictureFlowLayout.Controls.Add(picturebox);

                    if (imagefiles.Count != 0) {
                        TweetButton.Enabled = true;
                    }
                }
            }

            PreviewLabel.Text = selectedimage;
        }

        private void ClearImage() {
            PictureFlowLayout.Controls.Clear();
            imageViewForm = new ImageViewForm(labelstatus: PreviewLabel.Text);
        }

        private void TweetTextChanged(object sender, EventArgs e) {
            if (TweetTextBox.Text.Length != 0 || imagefiles.Count != 0) {
                TweetButton.Enabled = true;
            }
            else {
                TweetButton.Enabled = false;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            TweetTextBox.Isreplying = false;
            TweetTextBox.Reply_tweet_id = 0;
            ClickedTweetId = 0;
            ClickedUserId = 0;
            ClickedUser = null;
            imagefiles.Clear();
            ClearImage();
            PictureFlowLayout.Controls.Clear();
            TweetTextBox.Text = "";
            TweetButton.Enabled = false;
            ImageSelector.Enabled = true;

            UpdateMode();

            LogBox.Text += $"リセットしました{Environment.NewLine}";
        }

        private void ImagesResetButton_Click(object sender, EventArgs e) {
            imagefiles.Clear();
            ClearImage();
            PictureFlowLayout.Controls.Clear();

            if (TweetTextBox.Text.Length == 0) {
                TweetButton.Enabled = false;
            }

            LogBox.Text += $"画像をリセットしました{Environment.NewLine}";
        }

        private void MainFormSelected(object sender, TabControlEventArgs e) {
            PreviewLabel.Text = selectedimage;
            ClearImage();

            if (MainForm.SelectedTab.Text == TimeLinePage.Text && !TimelinePageAlreadyLoaded) {
                try {
                    Task.Run(async () => {
                        await BuildList(tokens.Statuses.HomeTimeline(), TimeLinePanel);
                    });

                    TimelinePageAlreadyLoaded = true;
                }
                catch (Exception ex) {
                    LogBox.Text += $"{TimeLinePage.Text}を読み込もうとして、次のエラーが発生しました{Environment.NewLine}{ex}";
                }
            }
            else if (MainForm.SelectedTab.Text == NoticePage.Text && !NoticePageAlreadyLoaded) {
                try {
                    Task.Run(async () => {
                        await BuildList(tokens.Statuses.MentionsTimeline(), NoticePanel);
                    });

                    NoticePageAlreadyLoaded = true;
                }
                catch (Exception ex) {
                    LogBox.Text += $"{NoticePage.Text}を読み込もうとして、次のエラーが発生しました{Environment.NewLine}{ex}";
                }
            }
            else if (MainForm.SelectedTab.Text == UserSearchPage.Text) {
                ClickedTweetId = 0;
                ClickedUser = null;
                ClickedUserId = 0;
                ClickedUserScreenName = "";
                PreviewLabel.Count = 0;
                PictureFlowLayout.Controls.Clear();
            }

            ChangeMode();
        }

        private void ChangeMode() {
            string now_tab = MainForm.SelectedTab.Text;

            if (now_tab == TimeLinePage.Text || now_tab == NoticePage.Text || now_tab == SearchPage.Text || now_tab == UserPage.Text) {
                UpdateMode();
            }
            else if (now_tab == TweetPage.Text) {
                PictureFlowLayout.Controls.Clear();

                if (imagefiles.Count != 0) {
                    foreach (string bitmap in imagefiles) {
                        PictureboxUrl picturebox = new PictureboxUrl();

                        picturebox.Click += PicturePreview_Click;
                        picturebox.Size = new Size(150, 90);
                        picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                        picturebox.Image = Image.FromFile(bitmap);
                        picturebox.Url = bitmap;

                        PictureFlowLayout.Controls.Add(picturebox);
                    }
                }
            }
            else if (now_tab == SearchPage.Text) {
                PictureFlowLayout.Controls.Clear();
                ClearImage();
            }
            else if (now_tab == UserSearchPage.Text) {
                PictureFlowLayout.Controls.Clear();
                UpdateMode(true);
                ClearImage();
            }
            else if(now_tab == RateLimitPage.Text) {
                Task.Run(async () => {
                    string res = "";
                    DictionaryResponse<string, Dictionary<string, RateLimit>> ratelimits = tokens.Application.RateLimitStatus();
                    foreach (var limit in ratelimits) {
                        foreach (KeyValuePair<string, RateLimit> lim in limit.Value) {
                            res += $"{lim.Key}:{lim.Value.Remaining}{Environment.NewLine}";

                        }
                    }
                    this.Invoke((Action)(() => {
                        RateLimitBox.Text += res;
                        TextSearch.TextChanged += (s, e) => TextSearchButton_Click(s, e, TextSearch.Text, ratelimits);
                    }));

                    await Task.CompletedTask;
                });
            }
            else {
                PictureFlowLayout.Controls.Clear();
                ModeTextBox.Text = $"";
            }
        }
        
        private void TextSearchButton_Click(object sender, EventArgs e, string searchkey, DictionaryResponse<string, Dictionary<string, RateLimit>> l) {
            string result = "";
            foreach (var limit in l) {
                foreach (KeyValuePair<string, RateLimit> lim in limit.Value) {
                    if(lim.Key.Contains(searchkey)) {

                        result += $"{lim.Key}:{lim.Value.Remaining}{Environment.NewLine}";
                    }
                }
            }

            RateLimitBox.Text = result;
        }

        private void FavRetClick(object sender, EventArgs e) {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Text == "いいね") {
                tokens.Favorites.Create(id: ClickedTweetId);
                Trace.WriteLine($"いいね:{ClickedTweetId}");
                LogBox.Text += $"いいねしました:{ClickedTweetId}";
            }
            else if (item.Text == "リツイート") {
                tokens.Statuses.Retweet(id: ClickedTweetId);
                Trace.WriteLine($"リツイート:{ClickedTweetId}");
                LogBox.Text += $"リツイートしました:{ClickedTweetId}";
            }
        }

        private void Favorite_image_Click(object sender, EventArgs e, Status status, FavoriteCountBox FavoriteCount) {
            FavoritePictureBox favorite_image = (FavoritePictureBox)sender;

            if (tokens != null && status != null) {
                if (!favorite_image.IsFavorited) {
                    favorite_image.Image = Properties.Resources.favorirte_true_image;
                    favorite_image.IsFavorited = true;
                    tokens.Favorites.Create(status.Id);

                    FavoriteCount.Text = tokens.Statuses.Show(id: status.Id).FavoriteCount.ToString();
                }
                else {
                    favorite_image.Image = Properties.Resources.favorite_false_image;
                    favorite_image.IsFavorited = false;
                    tokens.Favorites.Destroy(status.Id);
                }
            }
        }

        private void Favorite_image_Click(object sender, EventArgs e, Status status, RetweetPictureBox RetweetCount) {
            FavoritePictureBox favorite_image = (FavoritePictureBox)sender;

            if (tokens != null && status != null) {
                if (!favorite_image.IsFavorited) {
                    favorite_image.Image = Properties.Resources.favorirte_true_image;
                    favorite_image.IsFavorited = true;
                    tokens.Favorites.Create(status.Id);

                    RetweetCount.Text = tokens.Statuses.Show(id: status.Id).FavoriteCount.ToString();
                }
                else {
                    favorite_image.Image = Properties.Resources.favorite_false_image;
                    favorite_image.IsFavorited = false;
                    tokens.Favorites.Destroy(status.Id);
                }
            }
        }

        private void Retweet_image_Click(object sender, EventArgs e, Status status) {
            RetweetPictureBox retweet_image = (RetweetPictureBox)sender;

            if (tokens != null && status != null) {
                if (!retweet_image.IsRetweeted) {
                    retweet_image.Image = Properties.Resources.retweet_true_image;
                    retweet_image.IsRetweeted = true;
                    StatusResponse res = tokens.Statuses.Retweet(status.Id);
                    retweet_image.LastRetweetedId = res.Id;
                }
                else {
                    retweet_image.Image = Properties.Resources.retweet_false_image;
                    retweet_image.IsRetweeted = false;

                    if (retweet_image.LastRetweetedId != 0) {
                        tokens.Statuses.Destroy(retweet_image.LastRetweetedId);
                    }
                }
            }
        }

        private void FollowItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.Text == "フォロー") {
                try {
                    tokens.Friendships.Create(user_id: ClickedUserId);
                    Trace.WriteLine($"フォロー:{ClickedUserId}");
                }
                catch (Exception) {
                    LogBox.Text += "フォローに失敗しました";
                }
            }
            else if (item.Text == "フォロー解除") {
                try {
                    tokens.Friendships.Destroy(user_id: ClickedUserId);
                    Trace.WriteLine($"フォロー解除:{ClickedUserId}");
                }
                catch (Exception) {
                    LogBox.Text += "フォロー解除に失敗しました";
                }
            }
        }

        private void ReloadItem_Click(object sender, EventArgs e) {
            if (MainForm.SelectedTab == TimeLinePage) {
                try {
                    TimeLinePanel.Controls.Clear();

                    Task.Run(async () => {
                        await BuildList(tokens.Statuses.HomeTimeline(), TimeLinePanel);
                    });
                }
                catch (Exception ex) {
                    LogBox.Text += $"{TimeLinePage.Text}を読み込もうとして、次のエラーが発生しました{Environment.NewLine}{ex}";
                }
            }
            else if (MainForm.SelectedTab == NoticePage) {
                try {
                    NoticePanel.Controls.Clear();

                    Task.Run(async () => {
                        await BuildList(tokens.Statuses.MentionsTimeline(), NoticePanel);
                    });
                }
                catch (Exception ex) {
                    LogBox.Text += $"{NoticePage.Text}を読み込もうとして、次のエラーが発生しました{Environment.NewLine}{ex}";
                }
            }
            else if(MainForm.SelectedTab == UserPage) {
                BuildList(LastShowedUser, UserPanel);
            }

            LogBox.Text += $"読み込み完了。{Environment.NewLine}";
            Trace.WriteLine($"読み込み完了。");
        }

        private void ReplyClick(object sender, EventArgs e) {
            TweetTextBox.Isreplying = true;
            TweetTextBox.Reply_tweet_id = ClickedTweetId;
            MainForm.SelectedTab = TweetPage;
            UpdateMode();
        }

        private void PicturePreview_Click(object sender, EventArgs e) {
            PictureboxUrl pictureBox = (PictureboxUrl)sender;

            imageViewForm = new ImageViewForm();

            if (MainForm.SelectedTab.Text == TimeLinePage.Text || MainForm.SelectedTab.Text == NoticePage.Text || MainForm.SelectedTab.Text == SearchPage.Text || MainForm.SelectedTab.Text == UserPage.Text) {
                if (pictureBox.Url != "" || pictureBox.Image != null) {
                    imageViewForm = new ImageViewForm(pictureBox.Url, PreviewLabel.Text);
                    imageViewForm.ShowDialog();
                }
            }
        }

        private void OpenTweetUrl(object sender, EventArgs e) {
            if (ClickedUserScreenName != "" && ClickedTweetId != 0) {
                Utils.OpenUrl($"https://twitter.com/{ClickedUserScreenName}/status/{ClickedTweetId}");
            }
        }

        public void JumpToUserPage(object sender, EventArgs e) {
            if(MainForm.SelectedTab.Text != UserPage.Text) {
                MainForm.SelectedTab = UserPage;
                BuildList(ClickedUser, UserPanel);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e) {
            ClearImage();
            if (SearchTextBox.Text != "") {
                try {
                    SearchResultLayout.Controls.Clear();

                    Task.Run(async () => {
                        SearchResult res = tokens.Search.Tweets(q: SearchTextBox.Text);
                        await BuildList(res, SearchResultLayout);
                    });
                }
                catch (Exception ex) {
                    LogBox.Text += $"検索中に次のエラーが発生しました{Environment.NewLine}{ex}";
                }
            }
        }

        private void UserSearchButton_Click(object sender, EventArgs e) {
            ClearImage();
            if (UserSearchBox.Text != "") {
                try {
                    UserSearchResultLayout.Controls.Clear();

                    Task.Run(async () => {
                        ListedResponse<User> res = tokens.Users.Search(q: UserSearchBox.Text);
                        await BuildList(res, UserSearchResultLayout);
                    });
                }
                catch (Exception ex) {
                    LogBox.Text += ex;
                    LogBox.Text += $"検索中に次のエラーが発生しました{Environment.NewLine}{ex}";
                }
            }
        }

        private void ClearReply_Click(object sender, EventArgs e) {
            TweetTextBox.Isreplying = false;
            TweetTextBox.Reply_tweet_id = 0;
            UpdateMode();
        }

        private void UpdateMode(bool isUserSearch = false) {
            if (TweetTextBox.Isreplying) {
                ModeTextBox.Text = $"ツイートID:{ClickedTweetId}{Environment.NewLine}ユーザーID:{ClickedUserId}{Environment.NewLine}返信中のID:{TweetTextBox.Reply_tweet_id}{Environment.NewLine}右クリックでアクションを実行";
            }
            else if (isUserSearch) {
                ModeTextBox.Text = $"ユーザースクリーンネーム:{ClickedUserScreenName}{Environment.NewLine}ユーザーID:{ClickedUserId}{Environment.NewLine}右クリックでアクションを実行";
            }
            else {
                ModeTextBox.Text = $"ツイートID:{ClickedTweetId}{Environment.NewLine}ユーザーID:{ClickedUserId}{Environment.NewLine}返信中のID:{Environment.NewLine}右クリックでアクションを実行";
            }
        }

        private void PreviewLabelChanged(object sender, EventArgs e) {
            foreach (PictureboxUrl picturebox in PictureFlowLayout.Controls) {
                if (PreviewLabel.Text == noimages || PreviewLabel.Text == selectedimage) {
                    picturebox.Enabled = false;
                }
                else {
                    picturebox.Enabled = true;
                }
            }
        }
    }
}
