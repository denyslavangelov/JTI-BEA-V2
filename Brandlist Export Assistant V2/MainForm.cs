using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brandlist_Export_Assistant.Classes;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Guna.UI.WinForms;

namespace Brandlist_Export_Assistant_V2
{
    public partial class MainForm : Form
    {
        private Excel excel;
        private TobaccoSheet tobaccoSheet;
        private RRPSheet rrpSheet;

        private TobaccoBrandlist tobaccoBrandlist;
        private RRPBrandlist rrpBrandlist;

        private ProjectSettingsControl projectSettingsControl;
        private TobaccoSelectionControl tobaccoSelectionControl;
        private RRPSelectionControl RRPSelectionControl;
        private DataExportControl finalExportControl;
        
        private readonly Color GreenIndicator = ColorTranslator.FromHtml("#57B894");
        private readonly Color LowOpacityLabel = ColorTranslator.FromHtml("#646577");
        private readonly Color HighOpacityLabel = ColorTranslator.FromHtml("#C5C7D3");

        public Stages CurrentStage { get; set; }

        public MainForm()
        {
            InitializeComponent();

            CurrentStage = Stages.LoadBrandlist;
        }

        public void UpdateColumnIconsEvent(object sender, EventArgs e)
        {
            UpdateColumnSelectionIcons();
        }

        private void UpdateColumnSelectionIcons()
        {
            if (tobaccoSelectionControl != null) {
                if (tobaccoSelectionControl.Visible)
                {
                    if (tobaccoSelectionControl.GreenIconsCount >= tobaccoSelectionControl.FieldsToFillCount)
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

            if (RRPSelectionControl != null)
            {
                if (RRPSelectionControl.Visible)
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
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (!loadingBarImage.Visible)
            {
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Filter = "Excel | *.xlsx",
                    FilterIndex = 0,
                    RestoreDirectory = true
                };

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    SetLoadingScreen(fileDialog);
                }
            }
        }

        private async void SetLoadingScreen(OpenFileDialog fileDialog)
        {
            LoadingButton(uploadButton);

            await ExecuteAsync(fileDialog);

            UpdateStage(Stages.ProjectSettings);
        }

        public async Task ExecuteAsync(OpenFileDialog fileDialog)
        {
            await Task.Run(() => {
                excel = new Excel(fileDialog.FileName);
            });
        }

        private void LoadingButton(GunaButton uploadButton)
        {
            uploadButton.BorderColor = ColorTranslator.FromHtml("#3D4853");
            uploadButton.ForeColor = ColorTranslator.FromHtml("#3D4853");
            uploadButton.BorderSize = 4;

            uploadButton.BaseColor = Color.Transparent;
            uploadButton.OnHoverBaseColor = Color.Transparent;
            uploadButton.OnHoverBorderColor = ColorTranslator.FromHtml("#3D4853");
            uploadButton.OnHoverForeColor = ColorTranslator.FromHtml("#3D4853");
            uploadButton.OnHoverImage = null;
            uploadButton.Image = null;
            uploadButton.TextOffsetX = 25;
            uploadButton.TextAlign = HorizontalAlignment.Right;

            loadingBarImage.Visible = true;

            uploadButton.Text = "LOADING";
        }

        #region Update Stages and Next Button

        private void NextButton_Click(object sender, EventArgs e)
        {
            switch (CurrentStage)
            {
                case Stages.LoadBrandlist:
                    UpdateStage(Stages.ProjectSettings);
                    break;
                case Stages.ProjectSettings:
                    UpdateStage(Stages.ColumnSelection);
                    break;
                case Stages.ColumnSelection:
                    UpdateStage(Stages.Import);
                    break;
            }
        }

        private void UpdateStagesVisualzation(Stages currentStage)
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

                    currentStageLabel.Text = "SETTINGS";
                    break;
                case Stages.TobaccoSelection:
                case Stages.RRPSelection:
                    psIndicator.BackColor = GreenIndicator;
                    psLabel.ForeColor = LowOpacityLabel;
                    psIcon.Image = Properties.Resources.settings_low_op;

                    csIndicator.Visible = true;
                    csLabel.ForeColor = HighOpacityLabel;
                    csIcon.Image = Properties.Resources.select_high_op;

                    currentStageLabel.Text = "SELECTION";
                    break;
                case Stages.Import:
                    csIndicator.BackColor = GreenIndicator;
                    csLabel.ForeColor = LowOpacityLabel;
                    csIcon.Image = Properties.Resources.select_low_op;

                    iIndicator.Visible = true;
                    iLabel.ForeColor = HighOpacityLabel;
                    iIcon.Image = Properties.Resources.export_high_op;

                    currentStageLabel.Text = "EXPORT";
                    break;
                case Stages.Final:
                    iIndicator.Visible = true;
                    iLabel.ForeColor = LowOpacityLabel;
                    iIcon.Image = Properties.Resources.export_low_op;
                    iIndicator.BackColor = GreenIndicator;

                    currentStageLabel.Text = "EXPORT";
                    break;
            }
        }

