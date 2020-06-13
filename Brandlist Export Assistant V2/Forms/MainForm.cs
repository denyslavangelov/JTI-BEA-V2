using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Brandlist_Export_Assistant_V2.Classes.Sheet_Classes;
using Brandlist_Export_Assistant_V2.Controls;

namespace Brandlist_Export_Assistant_V2.Forms
{
    public partial class MainForm : Form
    {
        public Excel Excel { get; private set; }
        public TobaccoSheet TobaccoSheet { get; private set; }
        public RRPSheet RRPSheet { get; private set; }
        public TobaccoBrandlist TobaccoBrandlist { get; private set; }
        public RRPBrandlist RrpBrandlist { get; private set; }

        public ProjectSettingsControl SettingsControl { get; private set; }
        public TobaccoSelectionControl SelectionControl { get; private set; }
        public RRPSelectionControl RRPSelectionControl { get; private set; }
        public DataExportControl FinalExportControl { get; private set; }

        public LoadingScreen LoadingScreen { get; }

        public Color GreenIndicator { get; } = ColorTranslator.FromHtml("#57B894");
        public Color LowOpacityLabel { get; } = ColorTranslator.FromHtml("#646577");
        public Color HighOpacityLabel { get; } = ColorTranslator.FromHtml("#C5C7D3");

        public Stages CurrentStage { get; set; }

        public MainForm()
        {
            InitializeComponent();

            LoadingScreen = new LoadingScreen();

            CurrentStage = Stages.LoadBrandlist;
        }

        public void UpdateColumnIconsEvent(object sender, EventArgs e)
        {
            UpdateColumnSelectionIcons();
        }

        private void UpdateColumnSelectionIcons()
        {
            if (SelectionControl != null) {
                if (SelectionControl.Visible)
                {
                    if (SelectionControl.GreenIconsCount >= SelectionControl.FieldsToFillCount)
                    {
                        tbIcon.Image = Properties.Resources.green;
                        tbIcon.Tag = "Green";
                    }
                    else
                    {
                        tbIcon.Image = Properties.Resources.yellow;
                        tbIcon.Tag = null;
                    }
                }
            }

            if (RRPSelectionControl != null && RRPSelectionControl.Visible)
            {
                if (RRPSelectionControl.GreenIconsCount >= RRPSelectionControl.FieldsToFillCount)
                {
                    rbIcon.Image = Properties.Resources.green;
                    rbIcon.Tag = "Green";
                }
                else
                {
                    rbIcon.Image = Properties.Resources.yellow;
                    rbIcon.Tag = null;
                }
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (!loadingBarImage.Visible)
            {
                var fileDialog = new OpenFileDialog
                {
                    Filter = @"Excel | *.xlsx", FilterIndex = 0, RestoreDirectory = true
                };

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    uploadPanel.Hide();

                    this.LoadingScreen.Show(this, this,"LOADING");

                    OpenBrandlist(fileDialog);
                }
            }
        }

        private async void OpenBrandlist(OpenFileDialog fileDialog)
        {
            await OpenBrandlistAsync(fileDialog);

            UpdateStage(Stages.ProjectSettings);

            this.LoadingScreen.Hide(this, this);
        }

        public async Task OpenBrandlistAsync(OpenFileDialog fileDialog)
        {
            await Task.Run(() => { Excel = new Excel(fileDialog.FileName); });
        }

        #region Update Stages and Next Button

        private void UpdateStagesVisualization(Stages currentStage)
        {
            switch (currentStage)
            {
                case Stages.ProjectSettings:
                    uploadPanel.Visible = false;

                    lbIndicator.BackColor = GreenIndicator;
                    lbLabel.ForeColor = LowOpacityLabel;
                    lbIcon.Image = Properties.Resources.upload_low_op;

                    psIndicator.Visible = true;
                    psLabel.ForeColor = HighOpacityLabel;
                    psIcon.Image = Properties.Resources.settings_high_op;

                    currentStageLabel.Text = @"SETTINGS";
                    break;
                case Stages.TobaccoSelection:
                case Stages.RRPSelection:
                    psIndicator.BackColor = GreenIndicator;
                    psLabel.ForeColor = LowOpacityLabel;
                    psIcon.Image = Properties.Resources.settings_low_op;

                    csIndicator.Visible = true;
                    csLabel.ForeColor = HighOpacityLabel;
                    csIcon.Image = Properties.Resources.select_high_op;

                    currentStageLabel.Text = @"SELECTION";
                    break;
                case Stages.Import:
                    csIndicator.BackColor = GreenIndicator;
                    csLabel.ForeColor = LowOpacityLabel;
                    csIcon.Image = Properties.Resources.select_low_op;

                    iIndicator.Visible = true;
                    iLabel.ForeColor = HighOpacityLabel;
                    iIcon.Image = Properties.Resources.export_high_op;

                    currentStageLabel.Text = @"EXPORT";
                    break;
                case Stages.Final:
                    iIndicator.Visible = true;
                    iLabel.ForeColor = LowOpacityLabel;
                    iIcon.Image = Properties.Resources.export_low_op;
                    iIndicator.BackColor = GreenIndicator;

                    currentStageLabel.Text = @"EXPORT";
                    break;
            }
        }

