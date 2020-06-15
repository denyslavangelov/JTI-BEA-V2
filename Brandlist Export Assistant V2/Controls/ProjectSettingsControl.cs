using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Sheet_Classes;
using Brandlist_Export_Assistant_V2.Enums;
using Brandlist_Export_Assistant_V2.Forms;
using Guna.UI.WinForms;
using Microsoft.Office.Interop.Excel;

namespace Brandlist_Export_Assistant_V2.Controls
{
    public partial class ProjectSettingsControl : UserControl
    {
        public event EventHandler IndexChanged;
        public event EventHandler SwitchClicked;

        private MainForm MainForm { get; set; }

        private Excel Excel { get; }

        private int GreenIconsCount { get; set; }

        private int FieldsToFillCount { get; set; } = 4;

        public Platform Platform { get; set; }

        public ProjectSettingsControl(MainForm mainForm, Excel excel)
        {
            InitializeComponent();

            this.MainForm = mainForm;
            this.Excel = excel;

            Visible = true;

            Location = new System.Drawing.Point(323, 115);
            Size = new Size(579, 524);

            foreach (Worksheet sheet in this.Excel.AllWorksheets)
            {
                if (this.Excel.Worksheets.Any(s => sheet.Name.Contains(s)))
                {
                    tsBox.Items.Add(sheet.Name);
                    rsBox.Items.Add(sheet.Name);
                }
            }
        }

        private void NextButton_Visibility(object sender, EventArgs e)
        {
            GreenIconsCount = 0;

            foreach (var panel in this.Controls.OfType<GunaPanel>())
            {
                foreach (var icon in panel.Controls.OfType<GunaPictureBox>())
                {
                    #pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                    if (icon.Tag == "Green")
                    {
                        GreenIconsCount++;
                    }
                }
            }

            nextButton.Visible = GreenIconsCount >= FieldsToFillCount ? true : false;
        }

        private void AttachIndexChangedEvent()
        {
            this.SwitchClicked += NextButton_Visibility;
            this.IndexChanged += NextButton_Visibility;

            foreach (var panel in this.Controls.OfType<GunaPanel>())
            {
                foreach (var comboBox in panel.Controls.OfType<GunaComboBox>())
                {
                    comboBox.SelectedIndexChanged += (sender, eventArgs) => {
                        var instance = (GunaComboBox)sender;
                        var instanceName = instance.Name;

                        UpdateIconComboBox(instance, instanceName, panel);

                        IndexChanged?.Invoke(this, eventArgs);
                    };
                }

                foreach (var comboBox in panel.Controls.OfType<GunaCheckBox>())
                {
                    comboBox.CheckedChanged += (sender, eventArgs) => {
                        var instance = (GunaCheckBox)sender;
                        var instanceName = instance.Name;

                        UpdateIconCheckBox(instanceName);

                        SwitchClicked?.Invoke(this, eventArgs);
                    };
                }
            }
        }

        private static void UpdateIconComboBox(Control instance, string instanceName, Control panel)
        {
            var icon = (GunaPictureBox)panel.Controls[instanceName.Replace("Box", "") + "Icon"];

            if (instance.Text.Length > 1)
            {
                icon.Image = Properties.Resources.green;
                icon.Tag = "Green";
            }
            else
            {
                icon.Image = Properties.Resources.yellow;
                icon.Tag = null;
            }
        }

        private void UpdateIconCheckBox(string instanceName)
        {
            var icon = (GunaPictureBox)settingsPanel.Controls[instanceName.Substring(0, 2) + "Icon"];

            if (etTBCheckBox.Checked || etRRPCheckBox.Checked)
            {
                icon.Image = Properties.Resources.green;
                icon.Tag = "Green";
            }
            else
            {
                icon.Image = Properties.Resources.yellow;
                icon.Tag = null;
            }
        }

        private void SetItems()
        {
            AttachIndexChangedEvent();
        }

        private void ProjectSettingsControl_Load(object sender, EventArgs e)
        {
            SetItems();
        }

