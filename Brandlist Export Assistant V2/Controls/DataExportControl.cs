using Brandlist_Export_Assistant.Classes;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Brandlist_Export_Assistant_V2.Enums;
using Guna.UI.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brandlist_Export_Assistant_V2
{
    public partial class DataExportControl : UserControl
    {
        private DimensionsExport DimensionsExport { get; set; }
        private IFieldExport IFieldExport { get; set; }

        public TobaccoBrandlist TobaccoBrandlist { get; }
        public RRPBrandlist RRPBrandlist { get; }

        public TobaccoSheet tobaccoSheet;

        public Excel excel;

        private MainForm MainForm { get; }

        public ProjectSettingsControl ProjectSettingsControl { get; }

        private MDDFile MDDFile { get; set; }

        public DataExportControl(MainForm mainForm, TobaccoBrandlist tobaccoBrandlist, RRPBrandlist rrpBrandlist, Excel Excel, ProjectSettingsControl projectSettingsControl)
        {
            InitializeComponent();

            RRPBrandlist = rrpBrandlist;
            TobaccoBrandlist = tobaccoBrandlist;

            ProjectSettingsControl = projectSettingsControl;

            excel = Excel;

            MainForm = mainForm;

            Location = new Point(323, 115);
            Size = new Size(579, 524);

            ExportPanelSetup();
        }

        public async Task ExecuteAsync()
        {
            await Task.Run(() => {
                ExportData();
            });
        }

        private async void ExportDataButton_Click(object sender, EventArgs e)
        {
            if (ProjectSettings.Platform == Platform.Dimensions)
            {
                OpenFileDialog browseFile = new OpenFileDialog
                {
                    FilterIndex = 0,
                    RestoreDirectory = true
                };

                if (browseFile.ShowDialog() == DialogResult.OK)
                {
                    MDDFile = new MDDFile
                    {
                        ShortName = browseFile.SafeFileName,
                        FullName = browseFile.FileName
                    };

                    MDDFile.Path = Path.GetDirectoryName(MDDFile.FullName);
                }
            }

            LoadingButton(exportDataButton);

            await ExecuteAsync();

            MainForm.UpdateStage(Stages.Final);

            SucessScreenSetup();
        }

        private void ExportPanelSetup()
        {
            browsePanel.Location = new Point(155,80);

            if (ProjectSettings.Platform == Platform.iField)
            {
                exportDataButton.Text = "EXPORT DATA";
                exportLabel.Visible = false;
            }
        }

        private void SucessScreenSetup()
        {
            successPanel.Visible = true;
            browsePanel.Visible = false;

            if (ProjectSettings.Platform == Platform.iField)
            {
                successBodyText.Text = successBodyText.Text.Replace("imported", "exported");
            }
        }

        private void ExportData()
        {
            switch (ProjectSettings.Platform)
            {
                case Platform.Dimensions:
                    DimensionsExport = new DimensionsExport(MDDFile, TobaccoBrandlist, RRPBrandlist, ProjectSettingsControl);
                    DimensionsExport.ExportData();

                    if (ProjectSettings.Methodology == Methodology.CAWI && ProjectSettings.Platform == Platform.Dimensions)
                    {
                        var autoCompleteExport = new AutoCompleteTablesExport(TobaccoBrandlist, RRPBrandlist, MDDFile);
                        autoCompleteExport.ExportData();
                    }
                    break;
                case Platform.iField:
                    IFieldExport = new IFieldExport(TobaccoBrandlist, RRPBrandlist, ProjectSettingsControl);
                    IFieldExport.ExportData();
                    break;
                case Platform.Dooblo:
                    break;
            }
        }

        private void LoadingButton(GunaButton button)
        {
            button.BorderColor = ColorTranslator.FromHtml("#3D4853");
            button.ForeColor = ColorTranslator.FromHtml("#3D4853");
            button.BorderSize = 4;

            button.BaseColor = Color.Transparent;
            button.OnHoverBaseColor = Color.Transparent;
            button.OnHoverBorderColor = ColorTranslator.FromHtml("#3D4853");
            button.OnHoverForeColor = ColorTranslator.FromHtml("#3D4853");
            button.OnHoverImage = null;
            button.Image = null;
            button.TextOffsetX = 25;
            button.TextAlign = HorizontalAlignment.Right;

            loadingBarImage.Visible = true;

            button.Text = "IMPORTING";
        }

        private void SuccessFolderButton_Click(object sender, EventArgs e)
        {
            if (ProjectSettings.Platform == Platform.Dimensions)
            {
                //Process.Start(MDDFile.Path);
                Process.Start(DimensionsExport.Dir);
            }

            if (ProjectSettings.Platform == Platform.iField)
            {
                Process.Start(IFieldExport.Dir);
            }
            
        }
    }
}
