using System.Collections.Generic;
using System.IO;
using System.Linq;
using Brandlist_Export_Assistant_V2.Classes.Brand;
using Brandlist_Export_Assistant_V2.Classes.Exports;
using Brandlist_Export_Assistant_V2.Classes.Sheet_Classes;

namespace Brandlist_Export_Assistant_V2.Classes
{
    public static class Validator
    {
        public static bool ValidateBrand(Brand.Brand brand, int rowIndex)
        {
            if (string.IsNullOrEmpty(brand.TrackerCode) || brand.TrackerCode == "br_")
            {
                Alert.Show($"There is an invalid tracker code at row {rowIndex + 1}.", Alert.AlertType.Error, Stages.LoadBrandlist);
                return false;
            }

            if (string.IsNullOrEmpty(brand.GlobalLabel) || brand.GlobalLabel == "n/a")
            {
                Alert.Show($"There is an invalid global label at row {rowIndex + 1}.", Alert.AlertType.Error, Stages.LoadBrandlist);
                return false;
            }

            if (string.IsNullOrEmpty(brand.LocalLabel) || brand.LocalLabel == "n/a")
            {
                Alert.Show($"There is an invalid local label at row {rowIndex + 1}.", Alert.AlertType.Error, Stages.LoadBrandlist);
                return false;
            }

            return true;
        }

        public static void Validate_HasMainBrand(List<SubBrand> subBrandList)
        {

            foreach (var subBrand in subBrandList)
            {
                if (!subBrand.HasMainBrand)
                {
                    Alert.Show($"The sub brand named {subBrand.GlobalLabel} doesn't have a main brand.", Alert.AlertType.Error, Stages.LoadBrandlist);
                }
            }
        }

        public static void Validate_HasSubBrandList(List<MainBrand> mainBrandList)
        {
            for (var i = 0; i < mainBrandList.Count - 3; i++)
            {
                if (!mainBrandList[i].HasAnySubBrands)
                {
                    Alert.Show($"The brand named {mainBrandList[i].GlobalLabel} doesn't have any sub brands.", Alert.AlertType.Error, Stages.LoadBrandlist);
                }
            }
        }

        //public static bool ValidateiFieldExport(MainUI UI)
        //{
        //    if (UI.localLanguagesComboBox.Visible == true && UI.localLanguagesComboBox.Text == "" || UI.secondLocalLanguageComboBox.Visible == true && UI.secondLocalLanguageComboBox.Text == "")
        //    {
        //        MetroMessageBox.Show(UI, $"Please specify a local language.", "Missing Local Language", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return false;
        //    }

        //    return true;
        //}

        public static bool IsFileOpen(DimensionsExport export, string mddDirectory)
        {
            var mdd = mddDirectory.Contains("mdd") ? "" : ".mdd";

            mddDirectory += mdd;

            if (File.Exists(mddDirectory))
            {
                try
                {
                    export.MDD_Document.Open(mddDirectory);
                }
                catch
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ValidateBrandlist(TobaccoSheet tobaccoSheet)
        {
            var mandatoryColumns = new List<string> { "Tracker 2.0 Code", "Scripting Product Type Code", "Market Code", "Status" };

            if (mandatoryColumns.Any(column => !tobaccoSheet.ColumnNames.Contains(column)))
            {
                Alert.Show("Invalid brandlist. One of the mandatory columns is not present in the brandlist.", Alert.AlertType.Error, Stages.LoadBrandlist);
                return false;
            }
            return true;
        }

        //public static void ValidateLanguages(MainUI UI, List<string> languages, ExcelProcessor _brandlist)
        //{
        //    if (languages.Count == 0)
        //    {
        //        MetroMessageBox.Show(UI, "Woops!" + Environment.NewLine + Environment.NewLine + $"It looks like '{_brandlist.Country}' is not part of the country list." + Environment.NewLine + "Please inform Denislav.Angelov@ipsos.com!" + Environment.NewLine + "You can still export your brandlist but without translations.", "Missing Country", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        UI.exportTranslationsCheckBox.Checked = false;
        //        UI.exportTranslationsCheckBox.Enabled = false;
        //    }
        //}
    }
}