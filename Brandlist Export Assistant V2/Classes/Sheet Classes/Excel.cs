using Microsoft.Office.Interop.Excel;

namespace Brandlist_Export_Assistant_V2.Classes.Sheet_Classes
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
