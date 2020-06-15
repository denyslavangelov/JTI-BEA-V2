using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Sheet_Classes;
using Brandlist_Export_Assistant_V2.Forms;
using Guna.UI.WinForms;

namespace Brandlist_Export_Assistant_V2.Controls
{
    public partial class RRPSelectionControl : UserControl
    {
        public event EventHandler IndexChanged;

        public RRPSheet RRPSheet { get; set; }
        public MainForm MainForm { get; set; }

        public string ControlGlobalLabel => glcBox.Text;

        public string ControlLocalLabel => llcBox.Text;

        public string ControlSecondLocalLabel => sllcBox.Text;

        public string ControlCustomProperty => cpcBox.Text;

        public int GreenIconsCount { get; set; }

        public int FieldsToFillCount { get; set; } = 4;

        public RRPSelectionControl(RRPSheet rrpSheet, MainForm mainForm)
        {
            InitializeComponent();

            Visible = true;
            Location = new Point(323, 115);
            Size = new Size(579, 524);

            RRPSheet = rrpSheet;
            MainForm = mainForm;
        }

        private static void UpdateIcon(GunaComboBox instance, string instanceName, Panel panel)
        {
            var icon = (GunaPictureBox)panel.Controls[instanceName.Replace("Box", "") + "Icon"];

            if (instance.Text.Length > 1)
            {
                icon.Tag = "Green";
                icon.Image = Properties.Resources.green;
            }
            else
            {
                icon.Tag = null;
                icon.Image = Properties.Resources.yellow;
            }
        }

        private void SetItems()
        {
            var headers = RRPSheet.Data.Keys.SelectMany(x => x.Values).ToArray();

            const string emptyColumn = "Please select a column.";

            var comboBoxes = new List<GunaComboBox>
            {
                tccBox,
                glcBox,
                llcBox,
                sllcBox,
                cpcBox
            };

            foreach (var column in headers)
            {
                if (column == null) continue;

                comboBoxes.ForEach(x => x.Items.Add(column));
            }

            AttachIndexChangedEvent();

            foreach (var box in comboBoxes)
            {
                box.SelectedText = emptyColumn;

                switch (box.Name)
                {
                    case "tccBox":
                        box.SelectedIndex = RRPSheet.TrackerCodeColumnIndex != 0 ? box.FindStringExact(@"Tracker 2.0 Code") : 0;
                        break;
                    case "glcBox":
                        box.SelectedIndex = RRPSheet.GlobalLabelColumnIndex != 0 ? box.FindStringExact(@"Label in English (Translated Questionnaire label)") : 0;
                        break;
                    case "llcBox":
                        box.SelectedIndex = RRPSheet.LocalLabelColumnIndex != 0 ? box.FindStringExact(@"Local Label in local language A (Questionnaire label)") : 0;
                        break;
                }
            }

            snBox.Items.Add(RRPSheet.Sheet.Name);
            snBox.Text = RRPSheet.Sheet.Name;
        }

        private void AttachIndexChangedEvent()
        {
            this.IndexChanged += MainForm.UpdateColumnIconsEvent;
            this.IndexChanged += NextButton_Visibility;

            foreach (var panel in this.Controls.OfType<Panel>())
            {
                foreach (var comboBox in panel.Controls.OfType<GunaComboBox>())
                {
                    comboBox.SelectedIndexChanged += (sender, eventArgs) => {
                        var instance = (GunaComboBox)sender;
                        var instanceName = instance.Name;

                        UpdateIcon(instance, instanceName, panel);

                        IndexChanged?.Invoke(this, eventArgs);
                    };
                }
            }
        }

        private void AsllSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (asllSwitch.Checked)
            {
                sllcPanel.Visible = true;
                this.FieldsToFillCount++;
                asslSwitchPanel.Location = new Point(332, 352);
            }
            else
            {
                sllcPanel.Visible = false;
                this.FieldsToFillCount--;
                asslSwitchPanel.Location = new Point(36, 352);
            }

            IndexChanged?.Invoke(this, e);
        }

        private void EcpSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (ecpSwitch.Checked)
            {
                cpcPanel.Visible = true;
                this.FieldsToFillCount++;
                ecpSwitchPanel.Location = new Point(328, 419);
            }
            else
            {
                cpcPanel.Visible = false;
                this.FieldsToFillCount--;
                ecpSwitchPanel.Location = new Point(36, 419);
            }

            IndexChanged?.Invoke(this, e);
        }

        private void ColumnSelectionRRP_Load(object sender, EventArgs e)
        {
            SetItems();

            asslSwitchPanel.Location = new Point(36, 352);
            ecpSwitchPanel.Location = new Point(36, 419);
        }

        private void NextButton_Visibility(object sender, EventArgs e)
        {
            GreenIconsCount = 0;

            foreach (var panel in this.Controls.OfType<Panel>())
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

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (this.asllSwitch.Checked)
            {
                ProjectSettings.RRPSecondLocalExported = true;
            }

            if (this.ecpSwitch.Checked)
            {
                ProjectSettings.RRPCustomPropertyExported = true;
            }

            MainForm.UpdateStage(Stages.Import);
        }
    }
}