        public void UpdateStage(Stages nextStage)
        {
            switch (nextStage)
            {
                case Stages.ProjectSettings:
                    CurrentStage = Stages.ProjectSettings;

                    projectSettingsControl = new ProjectSettingsControl(this, excel);
                    this.Controls.Add(projectSettingsControl);

                    UpdateStagesVisualzation(CurrentStage);

                    uploadButton.Visible = false;
                    break;
                case Stages.TobaccoSelection:
                    CurrentStage = Stages.TobaccoSelection;

                    this.Controls.Remove(projectSettingsControl);

                    if (ProjectSettings.TobaccoExport)
                    {
                        tobaccoSheet = new TobaccoSheet(excel, ProjectSettings.TobaccoSheetName);
                        tobaccoSelectionControl = new TobaccoSelectionControl(tobaccoSheet, this);

                        if (!ProjectSettings.RRPExport)
                        {
                            this.tbPanel.Location = new Point(224, 3);
                            this.rbPanel.Visible = false;
                        }

                        this.Controls.Add(tobaccoSelectionControl);

                        ShowCurrenctControl(tobaccoSelectionControl, RRPSelectionControl);
                    }

                    columnSelectionPanel.Visible = true;

                    UpdateColumnSelectionIcons();
                    UpdateStagesVisualzation(CurrentStage);
                    break;
                case Stages.RRPSelection:
                    CurrentStage = Stages.RRPSelection;

                    this.Controls.Remove(projectSettingsControl);

                    if (ProjectSettings.RRPExport)
                    {
                        rrpSheet = new RRPSheet(excel, ProjectSettings.RRPSheetName);
                        RRPSelectionControl = new RRPSelectionControl(rrpSheet, this);

                        if (!ProjectSettings.TobaccoExport)
                        {
                            this.rbPanel.Location = new System.Drawing.Point(224, 3);
                            this.tbPanel.Visible = false;
                        }

                        this.Controls.Add(RRPSelectionControl);
                        this.rbIndicator.Visible = true;

                        rbLabel.ForeColor = ColorTranslator.FromHtml("#302F44");

                        columnSelectionPanel.Visible = true;

                        UpdateColumnSelectionIcons();
                        ShowCurrenctControl(RRPSelectionControl, tobaccoSelectionControl);
                    } 
                    else
                    {
                        UpdateStage(Stages.Import);
                    }

                    UpdateStagesVisualzation(CurrentStage);
                    break;
                case Stages.Import:
                    excel.ExcelApplication.Quit();

                    CurrentStage = Stages.Import;

                    if (tobaccoSelectionControl != null)
                    {
                        this.Controls.Remove(tobaccoSelectionControl);

                        tobaccoBrandlist = new TobaccoBrandlist()
                        {
                            ExportCustomProperty = tobaccoSelectionControl.ecpSwitch.Checked
                        };

                        tobaccoBrandlist.PopulateBrands(tobaccoSheet, tobaccoSelectionControl);
                    }

                    if (RRPSelectionControl != null)
                    {
                        this.Controls.Remove(RRPSelectionControl);

                        rrpBrandlist = new RRPBrandlist();
                        rrpBrandlist.PopulateBrands(rrpSheet, RRPSelectionControl);
                    }

                    finalExportControl = new DataExportControl(this,tobaccoBrandlist, rrpBrandlist, excel, projectSettingsControl);
                    this.Controls.Add(finalExportControl);

                    columnSelectionPanel.Visible = false;

                    UpdateStagesVisualzation(CurrentStage);
                    break;
                case Stages.Final:
                    CurrentStage = Stages.Final;

                    UpdateStagesVisualzation(CurrentStage);
                    break;
            }
        }
        #endregion

        #region ColumnSelectionPanels

        public void ShowCurrenctControl(Control currentControl, Control previousControl)
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
            System.Windows.Forms.Application.Exit();
        }
        #endregion

        private void GunaTransfarantPictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void UploadButton_MouseEnter(object sender, EventArgs e)
        {
            zeroitPizaroAnimEdit2.ResizeHeight_Begin = 80;
            zeroitPizaroAnimEdit2.ResizeWidth_Begin = 190;

            zeroitPizaroAnimEdit2.ResizeHeight_Limit = 70;
            zeroitPizaroAnimEdit2.ResizeWidth_Limit = 180;

            zeroitPizaroAnimEdit2.Activate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (excel != null && excel.ExcelApplication.Worksheets.Count > 0)
                {
                    excel.ExcelApplication.Quit();
                }
            } catch (Exception)
            {
                return;
            }
            
        }
    }
}
