using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Brandlist_Export_Assistant_V2.Classes.Exports;
using Brandlist_Export_Assistant_V2.Enums;
using Brandlist_Export_Assistant_V2.Forms;

namespace Brandlist_Export_Assistant_V2.Controls
{
    public partial class DataExportControl : UserControl
    {
        public string ExportString { get; private set; } = @"EXPORTING";

        private DimensionsExport DimensionsExport { get; set; }
        private IFieldExport IFieldExport { get; set; }
        private TobaccoBrandlist TobaccoBrandlist { get; }
        private RRPBrandlist RRPBrandlist { get; }
        public AutoCompleteTablesExport AutoCompleteTablesExport { get; set; }
        public LoadingScreen LoadingScreen { get; set; }
        private MainForm MainForm { get; }
        public ProjectSettingsControl ProjectSettingsControl { get; }
        private MDDFile MDDFile { get; set; }
        private string PathLocation { get; set; }

        private SuccessScreenControl SuccessScreenControl { get; set; }

            public DataExportControl(MainForm mainForm, TobaccoBrandlist tobaccoBrandlist, RRPBrandlist rrpBrandlist, ProjectSettingsControl projectSettingsControl)
        {
            InitializeComponent();

            RRPBrandlist = rrpBrandlist;
            TobaccoBrandlist = tobaccoBrandlist;

            ProjectSettingsControl = projectSettingsControl;

            MainForm = mainForm;

            LoadingScreen = new LoadingScreen();

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

            this.LoadingScreen.Show(this.MainForm, this, ExportString);

            await ExportDataAsync();

            this.LoadingScreen.Hide(this.MainForm, this);

            FinalScreenSetup();
        }

        private void FinalScreenSetup()
        {
            var pathLocation = "";

            switch (ProjectSettings.Platform)
            {
                case Platform.Dimensions:
                    if (DimensionsExport.IsSuccessfulyOpen)
                    {
                        pathLocation = DimensionsExport.Dir;
                    }
                    else
                    {
                        MainForm.UpdateStage(Stages.Import);
                    }
                    break;
                case Platform.iField:
                    pathLocation = IFieldExport.Dir;
                    break;
            }

            this.PathLocation = pathLocation;
            SuccessScreenControl = new SuccessScreenControl(PathLocation);

            this.MainForm.Controls.Remove(this);
            this.MainForm.Controls.Add(SuccessScreenControl);

            MainForm.UpdateStage(Stages.Final);
        }

        private void ExportPanelSetup()
        {
            //browsePanel.Location = new Point(155,80);

            if (ProjectSettings.Platform == Platform.iField)
            {
                exportDataButton.Text = @"EXPORT DATA";
            }
        }

        private void ExportData()
        {
            switch (ProjectSettings.Platform)
            {
                case Platform.Dimensions:
                    DimensionsExport = new DimensionsExport(MDDFile,RRPBrandlist,TobaccoBrandlist);

                    if (ProjectSettings.TobaccoExport)
                    {
                        if (ProjectSettings.Methodology == Methodology.CAWI && ProjectSettings.Platform == Platform.Dimensions)
                        {
                            AutoCompleteTablesExport = new AutoCompleteTablesExport(TobaccoBrandlist, MDDFile);
                            AutoCompleteTablesExport.ExportData("Tobacco");
                        }

                        DimensionsExport.ExportData();

                        if (!DimensionsExport.IsSuccessfulyOpen)
                        {
                            return;
                        }
                    }

                    if (ProjectSettings.RRPExport)
                    {
                        if (ProjectSettings.Methodology == Methodology.CAWI && ProjectSettings.Platform == Platform.Dimensions)
                        {
                            AutoCompleteTablesExport = new AutoCompleteTablesExport(RRPBrandlist, MDDFile);
                            AutoCompleteTablesExport.ExportData("RRP");
                        }

                        DimensionsExport.ExportData();
                    }
                    break;
                case Platform.iField:
                    IFieldExport = new IFieldExport(TobaccoBrandlist,RRPBrandlist);
                    IFieldExport.ExportData();
                    break;
            }
        }

        private void SuccessFolderButton_Click(object sender, EventArgs e)
        {
            switch (ProjectSettings.Platform)
            {
                case Platform.Dimensions:
                    Process.Start(DimensionsExport.Dir);
                    break;
                case Platform.iField:
                    Process.Start(IFieldExport.Dir);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
