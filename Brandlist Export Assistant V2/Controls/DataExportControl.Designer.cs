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
            this.loadingBarImage = new Guna.UI.WinForms.GunaPictureBox();
            this.browsePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBarImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // exportDataButton
            // 
            this.exportDataButton.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.exportDataButton.Location = new System.Drawing.Point(199, 237);
            this.exportDataButton.Name = "exportDataButton";
            this.exportDataButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(142)))), ((int)(((byte)(220)))));
            this.exportDataButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(142)))), ((int)(((byte)(220)))));
            this.exportDataButton.OnHoverForeColor = System.Drawing.Color.White;
            this.exportDataButton.OnHoverImage = null;
            this.exportDataButton.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.exportDataButton.OnPressedDepth = 0;
            this.exportDataButton.Radius = 20;
            this.exportDataButton.Size = new System.Drawing.Size(158, 49);
            this.exportDataButton.TabIndex = 4;
            this.exportDataButton.Text = "CHOOSE MDD";
            this.exportDataButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exportDataButton.UseTransfarantBackground = true;
            this.exportDataButton.Click += new System.EventHandler(this.ExportDataButton_Click);
            // 
            // loadingBarImage
            // 
            this.loadingBarImage.BaseColor = System.Drawing.Color.White;
            this.loadingBarImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingBarImage.Image")));
            this.loadingBarImage.Location = new System.Drawing.Point(213, 239);
            this.loadingBarImage.Name = "loadingBarImage";
            this.loadingBarImage.Size = new System.Drawing.Size(48, 45);
            this.loadingBarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingBarImage.TabIndex = 11;
            this.loadingBarImage.TabStop = false;
            this.loadingBarImage.Visible = false;
            // 
            // browsePanel
            // 
            this.browsePanel.BackColor = System.Drawing.Color.Transparent;
            this.browsePanel.Location = new System.Drawing.Point(0, 421);
            this.browsePanel.Name = "browsePanel";
            this.browsePanel.Size = new System.Drawing.Size(185, 72);
            this.browsePanel.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(139, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 313);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // DataExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadingBarImage);
            this.Controls.Add(this.browsePanel);
            this.Controls.Add(this.exportDataButton);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "DataExportControl";
            this.Size = new System.Drawing.Size(579, 517);
            ((System.ComponentModel.ISupportInitialize)(this.loadingBarImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaButton exportDataButton;
        private Guna.UI.WinForms.GunaPictureBox loadingBarImage;
        private System.Windows.Forms.Panel browsePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
