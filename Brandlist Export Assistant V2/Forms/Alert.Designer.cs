namespace Brandlist_Export_Assistant_V2.Forms
{
    partial class Alert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert));
            this.dismissButton = new Guna.UI.WinForms.GunaButton();
            this.errorMessage = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.errorTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.errorMessagePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.errorMessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dismissButton
            // 
            this.dismissButton.Animated = true;
            this.dismissButton.AnimationHoverSpeed = 2.5F;
            this.dismissButton.AnimationSpeed = 0.03F;
            this.dismissButton.BackColor = System.Drawing.Color.Transparent;
            this.dismissButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dismissButton.BaseColor = System.Drawing.Color.IndianRed;
            this.dismissButton.BorderColor = System.Drawing.Color.Black;
            this.dismissButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.dismissButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dismissButton.FocusedColor = System.Drawing.Color.Empty;
            this.dismissButton.Font = new System.Drawing.Font("Malgun Gothic Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dismissButton.ForeColor = System.Drawing.Color.White;
            this.dismissButton.Image = null;
            this.dismissButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dismissButton.ImageOffsetX = 5;
            this.dismissButton.ImageSize = new System.Drawing.Size(25, 25);
            this.dismissButton.Location = new System.Drawing.Point(181, 353);
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.OnHoverBaseColor = System.Drawing.Color.LightCoral;
            this.dismissButton.OnHoverBorderColor = System.Drawing.Color.LightCoral;
            this.dismissButton.OnHoverForeColor = System.Drawing.Color.White;
            this.dismissButton.OnHoverImage = null;
            this.dismissButton.OnPressedColor = System.Drawing.Color.LightCoral;
            this.dismissButton.Radius = 15;
            this.dismissButton.Size = new System.Drawing.Size(177, 49);
            this.dismissButton.TabIndex = 14;
            this.dismissButton.Text = "DISMISS";
            this.dismissButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dismissButton.UseTransfarantBackground = true;
            this.dismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // errorMessage
            // 
            this.errorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.errorMessage.Font = new System.Drawing.Font("Malgun Gothic Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMessage.ForeColor = System.Drawing.Color.DimGray;
            this.errorMessage.Location = new System.Drawing.Point(3, 3);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(375, 83);
            this.errorMessage.TabIndex = 13;
            this.errorMessage.Text = "Invalid brandlist.";
            this.errorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorTitle
            // 
            this.errorTitle.AutoSize = true;
            this.errorTitle.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(46)))), ((int)(((byte)(78)))));
            this.errorTitle.Location = new System.Drawing.Point(132, 222);
            this.errorTitle.Name = "errorTitle";
            this.errorTitle.Size = new System.Drawing.Size(276, 32);
            this.errorTitle.TabIndex = 12;
            this.errorTitle.Text = "Something went wrong!";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(181, 69);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(177, 141);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 11;
            this.gunaPictureBox1.TabStop = false;
            // 
            // errorMessagePanel
            // 
            this.errorMessagePanel.Controls.Add(this.errorMessage);
            this.errorMessagePanel.Location = new System.Drawing.Point(78, 253);
            this.errorMessagePanel.Name = "errorMessagePanel";
            this.errorMessagePanel.Size = new System.Drawing.Size(381, 94);
            this.errorMessagePanel.TabIndex = 15;
            // 
            // Alert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(511, 425);
            this.ControlBox = false;
            this.Controls.Add(this.errorMessagePanel);
            this.Controls.Add(this.dismissButton);
            this.Controls.Add(this.errorTitle);
            this.Controls.Add(this.gunaPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Alert";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.errorMessagePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaButton dismissButton;
        private Bunifu.Framework.UI.BunifuCustomLabel errorMessage;
        private Bunifu.Framework.UI.BunifuCustomLabel errorTitle;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Panel errorMessagePanel;
    }
}