        private void PBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (pBox.Text)
            {
                case "Dimensions":
                    Platform = Platform.Dimensions;
                    break;
                case "iField":
                    Platform = Platform.iField;
                    break;
                case "Dooblo":
                    Platform = Platform.Dooblo;
                    break;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var rrpExportBoolean = this.etRRPCheckBox.Checked;
            var tobaccoExportBoolean = this.etTBCheckBox.Checked;

            Methodology methodology = 0;

            switch (this.pmBox.Text)
            {
                case "CAWI":
                    methodology = Methodology.CAWI;
                    break;
                case "CAPI":
                    methodology = Methodology.CAPI;
                    break;
                case "CATI":
                    methodology = Methodology.CATI;
                    break;
            }

            ProjectType projectType = 0;

            switch (this.ptBox.Text)
            {
                case "One Tracker":
                    projectType = ProjectType.OneTracker;
                    break;
                case "Tracker":
                    projectType = ProjectType.Tracker;
                    break;
                case "Incidence":
                    projectType = ProjectType.Incidence;
                    break;
                case "SwitchingBoost":
                    projectType = ProjectType.SwitchingBoost;
                    break;
            }

            Platform platform = 0;

            switch (this.pBox.Text)
            {
                case "Dimensions":
                    platform = Platform.Dimensions;
                    break;
                case "iField":
                    platform = Platform.iField;
                    break;
                case "Dooblo":
                    platform = Platform.Dooblo;
                    break;
            }

            ProjectSettings.SetProjectSettings(rrpExportBoolean, tobaccoExportBoolean, methodology, projectType, platform, this.tsBox.Text, this.rsBox.Text);

            if (ProjectSettings.TobaccoExport || (ProjectSettings.TobaccoExport && ProjectSettings.RRPExport))
            {
                MainForm.UpdateStage(Stages.TobaccoSelection);
            }

            if (!ProjectSettings.TobaccoExport && ProjectSettings.RRPExport)
            {
                MainForm.UpdateStage(Stages.RRPSelection);
            }
        }

        private void EtTBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (etTBCheckBox.Checked && !rsPanel.Visible)
            {
                tsPanel.Location = new System.Drawing.Point(185, 260);
                rsPanel.Location = new System.Drawing.Point(185, 320);
            }

            if (etTBCheckBox.Checked)
            {
                tsPanel.Location = rsPanel.Location == new System.Drawing.Point(185, 260) ? new System.Drawing.Point(185, 320) : new System.Drawing.Point(185, 260);
                tsPanel.Show();

                FieldsToFillCount++;
            }
            else
            {
                tsPanel.Hide();
                FieldsToFillCount--;
            }

            if (!etTBCheckBox.Checked && (tsPanel.Location == new System.Drawing.Point(185, 260)))
            {
                rsPanel.Location = new System.Drawing.Point(185, 260);
            }

            if (etTBCheckBox.Checked && Excel.WorksheetsCount == 1)
            {
                etRRPCheckBox.Checked = false;
            }
        }

        private void EtRRPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (etRRPCheckBox.Checked && !tsBox.Visible)
            {
                rsPanel.Location = new System.Drawing.Point(185, 260);
                tsPanel.Location = new System.Drawing.Point(185, 320);
            }

            if (etRRPCheckBox.Checked)
            {
                rsPanel.Location = tsPanel.Location == new System.Drawing.Point(185, 260) ? new System.Drawing.Point(185, 320) : new System.Drawing.Point(185, 260);
                rsPanel.Show();
                FieldsToFillCount++;
            }
            else
            {
                rsPanel.Hide();
                FieldsToFillCount--;
            }

            if (!etRRPCheckBox.Checked && (rsPanel.Location == new System.Drawing.Point(185, 260)))
            {
                tsPanel.Location = new System.Drawing.Point(185, 260);
            }

            if (etRRPCheckBox.Checked && Excel.WorksheetsCount == 1)
            {
                etTBCheckBox.Checked = false;
            }
        }

        private void TsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsBox.Text == rsBox.Text)
            {
                rsBox.SelectedItem = null;
            }
            
        }

        private void RsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsBox.Text == rsBox.Text)
            {
                tsBox.SelectedItem = null;
            }
        }
    }
}
