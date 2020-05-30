using Brandlist_Export_Assistant.Classes;
using Microsoft.Office.Interop.Excel;


namespace Brandlist_Export_Assistant_V2.Classes
{
    public class Excel
    {
        public Excel(string fileName)
        {
            FileName = fileName;
            Open();

            Worksheets = ExcelApplication.Worksheets;

            WorksheetsCount = VisibleWorksheetsCount(Worksheets);
        }
        
        public int VisibleWorksheetsCount(Sheets Worksheets)
        {
            var count = 0;

            foreach (Worksheet sheet in Worksheets)
            {
                if (sheet.Visible == XlSheetVisibility.xlSheetVisible)
                {
                    count++;
                }
            }

            return count;
        }

        public Sheets Worksheets { get; set; }

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
