namespace Brandlist_Export_Assistant_V2.Controls
{
    partial class SuccessScreenControl
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
            this.successPanel = new System.Windows.Forms.Panel();
            this.successFolderButton = new Guna.UI.WinForms.GunaButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.successBodyText = new System.Windows.Forms.Label();
            this.successTitle = new System.Windows.Forms.Label();
            this.successPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // successPanel
            // 
            this.successPanel.Controls.Add(this.successFolderButton);
            this.successPanel.Controls.Add(this.pictureBox1);
            this.successPanel.Controls.Add(this.successBodyText);
            this.successPanel.Controls.Add(this.successTitle);
            this.successPanel.Location = new System.Drawing.Point(130, 13);
            this.successPanel.Name = "successPanel";
            this.successPanel.Size = new System.Drawing.Size(367, 392);
            this.successPanel.TabIndex = 18;
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
            this.successFolderButton.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Brandlist_Export_Assistant_V2.Properties.Resources.SuccessScreen;
            this.pictureBox1.Location = new System.Drawing.Point(36, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 222);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
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
            // SuccessScreenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.successPanel);
            this.Name = "SuccessScreenControl";
            this.Size = new System.Drawing.Size(579, 517);
            this.successPanel.ResumeLayout(false);
            this.successPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel successPanel;
        private Guna.UI.WinForms.GunaButton successFolderButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label successBodyText;
        private System.Windows.Forms.Label successTitle;
    }
}
