﻿using System;
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
    public partial class TobaccoSelectionControl : UserControl
    {
        public event EventHandler IndexChanged;

        public TobaccoSheet TobaccoSheet { get; set; }

        public MainForm MainForm { get; set; }

        public string ControlGlobalLabel => glcBox.Text;

        public string ControlLocalLabel => llcBox.Text;

        public string ControlSecondLocalLabel => sllcBox.Text;

        public string ControlCustomProperty => cpcBox.Text;

        public int GreenIconsCount { get; set; }

        public int FieldsToFillCount { get; set; } = 4;

        public TobaccoSelectionControl(TobaccoSheet tobaccoSheet, MainForm mainForm)
        {
            InitializeComponent();

            Visible = true;
            Location = new Point(323, 115);
            Size = new Size(579, 524);

            TobaccoSheet = tobaccoSheet;
            MainForm = mainForm;
        }

        private void SetBoxItems()
        {
            var headers = TobaccoSheet.Data.Keys.SelectMany(x => x.Values).ToArray();

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
                switch (box.Name)
                {
                    case "tccBox":
                        box.SelectedIndex = TobaccoSheet.TrackerCodeColumnIndex != 0 ? box.FindStringExact(@"Tracker 2.0 Code") : 0;
                        break;
                    case "glcBox":
                        box.SelectedIndex = TobaccoSheet.GlobalLabelColumnIndex != 0 ? box.FindStringExact(@"Label in English (Translated Questionnaire label)") : 0;
                        break;
                    case "llcBox":
                        box.SelectedIndex = TobaccoSheet.LocalLabelColumnIndex != 0 ? box.FindStringExact(@"Local Label in local language A (Questionnaire label)") : 0;
                        break;
                }
            }

            snBox.Items.Add(TobaccoSheet.SheetName);
            snBox.Text = TobaccoSheet.SheetName;
        }

        private static void UpdateIcon(Control instance, string instanceName, Control panel)
        {
            var icon = (GunaPictureBox)panel.Controls[instanceName.Replace("Box", "") + "Icon"];

            if (instance.Text.Length > 1)
            {
                if (icon.Tag != null)
                {
                    return;
                }

                icon.Image = Properties.Resources.green;
                icon.Tag = "Green";
            }
            else
            {
                icon.Image = Properties.Resources.yellow;
                icon.Tag = null;
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

        private void ColumnSelectionTobacco_Load(object sender, EventArgs e)
        {
            asslSwitchPanel.Location = new Point(36, 352);
            ecpSwitchPanel.Location = new Point(36, 419);

            SetBoxItems();

            nextButton.Visible = GreenIconsCount >= FieldsToFillCount ? true : false;
        }

        private void NextButton_Visibility(object sender, EventArgs e)
        {
            GreenIconsCount = 0;

            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                foreach (GunaPictureBox icon in panel.Controls.OfType<GunaPictureBox>())
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

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (this.asllSwitch.Checked)
            {
                ProjectSettings.TobaccoSecondLocalExported = true;
            }

            if (this.ecpSwitch.Checked)
            {
                ProjectSettings.TobaccoCustomPropertyExported = true;
            }

            MainForm.UpdateStage(Stages.RRPSelection);
        }
    }
}
