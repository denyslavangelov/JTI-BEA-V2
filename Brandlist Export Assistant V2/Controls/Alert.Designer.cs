namespace Brandlist_Export_Assistant_V2.Controls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert));
            this.errorTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.errorMessage = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dismissButton = new Guna.UI.WinForms.GunaButton();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorTitle
            // 
            this.errorTitle.AutoSize = true;
            this.errorTitle.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(46)))), ((int)(((byte)(78)))));
            this.errorTitle.Location = new System.Drawing.Point(148, 303);
            this.errorTitle.Name = "errorTitle";
            this.errorTitle.Size = new System.Drawing.Size(276, 32);
            this.errorTitle.TabIndex = 3;
            this.errorTitle.Text = "Something went wrong!";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(163, 91);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(249, 204);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMessage.ForeColor = System.Drawing.Color.DimGray;
            this.errorMessage.Location = new System.Drawing.Point(207, 346);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(154, 25);
            this.errorMessage.TabIndex = 4;
            this.errorMessage.Text = "Invalid brandlist.";
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
            this.dismissButton.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dismissButton.ForeColor = System.Drawing.Color.White;
            this.dismissButton.Image = null;
            this.dismissButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dismissButton.ImageOffsetX = 5;
            this.dismissButton.ImageSize = new System.Drawing.Size(25, 25);
            this.dismissButton.Location = new System.Drawing.Point(192, 388);
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.dismissButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.dismissButton.OnHoverForeColor = System.Drawing.Color.White;
            this.dismissButton.OnHoverImage = null;
            this.dismissButton.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.dismissButton.Radius = 15;
            this.dismissButton.Size = new System.Drawing.Size(180, 53);
            this.dismissButton.TabIndex = 10;
            this.dismissButton.Text = "DISMISS";
            this.dismissButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dismissButton.UseTransfarantBackground = true;
            this.dismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dismissButton);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.errorTitle);
            this.Controls.Add(this.gunaPictureBox1);
            this.Name = "Alert";
            this.Size = new System.Drawing.Size(579, 517);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel errorTitle;
        private Bunifu.Framework.UI.BunifuCustomLabel errorMessage;
        private Guna.UI.WinForms.GunaButton dismissButton;
    }
}
