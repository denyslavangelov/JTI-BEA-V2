using System;
using System.IO;
using Brandlist_Export_Assistant_V2;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Microsoft.Office.Interop.Excel;

namespace Brandlist_Export_Assistant.Classes
{
    public class AutoCompleteTablesExport : Export
    {
        private TobaccoBrandlist TobaccoBrandList { get; }

        private RRPBrandlist RRPBrandList { get; }

        private MDDFile MDDFile { get; }

        private string TobaccoBrandNames { get; set; }

        private string TobaccoBrandNamesLocal { get; set; }

        private string TobaccoBrandCodes { get; set; }

        private string RRPBrandNames { get; set; }

        private string RRPBrandNamesLocal { get; set; }

        private string RRPBrandCodes { get; set; }

        public AutoCompleteTablesExport(TobaccoBrandlist tobaccoBrandList, RRPBrandlist rrpBrandList, MDDFile MDDFile) : base(tobaccoBrandList, rrpBrandList)
        {
            this.TobaccoBrandList = tobaccoBrandList;
            this.RRPBrandList = rrpBrandList;

            this.MDDFile = MDDFile;
        }
        public override string Dir => $@"C:\Users\{Environment.UserName}\Documents\Brandlist Export Assistant\{ProjectSettings.CountryName}\JTI - {ProjectSettings.CountryName} {ProjectSettings.ProjectType} {ProjectSettings.Wave}\AutoCompleteTables\";

        public override void ExportData()
        {
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            if (ProjectSettings.TobaccoExport)
            {
                PopulateTobaccoBrandNames();
                PopulateTobaccoBrandCodes();
            }

            if (ProjectSettings.RRPExport)
            {
                PopulateRRPBrandNames();
                PopulateRRPCodes();
            }

            string fileName = "AutoComplete_Tables.xlsx";

            if (File.Exists(Dir + fileName))
            {
                File.Delete(Dir + fileName);
            }

            ExportAutoCompleteTables(Dir + fileName, MDDFile.ShortName.Replace(".mdd", ""));
        }

        private void PopulateTobaccoBrandNames()
        {
            foreach (var brand in TobaccoBrandList.Brands)
            {
                TobaccoBrandNames = TobaccoBrandNames + brand.GlobalLabel.Replace("&amp;", "&") + Environment.NewLine;
                TobaccoBrandNamesLocal = TobaccoBrandNamesLocal + brand.LocalLabel.Replace("&amp;", "&") + Environment.NewLine;
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

        private void ExportAutoCompleteTables(string PathFileName, string mddDocument)
        {
            var excel = new Application { Visible = false };
            var misValue = System.Reflection.Missing.Value;
            var workBook = excel.Workbooks.Add(misValue);

            string[] brandCodesArray;
            string[] brandNamesArray;
            string[] brandNamesLocalArray;

            if (mddDocument.Length > 14)
            {
                mddDocument = mddDocument.Substring(0, 14);
            }

            if (ProjectSettings.TobaccoExport)
            {
                brandCodesArray = this.TobaccoBrandCodes.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                brandNamesArray = this.TobaccoBrandNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                brandNamesLocalArray = this.TobaccoBrandNamesLocal.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                Worksheet globalBrandsSheet = workBook.Sheets.Add();
                globalBrandsSheet.Name = mddDocument + "_AC_Brands_Global";

                globalBrandsSheet.Cells[1, "A"].Value2 = "precode";
                globalBrandsSheet.Cells[1, "B"].Value2 = "brand";

                for (int i = 0; i < brandNamesArray.Length; i++)
                {
                    globalBrandsSheet.Cells[i + 2, "A"].Value2 = brandCodesArray[i];
                    globalBrandsSheet.Cells[i + 2, "B"].Value2 = brandNamesArray[i];
                }

                Worksheet localBrandsSheet = workBook.Sheets.Add();

                localBrandsSheet.Name = mddDocument + "_AC_Brands_Local";

                localBrandsSheet.Cells[1, "A"].Value2 = "precode";
                localBrandsSheet.Cells[1, "B"].Value2 = "brand";

                for (int i = 0; i < brandNamesArray.Length; i++)
                {
                    localBrandsSheet.Cells[i + 2, "A"].Value2 = brandCodesArray[i];
                    localBrandsSheet.Cells[i + 2, "B"].Value2 = brandNamesLocalArray[i];
                }
            }

            if (ProjectSettings.RRPExport)
            {
                brandCodesArray = this.RRPBrandCodes.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                brandNamesArray = this.RRPBrandNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                brandNamesLocalArray = this.RRPBrandNamesLocal.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                Worksheet globalRRPBrandsSheet = workBook.Sheets.Add();

                globalRRPBrandsSheet.Name = mddDocument + "_RRP_AC_SP_Global";

                globalRRPBrandsSheet.Cells[1, "A"].Value2 = "precode";
                globalRRPBrandsSheet.Cells[1, "B"].Value2 = "brand";

                for (int i = 0; i < brandNamesArray.Length; i++)
                {
                    globalRRPBrandsSheet.Cells[i + 2, "A"].Value2 = brandCodesArray[i];
                    globalRRPBrandsSheet.Cells[i + 2, "B"].Value2 = brandNamesArray[i];
                }

                Worksheet localRRPBrandsSheet = workBook.Sheets.Add();

                localRRPBrandsSheet.Name = mddDocument + "_RRP_AC_SP_Local";

                localRRPBrandsSheet.Cells[1, "A"].Value2 = "precode";
                localRRPBrandsSheet.Cells[1, "B"].Value2 = "brand";

                for (int i = 0; i < brandNamesArray.Length; i++)
                {
                    localRRPBrandsSheet.Cells[i + 2, "A"].Value2 = brandCodesArray[i];
                    localRRPBrandsSheet.Cells[i + 2, "B"].Value2 = brandNamesLocalArray[i];
                }
            }

            workBook.Worksheets["Sheet1"].Delete();

            workBook.SaveAs(PathFileName);
            workBook.Close(true);

            excel.Quit();
        }
    }
}
