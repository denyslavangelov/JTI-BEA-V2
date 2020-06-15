using System;
using System.IO;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Microsoft.Office.Interop.Excel;

namespace Brandlist_Export_Assistant_V2.Classes.Exports
{
    public class AutoCompleteTablesExport : Export
    {
        private TobaccoBrandlist TobaccoBrandList { get; }
        private RRPBrandlist RRPBrandList { get; }
        private MDDFile MDDFile { get; }
        private string TobaccoBrandNames { get; set; }
        private string TobaccoBrandNamesLocal { get; set; }
        private string TobaccoBrandNamesSecondLocal { get; set; }
        private string TobaccoBrandCodes { get; set; }
        private string RRPBrandNames { get; set; }
        private string RRPBrandNamesLocal { get; set; }
        private string RRPBrandNamesSecondLocal { get; set; }
        private string RRPBrandCodes { get; set; }

        public AutoCompleteTablesExport(TobaccoBrandlist tobaccoBrandList, MDDFile MDDFile) : base(tobaccoBrandList)
        {
            this.TobaccoBrandList = tobaccoBrandList;
            this.MDDFile = MDDFile;
        }

        public AutoCompleteTablesExport(RRPBrandlist rrpBrandList, MDDFile MDDFile) : base(rrpBrandList)
        {
            this.RRPBrandList = rrpBrandList;
            this.MDDFile = MDDFile;
        }
        public virtual string Dir => $@"C:\Users\{Environment.UserName}\Documents\Brandlist Export Assistant\{ProjectSettings.CountryName}\JTI - {ProjectSettings.CountryName} {ProjectSettings.ProjectType} {ProjectSettings.Wave}\AutoCompleteTables\";

        public virtual void ExportData(string exportType)
        {
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            if (ProjectSettings.TobaccoExport && exportType == "Tobacco")
            {
                PopulateTobaccoBrandNames();
                PopulateTobaccoBrandCodes();

                var tobaccoSecondLocalLanguage = ProjectSettings.TobaccoSecondLocalExported;
                ExportAutoCompleteTables("Tobacco", Dir + "AutoComplete_Tables_Tobacco", "S20039391", "_AC_Tobbaco_Global", "_AC_Tobacco_Local", tobaccoSecondLocalLanguage);
                //ExportAutoCompleteTables("Tobacco", Dir + "AutoComplete_Tables_Tobacco", MDDFile.ShortName.Replace(".mdd", ""), "_AC_Tobbaco_Global", "_AC_Tobacco_Local", tobaccoSecondLocalLanguage);
            }

            if (ProjectSettings.RRPExport && exportType == "RRP")
            {
                PopulateRRPBrandNames();
                PopulateRRPCodes();

                var rrpSecondLocalLanguage = ProjectSettings.RRPSecondLocalExported;
                //ExportAutoCompleteTables("RRP",Dir + "AutoComplete_Tables_RRP", MDDFile.ShortName.Replace(".mdd", ""), "_AC_RRP_Global", "_AC_RRP_Local", rrpSecondLocalLanguage);
                ExportAutoCompleteTables("RRP", Dir + "AutoComplete_Tables_RRP", "S20039391", "_AC_RRP_Global", "_AC_RRP_Local", rrpSecondLocalLanguage);
            }
        }

        private void PopulateTobaccoBrandNames()
        {
            foreach (var brand in TobaccoBrandList.Brands)
            {
                TobaccoBrandNames = TobaccoBrandNames + brand.GlobalLabel.Replace("&amp;", "&") + Environment.NewLine;
                TobaccoBrandNamesLocal = TobaccoBrandNamesLocal + brand.LocalLabel.Replace("&amp;", "&") + Environment.NewLine;

                if (ProjectSettings.TobaccoSecondLocalExported)
                {
                    TobaccoBrandNamesSecondLocal = TobaccoBrandNamesSecondLocal + brand.SecondLocalLabel.Replace("&amp;", "&") + Environment.NewLine;
                }
            }

            if (ProjectSettings.TobaccoSecondLocalExported)
            {
                TobaccoBrandNamesSecondLocal = TobaccoBrandNamesSecondLocal.TrimEnd();
            }

            TobaccoBrandNames = TobaccoBrandNames.TrimEnd();
            TobaccoBrandNamesLocal = TobaccoBrandNamesLocal.TrimEnd();
        }

        private void PopulateTobaccoBrandCodes()
        {
            foreach (var brand in TobaccoBrandList.Brands)
            {
                TobaccoBrandCodes += brand.TrackerCode + Environment.NewLine;
            }

            TobaccoBrandCodes = TobaccoBrandCodes.TrimEnd();
        }

