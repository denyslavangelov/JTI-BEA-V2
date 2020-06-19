namespace Brandlist_Export_Assistant_V2.Controls
{
    partial class DataExportControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataExportControl));
            this.exportDataButton = new Guna.UI.WinForms.GunaButton();
            this.exportLabel = new System.Windows.Forms.Label();
            this.loadingBarImage = new Guna.UI.WinForms.GunaPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.successTitle = new System.Windows.Forms.Label();
            this.successBodyText = new System.Windows.Forms.Label();
            this.successFolderButton = new Guna.UI.WinForms.GunaButton();
            this.successPanel = new System.Windows.Forms.Panel();
            this.browsePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBarImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.successPanel.SuspendLayout();
            this.browsePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportDataButton
            // 
            this.exportDataButton.Animated = true;
            this.exportDataButton.AnimationHoverSpeed = 2.5F;
            this.exportDataButton.AnimationSpeed = 0.03F;
            this.exportDataButton.BackColor = System.Drawing.Color.Transparent;
            this.exportDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exportDataButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.exportDataButton.BorderColor = System.Drawing.Color.Black;
            this.exportDataButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.exportDataButton.FocusedColor = System.Drawing.Color.Empty;
            this.exportDataButton.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportDataButton.ForeColor = System.Drawing.Color.White;
            this.exportDataButton.Image = null;
            this.exportDataButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exportDataButton.ImageOffsetX = 100;
            this.exportDataButton.ImageSize = new System.Drawing.Size(25, 25);
            this.exportDataButton.Location = new System.Drawing.Point(52, 83);
            this.exportDataButton.Name = "exportDataButton";
            this.exportDataButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.exportDataButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.exportDataButton.OnHoverForeColor = System.Drawing.Color.White;
            this.exportDataButton.OnHoverImage = null;
            this.exportDataButton.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.exportDataButton.OnPressedDepth = 0;
            this.exportDataButton.Radius = 20;
            this.exportDataButton.Size = new System.Drawing.Size(175, 58);
            this.exportDataButton.TabIndex = 4;
            this.exportDataButton.Text = "CHOOSE FILE";
            this.exportDataButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exportDataButton.UseTransfarantBackground = true;
            this.exportDataButton.Click += new System.EventHandler(this.ExportDataButton_Click);
            // 
            // exportLabel
            // 
            this.exportLabel.AutoSize = true;
            this.exportLabel.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(68)))));
            this.exportLabel.Location = new System.Drawing.Point(13, 47);
            this.exportLabel.Name = "exportLabel";
            this.exportLabel.Size = new System.Drawing.Size(259, 25);
            this.exportLabel.TabIndex = 5;
            this.exportLabel.Text = "PLEASE SELECT A MDD FILE.";
            // 
            // loadingBarImage
            // 
            this.loadingBarImage.BaseColor = System.Drawing.Color.White;
            this.loadingBarImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingBarImage.Image")));
            this.loadingBarImage.Location = new System.Drawing.Point(62, 88);
            this.loadingBarImage.Name = "loadingBarImage";
            this.loadingBarImage.Size = new System.Drawing.Size(54, 48);
            this.loadingBarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingBarImage.TabIndex = 11;
            this.loadingBarImage.TabStop = false;
            this.loadingBarImage.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 222);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // successTitle
            // 
            this.successTitle.AutoSize = true;
            this.successTitle.Font = new System.Drawing.Font("Tw Cen MT", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.successTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.successTitle.Location = new System.Drawing.Point(107, 248);
            this.successTitle.Name = "successTitle";
            this.successTitle.Size = new System.Drawing.Size(133, 43);
            this.successTitle.TabIndex = 14;
            this.successTitle.Text = "Success!";
            // 
            // successBodyText
            // 
            this.successBodyText.AutoSize = true;
            this.successBodyText.Font = new System.Drawing.Font("Tw Cen MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.successBodyText.ForeColor = System.Drawing.Color.DimGray;
            this.successBodyText.Location = new System.Drawing.Point(68, 291);
            this.successBodyText.Name = "successBodyText";
            this.successBodyText.Size = new System.Drawing.Size(210, 48);
            this.successBodyText.TabIndex = 15;
            this.successBodyText.Text = "The data was imported\r\n          sucesfully.";
            // 
            // successFolderButton
            // 
            this.successFolderButton.Animated = true;
            this.successFolderButton.AnimationHoverSpeed = 2.5F;
            this.successFolderButton.AnimationSpeed = 0.03F;
            this.successFolderButton.BackColor = System.Drawing.Color.Transparent;
            this.successFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.successFolderButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.successFolderButton.BorderColor = System.Drawing.Color.Black;
            this.successFolderButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.successFolderButton.FocusedColor = System.Drawing.Color.Empty;
            this.successFolderButton.Font = new System.Drawing.Font("Tw Cen MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.successFolderButton.ForeColor = System.Drawing.Color.White;
            this.successFolderButton.Image = null;
            this.successFolderButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.successFolderButton.ImageOffsetX = 100;
            this.successFolderButton.ImageSize = new System.Drawing.Size(25, 25);
            this.successFolderButton.Location = new System.Drawing.Point(117, 349);
            this.successFolderButton.Name = "successFolderButton";
            this.successFolderButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.successFolderButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.successFolderButton.OnHoverForeColor = System.Drawing.Color.White;
            this.successFolderButton.OnHoverImage = null;
            this.successFolderButton.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(61)))), ((int)(((byte)(86)))));
            this.successFolderButton.OnPressedDepth = 0;
            this.successFolderButton.Radius = 20;
            this.successFolderButton.Size = new System.Drawing.Size(112, 40);
            this.successFolderButton.TabIndex = 16;
            this.successFolderButton.Text = "OPEN FOLDER";
            this.successFolderButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.successFolderButton.UseTransfarantBackground = true;
            this.successFolderButton.Click += new System.EventHandler(this.SuccessFolderButton_Click);
            // 
            // successPanel
            // 
            this.successPanel.Controls.Add(this.successFolderButton);
            this.successPanel.Controls.Add(this.pictureBox1);
            this.successPanel.Controls.Add(this.successBodyText);
            this.successPanel.Controls.Add(this.successTitle);
            this.successPanel.Location = new System.Drawing.Point(119, 6);
            this.successPanel.Name = "successPanel";
            this.successPanel.Size = new System.Drawing.Size(367, 392);
            this.successPanel.TabIndex = 17;
            this.successPanel.Visible = false;
            // 
            // browsePanel
            // 
            this.browsePanel.Controls.Add(this.loadingBarImage);
            this.browsePanel.Controls.Add(this.exportDataButton);
            this.browsePanel.Controls.Add(this.exportLabel);
            this.browsePanel.Location = new System.Drawing.Point(155, 401);
            this.browsePanel.Name = "browsePanel";
            this.browsePanel.Size = new System.Drawing.Size(294, 171);
            this.browsePanel.TabIndex = 18;
            // 
            // DataExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.successPanel);
            this.Controls.Add(this.browsePanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "DataExportControl";
            this.Size = new System.Drawing.Size(579, 517);
            ((System.ComponentModel.ISupportInitialize)(this.loadingBarImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.successPanel.ResumeLayout(false);
            this.successPanel.PerformLayout();
            this.browsePanel.ResumeLayout(false);
            this.browsePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaButton exportDataButton;
        private System.Windows.Forms.Label exportLabel;
        private Guna.UI.WinForms.GunaPictureBox loadingBarImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label successTitle;
        private System.Windows.Forms.Label successBodyText;
        private Guna.UI.WinForms.GunaButton successFolderButton;
        private System.Windows.Forms.Panel successPanel;
        private System.Windows.Forms.Panel browsePanel;
    }
}
