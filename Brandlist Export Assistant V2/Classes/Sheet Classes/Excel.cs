using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using com.sun.tools.javac.util;
using Microsoft.Office.Interop.Excel;

namespace Brandlist_Export_Assistant_V2.Classes.Sheet_Classes
{
    public class Excel
    {
        public Excel(string fileName)
        {
            FileName = fileName;
            Open();

            AllWorksheets = ExcelApplication.Worksheets;

            Worksheets = new List<string>();

            Worksheets = GetVisibleSheets(AllWorksheets);

            WorksheetsCount = VisibleWorksheetsCount(AllWorksheets);

            ProjectSettings.Wave = Regex.Match(this.FileName, @"(W\d{1,1})").Groups[1].Value;
        }
        
        public int VisibleWorksheetsCount(Sheets worksheets)
        {
            var count = 0;

            foreach (Worksheet sheet in worksheets)
            {
                if (sheet.Visible == XlSheetVisibility.xlSheetVisible)
                {
                    count++;
                }
            }

            return count;
        }

        public List<string> GetVisibleSheets(Sheets worksheets)
        {
            foreach (var sheet in worksheets.Cast<Worksheet>().Where(sheet => sheet.Visible == XlSheetVisibility.xlSheetVisible))
            {
                this.Worksheets.Add(sheet.Name);
            }

            return Worksheets;
        }

        public List<string> Worksheets { get; set; }

        public Sheets AllWorksheets { get; set; }

        public int WorksheetsCount { get; set; }

        private void Open()
        {
            ExcelApplication = new Application();
            ExcelApplication.Workbooks.Open(FileName);
        }

        public Application ExcelApplication { get; set; }

        public string FileName { get; set; }
    }
}
