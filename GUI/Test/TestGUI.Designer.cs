
namespace Twitter_CSharp.GUI.Test {
    partial class TestGUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.UserTable = new System.Windows.Forms.TableLayoutPanel();
            this.InfoTable = new System.Windows.Forms.TableLayoutPanel();
            this.IconTable = new System.Windows.Forms.TableLayoutPanel();
            this.UserIcon = new System.Windows.Forms.PictureBox();
            this.DescriptionTable = new System.Windows.Forms.TableLayoutPanel();
            this.ScreenName = new System.Windows.Forms.TextBox();
            this.Description = new Twitter_CSharp.GUI.CustomGUI.AutoSizeTextBox();
            this.Header = new System.Windows.Forms.PictureBox();
            this.TimelinePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.UserTable.SuspendLayout();
            this.InfoTable.SuspendLayout();
            this.IconTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserIcon)).BeginInit();
            this.DescriptionTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).BeginInit();
            this.SuspendLayout();
            // 
            // UserTable
            // 
            this.UserTable.AutoScroll = true;
            this.UserTable.AutoSize = true;
            this.UserTable.ColumnCount = 1;
            this.UserTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.UserTable.Controls.Add(this.InfoTable, 0, 1);
            this.UserTable.Controls.Add(this.Header, 0, 0);
            this.UserTable.Controls.Add(this.TimelinePanel, 0, 2);
            this.UserTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserTable.Location = new System.Drawing.Point(0, 0);
            this.UserTable.Name = "UserTable";
            this.UserTable.RowCount = 3;
            this.UserTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.UserTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.UserTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UserTable.Size = new System.Drawing.Size(684, 400);
            this.UserTable.TabIndex = 1;
            // 
            // InfoTable
            // 
            this.InfoTable.ColumnCount = 2;
            this.InfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.InfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InfoTable.Controls.Add(this.IconTable, 0, 0);
            this.InfoTable.Controls.Add(this.DescriptionTable, 1, 0);
            this.InfoTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoTable.Location = new System.Drawing.Point(3, 83);
            this.InfoTable.Name = "InfoTable";
            this.InfoTable.RowCount = 1;
            this.InfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.InfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.InfoTable.Size = new System.Drawing.Size(678, 207);
            this.InfoTable.TabIndex = 2;
            // 
            // IconTable
            // 
            this.IconTable.AutoSize = true;
            this.IconTable.ColumnCount = 1;
            this.IconTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IconTable.Controls.Add(this.UserIcon, 0, 0);
            this.IconTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IconTable.Location = new System.Drawing.Point(3, 3);
            this.IconTable.Name = "IconTable";
            this.IconTable.RowCount = 2;
            this.IconTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.IconTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.IconTable.Size = new System.Drawing.Size(58, 201);
            this.IconTable.TabIndex = 0;
            // 
            // UserIcon
            // 
            this.UserIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserIcon.Location = new System.Drawing.Point(3, 3);
            this.UserIcon.Name = "UserIcon";
            this.UserIcon.Size = new System.Drawing.Size(52, 58);
            this.UserIcon.TabIndex = 0;
            this.UserIcon.TabStop = false;
            // 
            // DescriptionTable
            // 
            this.DescriptionTable.AutoSize = true;
            this.DescriptionTable.ColumnCount = 1;
            this.DescriptionTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DescriptionTable.Controls.Add(this.ScreenName, 0, 0);
            this.DescriptionTable.Controls.Add(this.Description, 0, 1);
            this.DescriptionTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionTable.Location = new System.Drawing.Point(67, 3);
            this.DescriptionTable.Name = "DescriptionTable";
            this.DescriptionTable.RowCount = 2;
            this.DescriptionTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DescriptionTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.DescriptionTable.Size = new System.Drawing.Size(608, 201);
            this.DescriptionTable.TabIndex = 1;
            // 
            // ScreenName
            // 
            this.ScreenName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScreenName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenName.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScreenName.Location = new System.Drawing.Point(3, 3);
            this.ScreenName.Name = "ScreenName";
            this.ScreenName.ReadOnly = true;
            this.ScreenName.Size = new System.Drawing.Size(602, 18);
            this.ScreenName.TabIndex = 0;
            // 
            // Description
            // 
            this.Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.Description.Location = new System.Drawing.Point(3, 53);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Size = new System.Drawing.Size(602, 23);
            this.Description.TabIndex = 1;
            // 
            // Header
            // 
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Location = new System.Drawing.Point(3, 3);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(678, 74);
            this.Header.TabIndex = 3;
            this.Header.TabStop = false;
            // 
            // TimelinePanel
            // 
            this.TimelinePanel.AutoScroll = true;
            this.TimelinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimelinePanel.Location = new System.Drawing.Point(3, 296);
            this.TimelinePanel.Name = "TimelinePanel";
            this.TimelinePanel.Size = new System.Drawing.Size(678, 101);
            this.TimelinePanel.TabIndex = 4;
            // 
            // TestGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 400);
            this.Controls.Add(this.UserTable);
            this.Name = "TestGUI";
            this.Text = "TestGUI";
            this.UserTable.ResumeLayout(false);
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

        #endregion

        private System.Windows.Forms.TableLayoutPanel UserTable;
        private System.Windows.Forms.TableLayoutPanel InfoTable;
        private System.Windows.Forms.TableLayoutPanel IconTable;
        private System.Windows.Forms.PictureBox UserIcon;
        private System.Windows.Forms.TableLayoutPanel DescriptionTable;
        private System.Windows.Forms.TextBox ScreenName;
        private System.Windows.Forms.PictureBox Header;
        private System.Windows.Forms.FlowLayoutPanel TimelinePanel;
        private CustomGUI.AutoSizeTextBox Description;
    }
}