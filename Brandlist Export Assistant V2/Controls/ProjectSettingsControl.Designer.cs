namespace Brandlist_Export_Assistant_V2.Controls
{
    partial class ProjectSettingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectSettingsControl));
            this.etLabel = new Guna.UI.WinForms.GunaLabel();
            this.settingsPanel = new Guna.UI.WinForms.GunaPanel();
            this.pIcon = new Guna.UI.WinForms.GunaPictureBox();
            this.pBox = new Guna.UI.WinForms.GunaComboBox();
            this.pLabel = new Guna.UI.WinForms.GunaLabel();
            this.pmIcon = new Guna.UI.WinForms.GunaPictureBox();
            this.ptIcon = new Guna.UI.WinForms.GunaPictureBox();
            this.pmBox = new Guna.UI.WinForms.GunaComboBox();
            this.pmLabel = new Guna.UI.WinForms.GunaLabel();
            this.ptBox = new Guna.UI.WinForms.GunaComboBox();
            this.ptLabel = new Guna.UI.WinForms.GunaLabel();
            this.etIcon = new Guna.UI.WinForms.GunaPictureBox();
            this.etRRPCheckBox = new Guna.UI.WinForms.GunaCheckBox();
            this.etTBCheckBox = new Guna.UI.WinForms.GunaCheckBox();
            this.rsBox = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.rsPanel = new Guna.UI.WinForms.GunaPanel();
            this.rsIcon = new Guna.UI.WinForms.GunaPictureBox();
            this.tsBox = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.tsPanel = new Guna.UI.WinForms.GunaPanel();
            this.tsIcon = new Guna.UI.WinForms.GunaPictureBox();
            this.nextButton = new Guna.UI.WinForms.GunaButton();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.etIcon)).BeginInit();
            this.rsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rsIcon)).BeginInit();
            this.tsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // etLabel
            // 
            this.etLabel.AutoSize = true;
            this.etLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(68)))));
            this.etLabel.Location = new System.Drawing.Point(32, 93);
            this.etLabel.Name = "etLabel";
            this.etLabel.Size = new System.Drawing.Size(88, 17);
            this.etLabel.TabIndex = 3;
            this.etLabel.Text = "EXPORT TYPE";
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.pIcon);
            this.settingsPanel.Controls.Add(this.pBox);
            this.settingsPanel.Controls.Add(this.pLabel);
            this.settingsPanel.Controls.Add(this.pmIcon);
            this.settingsPanel.Controls.Add(this.ptIcon);
            this.settingsPanel.Controls.Add(this.pmBox);
            this.settingsPanel.Controls.Add(this.pmLabel);
            this.settingsPanel.Controls.Add(this.ptBox);
            this.settingsPanel.Controls.Add(this.ptLabel);
            this.settingsPanel.Controls.Add(this.etIcon);
            this.settingsPanel.Controls.Add(this.etRRPCheckBox);
            this.settingsPanel.Controls.Add(this.etTBCheckBox);
            this.settingsPanel.Controls.Add(this.etLabel);
            this.settingsPanel.Location = new System.Drawing.Point(115, 104);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(344, 148);
            this.settingsPanel.TabIndex = 27;
            // 
            // pIcon
            // 
            this.pIcon.BaseColor = System.Drawing.Color.White;
            this.pIcon.Image = ((System.Drawing.Image)(resources.GetObject("pIcon.Image")));
            this.pIcon.Location = new System.Drawing.Point(320, 41);
            this.pIcon.Name = "pIcon";
            this.pIcon.Size = new System.Drawing.Size(20, 25);
            this.pIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pIcon.TabIndex = 45;
            this.pIcon.TabStop = false;
            // 
            // pBox
            // 
            this.pBox.BackColor = System.Drawing.Color.Transparent;
            this.pBox.BaseColor = System.Drawing.Color.White;
            this.pBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.pBox.BorderSize = 1;
            this.pBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pBox.FocusedColor = System.Drawing.Color.Empty;
            this.pBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pBox.ForeColor = System.Drawing.Color.Black;
            this.pBox.FormattingEnabled = true;
            this.pBox.Items.AddRange(new object[] {
            "Dimensions",
            "iField",
            "Dooblo"});
            this.pBox.Location = new System.Drawing.Point(189, 41);
            this.pBox.Name = "pBox";
            this.pBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.pBox.OnHoverItemForeColor = System.Drawing.Color.White;
            this.pBox.Radius = 6;
            this.pBox.Size = new System.Drawing.Size(128, 26);
            this.pBox.TabIndex = 44;
            this.pBox.SelectedIndexChanged += new System.EventHandler(this.PBox_SelectedIndexChanged);
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(68)))));
            this.pLabel.Location = new System.Drawing.Point(191, 19);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(73, 17);
            this.pLabel.TabIndex = 43;
            this.pLabel.Text = "PLATFORM";
            // 
            // pmIcon
            // 
            this.pmIcon.BaseColor = System.Drawing.Color.White;
            this.pmIcon.Image = ((System.Drawing.Image)(resources.GetObject("pmIcon.Image")));
            this.pmIcon.Location = new System.Drawing.Point(320, 113);
            this.pmIcon.Name = "pmIcon";
            this.pmIcon.Size = new System.Drawing.Size(20, 25);
            this.pmIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pmIcon.TabIndex = 39;
            this.pmIcon.TabStop = false;
            // 
            // ptIcon
            // 
            this.ptIcon.BaseColor = System.Drawing.Color.White;
            this.ptIcon.Image = ((System.Drawing.Image)(resources.GetObject("ptIcon.Image")));
            this.ptIcon.Location = new System.Drawing.Point(150, 41);
            this.ptIcon.Name = "ptIcon";
            this.ptIcon.Size = new System.Drawing.Size(20, 25);
            this.ptIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptIcon.TabIndex = 38;
            this.ptIcon.TabStop = false;
            // 
            // pmBox
            // 
            this.pmBox.BackColor = System.Drawing.Color.Transparent;
            this.pmBox.BaseColor = System.Drawing.Color.White;
            this.pmBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.pmBox.BorderSize = 1;
            this.pmBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pmBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pmBox.FocusedColor = System.Drawing.Color.Empty;
            this.pmBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pmBox.ForeColor = System.Drawing.Color.Black;
            this.pmBox.FormattingEnabled = true;
            this.pmBox.Items.AddRange(new object[] {
            "CAWI",
            "CAPI",
            "CATI"});
            this.pmBox.Location = new System.Drawing.Point(189, 112);
            this.pmBox.Name = "pmBox";
            this.pmBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.pmBox.OnHoverItemForeColor = System.Drawing.Color.White;
            this.pmBox.Radius = 6;
            this.pmBox.Size = new System.Drawing.Size(128, 26);
            this.pmBox.TabIndex = 37;
            // 
            // pmLabel
            // 
            this.pmLabel.AutoSize = true;
            this.pmLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(68)))));
            this.pmLabel.Location = new System.Drawing.Point(191, 93);
            this.pmLabel.Name = "pmLabel";
            this.pmLabel.Size = new System.Drawing.Size(104, 17);
            this.pmLabel.TabIndex = 36;
            this.pmLabel.Text = "METHODOLOGY";
            // 
            // ptBox
            // 
            this.ptBox.BackColor = System.Drawing.Color.Transparent;
            this.ptBox.BaseColor = System.Drawing.Color.White;
            this.ptBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.ptBox.BorderSize = 1;
            this.ptBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ptBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ptBox.FocusedColor = System.Drawing.Color.Empty;
            this.ptBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ptBox.ForeColor = System.Drawing.Color.Black;
            this.ptBox.FormattingEnabled = true;
            this.ptBox.Items.AddRange(new object[] {
            "Tracker",
            "One Tracker",
            "Incidence",
            "Switching Boost"});
            this.ptBox.Location = new System.Drawing.Point(16, 41);
            this.ptBox.Name = "ptBox";
            this.ptBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ptBox.OnHoverItemForeColor = System.Drawing.Color.White;
            this.ptBox.Radius = 6;
            this.ptBox.Size = new System.Drawing.Size(131, 26);
            this.ptBox.TabIndex = 35;
            // 
            // ptLabel
            // 
            this.ptLabel.AutoSize = true;
            this.ptLabel.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(68)))));
            this.ptLabel.Location = new System.Drawing.Point(19, 20);
            this.ptLabel.Name = "ptLabel";
            this.ptLabel.Size = new System.Drawing.Size(93, 17);
            this.ptLabel.TabIndex = 34;
            this.ptLabel.Text = "PROJECT TYPE";
            // 
            // etIcon
            // 
            this.etIcon.BaseColor = System.Drawing.Color.White;
            this.etIcon.Image = ((System.Drawing.Image)(resources.GetObject("etIcon.Image")));
            this.etIcon.Location = new System.Drawing.Point(121, 90);
            this.etIcon.Name = "etIcon";
            this.etIcon.Size = new System.Drawing.Size(20, 25);
            this.etIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.etIcon.TabIndex = 32;
            this.etIcon.TabStop = false;
            // 
            // etRRPCheckBox
            // 
            this.etRRPCheckBox.BaseColor = System.Drawing.Color.White;
            this.etRRPCheckBox.CheckedOffColor = System.Drawing.Color.Gray;
            this.etRRPCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.etRRPCheckBox.FillColor = System.Drawing.Color.White;
            this.etRRPCheckBox.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etRRPCheckBox.Location = new System.Drawing.Point(108, 117);
            this.etRRPCheckBox.Name = "etRRPCheckBox";
            this.etRRPCheckBox.Size = new System.Drawing.Size(66, 20);
            this.etRRPCheckBox.TabIndex = 31;
            this.etRRPCheckBox.Text = "RRP BL";
            this.etRRPCheckBox.CheckedChanged += new System.EventHandler(this.EtRRPCheckBox_CheckedChanged);
            // 
            // etTBCheckBox
            // 
            this.etTBCheckBox.BaseColor = System.Drawing.Color.White;
            this.etTBCheckBox.CheckedOffColor = System.Drawing.Color.Gray;
            this.etTBCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.etTBCheckBox.FillColor = System.Drawing.Color.White;
            this.etTBCheckBox.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etTBCheckBox.Location = new System.Drawing.Point(14, 117);
            this.etTBCheckBox.Name = "etTBCheckBox";
            this.etTBCheckBox.Size = new System.Drawing.Size(89, 20);
            this.etTBCheckBox.TabIndex = 30;
            this.etTBCheckBox.Text = "Tobacco BL";
            this.etTBCheckBox.CheckedChanged += new System.EventHandler(this.EtTBCheckBox_CheckedChanged);
            // 
            // rsBox
            // 
            this.rsBox.BackColor = System.Drawing.Color.Transparent;
            this.rsBox.BaseColor = System.Drawing.Color.White;
            this.rsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.rsBox.BorderSize = 1;
            this.rsBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.rsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rsBox.FocusedColor = System.Drawing.Color.Empty;
            this.rsBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rsBox.ForeColor = System.Drawing.Color.Black;
            this.rsBox.FormattingEnabled = true;
            this.rsBox.Location = new System.Drawing.Point(3, 25);
            this.rsBox.Name = "rsBox";
            this.rsBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.rsBox.OnHoverItemForeColor = System.Drawing.Color.White;
            this.rsBox.Radius = 6;
            this.rsBox.Size = new System.Drawing.Size(187, 26);
            this.rsBox.TabIndex = 50;
            this.rsBox.SelectedIndexChanged += new System.EventHandler(this.RsBox_SelectedIndexChanged);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(68)))));
            this.gunaLabel2.Location = new System.Drawing.Point(10, 5);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(73, 17);
            this.gunaLabel2.TabIndex = 49;
            this.gunaLabel2.Text = "RRP SHEET";
            // 
            // rsPanel
            // 
            this.rsPanel.Controls.Add(this.gunaLabel2);
            this.rsPanel.Controls.Add(this.rsIcon);
            this.rsPanel.Controls.Add(this.rsBox);
            this.rsPanel.Location = new System.Drawing.Point(191, 318);
            this.rsPanel.Name = "rsPanel";
            this.rsPanel.Size = new System.Drawing.Size(230, 58);
            this.rsPanel.TabIndex = 47;
            this.rsPanel.Visible = false;
            // 
            // rsIcon
            // 
            this.rsIcon.BaseColor = System.Drawing.Color.White;
            this.rsIcon.Image = ((System.Drawing.Image)(resources.GetObject("rsIcon.Image")));
            this.rsIcon.Location = new System.Drawing.Point(193, 25);
            this.rsIcon.Name = "rsIcon";
            this.rsIcon.Size = new System.Drawing.Size(20, 25);
            this.rsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rsIcon.TabIndex = 51;
            this.rsIcon.TabStop = false;
            // 
            // tsBox
            // 
            this.tsBox.BackColor = System.Drawing.Color.Transparent;
            this.tsBox.BaseColor = System.Drawing.Color.White;
            this.tsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.tsBox.BorderSize = 1;
            this.tsBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsBox.FocusedColor = System.Drawing.Color.Empty;
            this.tsBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsBox.ForeColor = System.Drawing.Color.Black;
            this.tsBox.FormattingEnabled = true;
            this.tsBox.Location = new System.Drawing.Point(3, 26);
            this.tsBox.Name = "tsBox";
            this.tsBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tsBox.OnHoverItemForeColor = System.Drawing.Color.White;
            this.tsBox.Radius = 6;
            this.tsBox.Size = new System.Drawing.Size(187, 26);
            this.tsBox.TabIndex = 47;
            this.tsBox.SelectedIndexChanged += new System.EventHandler(this.TsBox_SelectedIndexChanged);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(47)))), ((int)(((byte)(68)))));
            this.gunaLabel1.Location = new System.Drawing.Point(10, 10);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(100, 15);
            this.gunaLabel1.TabIndex = 46;
            this.gunaLabel1.Text = "TOBACCO SHEET";
            // 
            // tsPanel
            // 
            this.tsPanel.Controls.Add(this.gunaLabel1);
            this.tsPanel.Controls.Add(this.tsBox);
            this.tsPanel.Controls.Add(this.tsIcon);
            this.tsPanel.Location = new System.Drawing.Point(191, 258);
            this.tsPanel.Name = "tsPanel";
            this.tsPanel.Size = new System.Drawing.Size(230, 58);
            this.tsPanel.TabIndex = 52;
            this.tsPanel.Visible = false;
            // 
            // tsIcon
            // 
            this.tsIcon.BaseColor = System.Drawing.Color.White;
            this.tsIcon.Image = ((System.Drawing.Image)(resources.GetObject("tsIcon.Image")));
            this.tsIcon.Location = new System.Drawing.Point(193, 26);
            this.tsIcon.Name = "tsIcon";
            this.tsIcon.Size = new System.Drawing.Size(20, 25);
            this.tsIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.tsIcon.TabIndex = 48;
            this.tsIcon.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.Animated = true;
            this.nextButton.AnimationHoverSpeed = 0.07F;
            this.nextButton.AnimationSpeed = 0.03F;
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.nextButton.BorderColor = System.Drawing.Color.Black;
            this.nextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.nextButton.FocusedColor = System.Drawing.Color.Empty;
            this.nextButton.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(211)))));
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nextButton.ImageSize = new System.Drawing.Size(15, 15);
            this.nextButton.Location = new System.Drawing.Point(480, 470);
            this.nextButton.Name = "nextButton";
            this.nextButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(46)))), ((int)(((byte)(75)))));
            this.nextButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(142)))), ((int)(((byte)(220)))));
            this.nextButton.OnHoverForeColor = System.Drawing.Color.White;
            this.nextButton.OnHoverImage = null;
            this.nextButton.OnPressedColor = System.Drawing.Color.Black;
            this.nextButton.Radius = 15;
            this.nextButton.Size = new System.Drawing.Size(75, 30);
            this.nextButton.TabIndex = 46;
            this.nextButton.Text = "NEXT";
            this.nextButton.Visible = false;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // ProjectSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rsPanel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.tsPanel);
            this.Controls.Add(this.settingsPanel);
            this.Name = "ProjectSettingsControl";
            this.Size = new System.Drawing.Size(579, 517);
            this.Load += new System.EventHandler(this.ProjectSettingsControl_Load);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.etIcon)).EndInit();
            this.rsPanel.ResumeLayout(false);
            this.rsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rsIcon)).EndInit();
            this.tsPanel.ResumeLayout(false);
            this.tsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaLabel etLabel;
        private Guna.UI.WinForms.GunaPanel settingsPanel;
        private Guna.UI.WinForms.GunaPictureBox pmIcon;
        private Guna.UI.WinForms.GunaPictureBox ptIcon;
        private Guna.UI.WinForms.GunaLabel pmLabel;
        private Guna.UI.WinForms.GunaLabel ptLabel;
        private Guna.UI.WinForms.GunaPictureBox etIcon;
        private Guna.UI.WinForms.GunaPictureBox pIcon;
        private Guna.UI.WinForms.GunaLabel pLabel;
        private Guna.UI.WinForms.GunaButton nextButton;
        private Guna.UI.WinForms.GunaCheckBox etTBCheckBox;
        private Guna.UI.WinForms.GunaCheckBox etRRPCheckBox;
        private Guna.UI.WinForms.GunaComboBox pBox;
        private Guna.UI.WinForms.GunaComboBox pmBox;
        private Guna.UI.WinForms.GunaComboBox ptBox;
        private Guna.UI.WinForms.GunaPictureBox rsIcon;
        private Guna.UI.WinForms.GunaComboBox rsBox;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaPanel rsPanel;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaComboBox tsBox;
        private Guna.UI.WinForms.GunaPictureBox tsIcon;
        private Guna.UI.WinForms.GunaPanel tsPanel;
    }
}
