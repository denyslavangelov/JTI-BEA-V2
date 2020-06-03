using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Brandlist_Export_Assistant_V2.Classes.Exports;
using Brandlist_Export_Assistant_V2.Classes.Sheet_Classes;
using Brandlist_Export_Assistant_V2.Enums;
using Brandlist_Export_Assistant_V2.Forms;
using Guna.UI.WinForms;

namespace Brandlist_Export_Assistant_V2.Controls
{
    public partial class DataExportControl : UserControl
    {
        public string ExportString { get; private set; } = @"EXPORTING";

        private DimensionsExport DimensionsExport { get; set; }
        private IFieldExport IFieldExport { get; set; }
        public TobaccoBrandlist TobaccoBrandlist { get; }
        public RRPBrandlist RRPBrandlist { get; }

        public Excel Excel;

        public LoadingScreen LoadingScreen { get; set; }

        private MainForm MainForm { get; }

        public ProjectSettingsControl ProjectSettingsControl { get; }

        private MDDFile MDDFile { get; set; }

        public DataExportControl(MainForm mainForm, TobaccoBrandlist tobaccoBrandlist, RRPBrandlist rrpBrandlist, Excel excel, ProjectSettingsControl projectSettingsControl)
        {
            InitializeComponent();

            RRPBrandlist = rrpBrandlist;
            TobaccoBrandlist = tobaccoBrandlist;

            ProjectSettingsControl = projectSettingsControl;

            LoadingScreen = new LoadingScreen();

            this.Excel = excel;

            MainForm = mainForm;

            Location = new Point(323, 115);
            Size = new Size(579, 524);

            ExportPanelSetup();
        }

        public async Task ExportDataAsync()
        {
            await Task.Run(ExportData);
        }

        private async void ExportDataButton_Click(object sender, EventArgs e)
        {
            if (ProjectSettings.Platform == Platform.Dimensions)
            {
                ExportString = @"IMPORTING";

                var browseFile = new OpenFileDialog
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

            this.LoadingScreen.Show(this.Parent, this, ExportString);

            await ExportDataAsync();

            MainForm.UpdateStage(Stages.Final);

            this.LoadingScreen.Hide(this.Parent, this);

            SuccessScreenSetup();
        }

        private void ExportPanelSetup()
        {
            browsePanel.Location = new Point(155,80);

            if (ProjectSettings.Platform == Platform.iField)
            {
                exportDataButton.Text = @"EXPORT DATA";
                exportLabel.Visible = false;
            }
        }

        private void SuccessScreenSetup()
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

        private void SuccessFolderButton_Click(object sender, EventArgs e)
        {
            switch (ProjectSettings.Platform)
            {
                case Platform.Dimensions:
                    Process.Start(MDDFile.Path);
                    break;
                case Platform.iField:
                    Process.Start(IFieldExport.Dir);
                    break;
                case Platform.Dooblo:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
