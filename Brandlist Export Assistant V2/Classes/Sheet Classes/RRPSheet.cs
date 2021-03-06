﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Brandlist_Export_Assistant_V2.Forms;
using Microsoft.Office.Interop.Excel;

namespace Brandlist_Export_Assistant_V2.Classes.Sheet_Classes
{
    public class RRPSheet
    {
        public RRPSheet(Excel excel, string sheetName)
        {
            Excel = excel;

            Sheet = excel.AllWorksheets[sheetName];

            SheetName = Sheet.Name;

            ColumnNames = new List<string>();

            try
            {
                Data = CollectData(Sheet);
            }
            catch (Exception)
            {
                Alert.Show("Invalid brandlist.", Stages.ColumnSelection);
            }

            SetColumnIndexes(Data);

            ProjectSettings.CountryName = Data.SelectMany(x => x.Value).ElementAt(this.CountryColumnIndex).Value.ElementAt(this.CountryColumnIndex);
            ProjectSettings.CountryCode = Countries.ExportCountries(Regex.Replace(ProjectSettings.CountryName, @"\s+", "")).FirstOrDefault(x => x.Key == Regex.Replace(ProjectSettings.CountryName, @"\s+", "")).Value;
        }
        private Excel Excel { get; set; }

        public Worksheet Sheet { get; set; }

        public string SheetName { get; set; }

        public Dictionary<Dictionary<int, string>, Dictionary<int, string[]>> Data { get; set; }

        public int TrackerCodeColumnIndex { get; set; }

        public int GlobalLabelColumnIndex { get; set; }

        public int LocalLabelColumnIndex { get; set; }

        public int ProductTypeColumnIndex { get; set; }

        public int StatusColumnIndex { get; set; }

        public int MarketCodeColumnIndex { get; set; }

        public int SecondLocalLabelColumnIndex { get; set; }

        public int CustomPropertyColumnIndex { get; set; }

        public int CountryColumnIndex { get; set; }

        public int ProductGroupColumnIndex { get; set; }

        public int CoreListColumnIndex { get; set; }

        public int BIListColumnIndex { get; set; }

        public int MarketCode { get; set; }

        public List<string> ColumnNames { get; set; }

        public Dictionary<Dictionary<int, string>, Dictionary<int, string[]>> CollectData(Worksheet worksheet)
        {
            var usedRange = worksheet.Range["A1", Type.Missing].CurrentRegion;
            var columnIndex = 0;

            var fullColumnData = new Dictionary<int, string>();
            var fullRowData = new Dictionary<int, string[]>();
            var wholeData = new Dictionary<Dictionary<int, string>, Dictionary<int, string[]>>();

            var initialRowsCount = usedRange.Rows.Count;

            Validator.ValidateDataRows(initialRowsCount);

            foreach (Range row in usedRange.Rows)
            {
                var columnData = new string[row.Columns.Count];

                for (var i = 0; i < row.Columns.Count; i++)
                {
                    columnData[i] = Convert.ToString(row.Cells[1, i + 1].Value2);

                    if (fullColumnData.Keys.Count < row.Columns.Count)
                    {
                        fullColumnData.Add(columnIndex, columnData[i]);
                        ColumnNames.Add(columnData[i]);
                        columnIndex++;
                    }
                }
                break;
            }

            Validator.ValidateRRPColumns(this);

            var rangeColumn = fullColumnData.Keys.Count - 1;
            var values = (object[,])usedRange.Value2;
            var rowsCount = values.GetLength(0);

            var rowIndex = 1;

            System.Windows.Forms.Application.DoEvents();

            while (rowIndex < rowsCount)
            {
                var rowData = new string[rangeColumn + 1];

                for (var c = 1; c <= rangeColumn + 1; c++)
                {
                    rowData[c - 1] = Convert.ToString(values[rowIndex + 1, c]);
                }

                fullRowData.Add(rowIndex, rowData);
                rowIndex++;
            }

            wholeData.Add(fullColumnData, fullRowData);


            return wholeData;
        }

        public void SetColumnIndexes(Dictionary<Dictionary<int, string>, Dictionary<int, string[]>> excelData)
        {
            foreach (var inner in excelData.SelectMany(x => x.Key))
            {
                var currentColumnName = inner.Value.Trim();

                switch (currentColumnName)
                {
                    case "Tracker 2.0 Code":
                        TrackerCodeColumnIndex = inner.Key;
                        break;  
                    case "Label in English (Translated questionnaire label)":
                        GlobalLabelColumnIndex = inner.Key;
                        break;
                    case "Local Label in local language A (Questionnaire label)":
                        LocalLabelColumnIndex = inner.Key;
                        break;
                    case "Scripting Product Type Code":
                        ProductTypeColumnIndex = inner.Key;
                        break;
                    case "Market Code":
                        MarketCodeColumnIndex = inner.Key;
                        break;
                    case "Status":
                        StatusColumnIndex = inner.Key;
                        break;
                    case "Market":
                        CountryColumnIndex = inner.Key;
                        break;
                    case "Product Group":
                        ProductGroupColumnIndex = inner.Key;
                        break;
                    case "BI list (max 10 Brands = 8 global + 2 local)":
                        BIListColumnIndex = inner.Key;
                        break;
                    case "Core List (Reco 16 = 8 global + 8 local , max 25 Brands)":
                        CoreListColumnIndex = inner.Key;
                        break;
                }
            }
        }
    }
}