        private void PopulateRRPBrandNames()
        {
            foreach (var brand in RRPBrandList.Brands)
            {
                RRPBrandNames = RRPBrandNames + brand.GlobalLabel.Replace("&amp;", "&") + Environment.NewLine;
                RRPBrandNamesLocal = RRPBrandNamesLocal + brand.LocalLabel.Replace("&amp;", "&") + Environment.NewLine;

                if (ProjectSettings.RRPSecondLocalExported)
                {
                    RRPBrandNamesSecondLocal = RRPBrandNamesSecondLocal + brand.SecondLocalLabel.Replace("&amp;", "&") + Environment.NewLine;
                }
            }

            if (ProjectSettings.RRPSecondLocalExported)
            {
                RRPBrandNamesSecondLocal = RRPBrandNamesSecondLocal.TrimEnd();
            }

            RRPBrandNames = RRPBrandNames.TrimEnd();
            RRPBrandNamesLocal = RRPBrandNamesLocal.TrimEnd();
        }

        private void PopulateRRPCodes()
        {
            foreach (var brand in RRPBrandList.Brands)
            {
                RRPBrandCodes += brand.TrackerCode + Environment.NewLine;
            }

            RRPBrandCodes = RRPBrandCodes.TrimEnd();
        }

        private void ExportAutoCompleteTables(string exportType, string path, string mddDocument, string globalSheetName, string localSheetName, bool exportSecondLocalLanguage)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var excel = new Application { Visible = false };
            var misValue = System.Reflection.Missing.Value;
            var workBook = excel.Workbooks.Add(misValue);

            if (mddDocument.Length > 14)
            {
                mddDocument = mddDocument.Substring(0, 14);
            }

            var brandCodesArray = new string[] { };
            var brandNamesArray = new string[] { };
            var brandNamesLocalArray = new string[] { };
            var brandNamesSecondLocalArray = new string[] { };

            if (exportType == "Tobacco")
            {
                brandCodesArray = this.TobaccoBrandCodes.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                brandNamesArray = this.TobaccoBrandNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                brandNamesLocalArray = this.TobaccoBrandNamesLocal.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                if (exportSecondLocalLanguage)
                {
                    brandNamesSecondLocalArray = this.TobaccoBrandNamesSecondLocal.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                }
            }

            if (exportType == "RRP")
            {
                brandCodesArray = this.RRPBrandCodes.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                brandNamesArray = this.RRPBrandNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                brandNamesLocalArray = this.RRPBrandNamesLocal.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                if (exportSecondLocalLanguage)
                {
                    brandNamesSecondLocalArray = this.RRPBrandNamesSecondLocal.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                }
            }


            Worksheet globalBrandsSheet = workBook.Worksheets.Add();
            workBook.Sheets[globalBrandsSheet.Name].Move(workBook.Sheets[workBook.Sheets.Count]);

            globalBrandsSheet.Name = mddDocument + globalSheetName;

            globalBrandsSheet.Cells[1, "A"].Value2 = "precode";
            globalBrandsSheet.Cells[1, "B"].Value2 = "brand";

            for (var i = 0; i < brandNamesArray.Length; i++)
            {
                globalBrandsSheet.Cells[i + 2, "A"].Value2 = brandCodesArray[i];
                globalBrandsSheet.Cells[i + 2, "B"].Value2 = brandNamesArray[i];
            }

            Worksheet localBrandsSheet = workBook.Sheets.Add();
            workBook.Sheets[localBrandsSheet.Name].Move(workBook.Sheets[workBook.Sheets.Count]);

            localBrandsSheet.Name = mddDocument + localSheetName;

            localBrandsSheet.Cells[1, "A"].Value2 = "precode";
            localBrandsSheet.Cells[1, "B"].Value2 = "brand";

            for (var i = 0; i < brandNamesArray.Length; i++)
            {
                localBrandsSheet.Cells[i + 2, "A"].Value2 = brandCodesArray[i];
                localBrandsSheet.Cells[i + 2, "B"].Value2 = brandNamesLocalArray[i];
            }

            if (exportSecondLocalLanguage)
            {
                Worksheet secondLocalBrandsSheet = workBook.Sheets.Add();
                workBook.Sheets[secondLocalBrandsSheet.Name].Move(workBook.Sheets[workBook.Sheets.Count]);

                secondLocalBrandsSheet.Name = mddDocument + localSheetName + "_2";

                secondLocalBrandsSheet.Cells[1, "A"].Value2 = "precode";
                secondLocalBrandsSheet.Cells[1, "B"].Value2 = "brand";

                for (var i = 0; i < brandNamesArray.Length; i++)
                {
                    secondLocalBrandsSheet.Cells[i + 2, "A"].Value2 = brandCodesArray[i];
                    secondLocalBrandsSheet.Cells[i + 2, "B"].Value2 = brandNamesSecondLocalArray[i];
                }
            }

            workBook.Worksheets["Sheet1"].Delete();

            workBook.Sheets[1].Activate();

            if (Validator.IsExcelOpen(path, workBook))
            {
                excel.Quit();
            }
            else
            {
                workBook.SaveAs(path);
                workBook.Close(true);
            }
        }

    }
}