        public async void UpdateStage(Stages nextStage)
        {
            switch (nextStage)
            {
                case Stages.ProjectSettings:
                    CurrentStage = Stages.ProjectSettings;

                    SettingsControl = new ProjectSettingsControl(this, Excel);
                    this.Controls.Add(SettingsControl);

                    UpdateStagesVisualization(CurrentStage);
                    break;
                case Stages.TobaccoSelection:
                    CurrentStage = Stages.TobaccoSelection;

                    this.Controls.Remove((SettingsControl));

                    if (ProjectSettings.TobaccoExport)
                    {
                        this.LoadingScreen.Show(this, this,"LOADING");

                        await TobaccoSelectionSetupAsync();

                        if (!ProjectSettings.RRPExport)
                        {
                            this.tbPanel.Location = new Point(224, 3);
                            this.rbPanel.Visible = false;
                        }

                        this.LoadingScreen.Hide(this, this);

                        this.Controls.Add(SelectionControl);

                        ShowCurrentControl(SelectionControl, RRPSelectionControl);
                    }

                    columnSelectionPanel.Visible = true;

                    UpdateColumnSelectionIcons();
                    UpdateStagesVisualization(CurrentStage);
                    break;
                case Stages.RRPSelection:
                    CurrentStage = Stages.RRPSelection;

                    this.Controls.Remove(SettingsControl);

                    if (ProjectSettings.RRPExport)
                    {
                        this.LoadingScreen.Show(this, this,"LOADING");

                        await RRPSelectionSetupAsync();

                        if (!ProjectSettings.TobaccoExport)
                        {
                            this.rbPanel.Location = new System.Drawing.Point(224, 3);
                            this.tbPanel.Visible = false;
                        }

                        this.LoadingScreen.Hide(this,this);

                        this.Controls.Add(RRPSelectionControl);
                        this.rbIndicator.Visible = true;

                        rbLabel.ForeColor = ColorTranslator.FromHtml("#302F44");

                        columnSelectionPanel.Visible = true;

                        UpdateColumnSelectionIcons();
                        ShowCurrentControl(RRPSelectionControl, SelectionControl);
                    } 
                    else
                    {
                        UpdateStage(Stages.Import);
                    }

                    UpdateStagesVisualization(CurrentStage);
                    break;
                case Stages.Import:
                    Excel.ExcelApplication.Quit();

                    CurrentStage = Stages.Import;

                    if (SelectionControl != null)
                    {
                        this.Controls.Remove(SelectionControl);

                        TobaccoBrandlist = new TobaccoBrandlist()
                        {
                            ExportCustomProperty = SelectionControl.ecpSwitch.Checked
                        };

                        TobaccoBrandlist.PopulateBrands(TobaccoSheet, SelectionControl);
                    }

                    if (RRPSelectionControl != null)
                    {
                        this.Controls.Remove(RRPSelectionControl);

                        RrpBrandlist = new RRPBrandlist();
                        RrpBrandlist.PopulateBrands(RRPSheet, RRPSelectionControl);
                    }

                    FinalExportControl = new DataExportControl(this,TobaccoBrandlist, RrpBrandlist, SettingsControl);
                    this.Controls.Add(FinalExportControl);

                    columnSelectionPanel.Visible = false;

                    UpdateStagesVisualization(CurrentStage);
                    break;
                case Stages.Final:
                    CurrentStage = Stages.Final;

                    UpdateStagesVisualization(CurrentStage);
                    break;
            }
        }

        public void TobaccoSelectionSetup()
        {
            TobaccoSheet = new TobaccoSheet(Excel, ProjectSettings.TobaccoSheetName);
            SelectionControl = new TobaccoSelectionControl(TobaccoSheet, this);
        }

        public void RRPSelectionSetup()
        {
            RRPSheet = new RRPSheet(Excel, ProjectSettings.RRPSheetName);
            RRPSelectionControl = new RRPSelectionControl(RRPSheet, this);
        }
        public async Task RRPSelectionSetupAsync()
        {
            await Task.Run(RRPSelectionSetup);
        }

        public async Task TobaccoSelectionSetupAsync()
        {
            await Task.Run(TobaccoSelectionSetup);
        }
        #endregion

        #region ColumnSelectionPanels

        public void ShowCurrentControl(Control currentControl, Control previousControl)
        {
            string currentControlInitials;
            string previousControlInitials;

            if (currentControl.Name == "TobaccoSelectionControl")
            {
                currentControlInitials = "tb";
                previousControlInitials = "rb";
            }
            else
            {
                currentControlInitials = "rb";
                previousControlInitials = "tb";
            }

            var currentIndicator = this.Controls["columnSelectionPanel"].Controls[currentControlInitials + "Panel"].Controls[currentControlInitials + "Indicator"];
            var previousIndicator = this.Controls["columnSelectionPanel"].Controls[previousControlInitials + "Panel"].Controls[previousControlInitials + "Indicator"];

            currentIndicator.Visible = true;
            previousIndicator.Visible = false;

            this.Controls["columnSelectionPanel"].Controls[currentControlInitials + "Panel"].Controls[currentControlInitials + "Label"].ForeColor = ColorTranslator.FromHtml("#302F44");
            this.Controls["columnSelectionPanel"].Controls[previousControlInitials + "Panel"].Controls[previousControlInitials + "Label"].ForeColor = LowOpacityLabel;

            currentControl.Visible = true;

            if (previousControl != null)
            {
                previousControl.Visible = false;
            }
        }
        #endregion

        #region Close and Minimize Buttons
        protected void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Excel != null && Excel.ExcelApplication.Worksheets.Count > 0)
                {
                    Excel.ExcelApplication.Quit();
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void GunaTransfarantPictureBox2_Click(object sender, EventArgs e)
        {
            Alert.Show($"The sub brand named CHESTERFIELD doesn't have a main brand.", Stages.LoadBrandlist);
        }
    }
}
