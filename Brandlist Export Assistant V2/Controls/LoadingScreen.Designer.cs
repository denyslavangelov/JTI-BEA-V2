namespace Brandlist_Export_Assistant_V2.Controls
{
    partial class LoadingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            this.uploadPanel = new Guna.UI.WinForms.GunaPanel();
            this.uploadButton = new Guna.UI.WinForms.GunaButton();
            this.loadingBarImage = new Guna.UI.WinForms.GunaPictureBox();
            this.uploadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBarImage)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadPanel
            // 
            this.uploadPanel.Controls.Add(this.loadingBarImage);
            this.uploadPanel.Controls.Add(this.uploadButton);
            this.uploadPanel.Location = new System.Drawing.Point(183, 205);
            this.uploadPanel.Name = "uploadPanel";
            this.uploadPanel.Size = new System.Drawing.Size(207, 77);
            this.uploadPanel.TabIndex = 15;
            // 
            // uploadButton
            // 
            this.uploadButton.Animated = true;
            this.uploadButton.AnimationHoverSpeed = 2.5F;
            this.uploadButton.AnimationSpeed = 0.03F;
            this.uploadButton.BackColor = System.Drawing.Color.Transparent;
            this.uploadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.uploadButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.uploadButton.BorderColor = System.Drawing.Color.Black;
            this.uploadButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.uploadButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.uploadButton.FocusedColor = System.Drawing.Color.Empty;
            this.uploadButton.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadButton.ForeColor = System.Drawing.Color.White;
            this.uploadButton.Image = null;
            this.uploadButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uploadButton.ImageOffsetX = 5;
            this.uploadButton.ImageSize = new System.Drawing.Size(25, 25);
            this.uploadButton.Location = new System.Drawing.Point(16, 4);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.uploadButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.uploadButton.OnHoverForeColor = System.Drawing.Color.White;
            this.uploadButton.OnHoverImage = null;
            this.uploadButton.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.uploadButton.Radius = 15;
            this.uploadButton.Size = new System.Drawing.Size(180, 70);
            this.uploadButton.TabIndex = 9;
            this.uploadButton.Text = "CHOOSE FILE";
            this.uploadButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uploadButton.UseTransfarantBackground = true;
            // 
            // loadingBarImage
            // 
            this.loadingBarImage.BaseColor = System.Drawing.Color.White;
            this.loadingBarImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingBarImage.Image")));
            this.loadingBarImage.Location = new System.Drawing.Point(27, 9);
            this.loadingBarImage.Name = "loadingBarImage";
            this.loadingBarImage.Size = new System.Drawing.Size(62, 58);
            this.loadingBarImage.TabIndex = 10;
            this.loadingBarImage.TabStop = false;
            this.loadingBarImage.Visible = false;
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uploadPanel);
            this.Name = "LoadingScreen";
            this.Size = new System.Drawing.Size(579, 517);
            this.uploadPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingBarImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel uploadPanel;
        private Guna.UI.WinForms.GunaPictureBox loadingBarImage;
        private Guna.UI.WinForms.GunaButton uploadButton;
    }
}
