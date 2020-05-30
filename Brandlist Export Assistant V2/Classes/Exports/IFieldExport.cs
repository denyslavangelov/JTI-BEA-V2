using Brandlist_Export_Assistant_V2;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using System;
using System.IO;
using System.Linq;

namespace Brandlist_Export_Assistant.Classes
{
    public class IFieldExport : Export
    {
        public TobaccoBrandlist TobaccoBrandList { get; }
        public RRPBrandlist RRPBrandList { get; }
        public ProjectSettingsControl ProjectSettingsControl { get; }

        private string TobaccoBrands { get; set; }
        private string TobaccoSubBrands { get; set; }
        private string TobaccoSubBrandsNoImage { get; set; }
        private string RRPBrands { get; set; }
        private string RRPSubBrands { get; set; }
        private string RRPSubBrandsNoImage { get; set; }
        private string RRPCoreList { get; set; }
        private string RRPBIList { get; set; }

        public override string Dir => $@"C:\Users\{Environment.UserName}\Documents\Brandlist Export Assistant\{ProjectSettings.CountryName}\JTI - {ProjectSettings.CountryName} {ProjectSettings.ProjectType} {ProjectSettings.Wave}\iFieldExport\";

        public IFieldExport(TobaccoBrandlist tobaccoBrandList, RRPBrandlist rrpBrandlist, ProjectSettingsControl projectSettingsControl): base(tobaccoBrandList, rrpBrandlist)
        {
            TobaccoBrandList = tobaccoBrandList;
            RRPBrandList = rrpBrandlist;

            ProjectSettingsControl = projectSettingsControl;
        }

        private void ExportTobaccoBrands(TobaccoBrandlist brandlist)
        {
            TobaccoBrands = @"Text" + "\t" + "Object Name" + "\t" + "Extended Properties" + "\t" + "Exclusive" + Environment.NewLine;

            foreach (var brand in brandlist.Brands)
            {
                string isExclusive = brand.IsExclusive ? "1" : "0";

                TobaccoBrands += brand.GlobalLabel + "\t" + brand.TrackerCode + "\t" + "{\"skuList\":\"" + string.Join(",", brand.SubBrandList.Select(x => x.TrackerCode)) + "\"}" + "\t" + isExclusive + Environment.NewLine;
            }
        }
        private void ExportTobaccoSubBrands(TobaccoBrandlist brandlist)
        {
            TobaccoSubBrands = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.SubBrands)
            {
                TobaccoSubBrands += "{#resource:\"" + sku.TrackerCode + ".jpg\",enlargeable:true,size:\"{#enImgSize#}%\"#}<br/>" + sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;

            }
        }
        private void ExportTobaccoSubBrandsNoImage(TobaccoBrandlist brandlist)
        {
            TobaccoSubBrandsNoImage = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.SubBrands)
            {
                TobaccoSubBrandsNoImage += sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;
            }
        }


        private void ExportRRPBrands(RRPBrandlist brandlist)
        {
            RRPBrands = @"Text" + "\t" + "Object Name" + "\t" + "Extended Properties" + "\t" + "Exclusive" + Environment.NewLine;

            foreach (var brand in brandlist.Brands)
            {
                string isExclusive = brand.IsExclusive ? "1" : "0";

                RRPBrands += brand.GlobalLabel + "\t" + brand.TrackerCode + "\t" + "{\"skuList\":\"" + string.Join(",", brand.SubBrandList.Select(x => x.TrackerCode)) + "\"}" + "\t" + isExclusive + Environment.NewLine;
            }
        }
        private void ExportRRPSubBrands(RRPBrandlist brandlist)
        {
            RRPSubBrands = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.SubBrands)
            {
                RRPSubBrands += "{#resource:\"" + sku.TrackerCode + ".jpg\",enlargeable:true,size:\"{#enImgSize#}%\"#}<br/>" + sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;

            }
        }
        private void ExportRRPSubBrandsNoImage(RRPBrandlist brandlist)
        {
            RRPSubBrandsNoImage = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.SubBrands)
            {
                RRPSubBrandsNoImage += sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;
            }
        }
        private void ExportRRPCoreList(RRPBrandlist brandlist)
        {
            RRPCoreList = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.CoreList)
            {
                RRPCoreList += sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;
            }
        }
        private void ExportRRPBIList(RRPBrandlist brandlist)
        {
            RRPBIList = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.BIList)
            {
                RRPBIList += sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;
            }
        }

        public override void ExportData()
        {
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            if (ProjectSettings.TobaccoExport)
            {
                ExportTobaccoBrands(tobaccoBrandlist);
                ExportTobaccoSubBrands(tobaccoBrandlist);
                ExportTobaccoSubBrandsNoImage(tobaccoBrandlist);

                CreateTXT(TobaccoBrands, "TobaccoBrandsList");
                CreateTXT(TobaccoSubBrands, "TobaccoSubBrandsList");
                CreateTXT(TobaccoSubBrandsNoImage, "TobaccoSubBrandsList_NoImage");
            }

            if (ProjectSettings.RRPExport)
            {
                ExportRRPBrands(rrpBrandlist);
                ExportRRPSubBrands(rrpBrandlist);
                ExportRRPSubBrandsNoImage(rrpBrandlist);
                ExportRRPCoreList(rrpBrandlist);
                ExportRRPBIList(rrpBrandlist);

                CreateTXT(RRPBrands, "RRPBrandsList");
                CreateTXT(RRPSubBrands, "RRPSubBrandsList");
                CreateTXT(RRPSubBrandsNoImage, "RRPSubBrandsList_NoImage");
                CreateTXT(RRPCoreList, "RRPCoreList");
                CreateTXT(RRPBIList, "RRPBIList");
            }

            //if (ui.exportTranslationsCheckBox.Checked)
            //{
            //    CreateTXT(TranslationExport(ui), "Translations");
            //}

            //System.Diagnostics.Process.Start(Dir);
        }

        //public string TranslationExport(MainForm ui)
        //{
        //    var translationExport = "";

        //    var localLanguage = "";
        //    var secondLocalLanguage = "";

        //    var languages = Countries.ExportLanguages(_brandlist.Country);

        //    localLanguage = languages.Where(x => x == ui.localLanguagesComboBox.Text).First();

        //    if (ui.iFieldSecondLocalLanguageCheckBox.Checked)
        //    {
        //        secondLocalLanguage = languages.Where(x => x == ui.secondLocalLanguageComboBox.Text).First();
        //    }

        //    translationExport += "Full Object Name" + "\t" + "Literal ID" + "\t" + localLanguage;

        //    if (ui.iFieldSecondLocalLanguageCheckBox.Checked)
        //    {
        //        translationExport += "\t" + secondLocalLanguage;
        //    }

        //    translationExport += Environment.NewLine;

        //    translationExport += "--- Survey Literals ---" + "\t" + "--- Survey Literals ---" + "\t" + "--------------------";

        //    if (ui.iFieldSecondLocalLanguageCheckBox.Checked)
        //    {
        //        translationExport += "\t" + "--------------------";
        //    }

        //    translationExport += Environment.NewLine;

        //    foreach (var brand in _brandlist.MainBrandList)
        //    {
        //        translationExport += "brandList." + brand.TrackerCode + ".text" + "\t" + brand.GlobalLabel + "\t" + brand.LocalLabel;

        //        if (ui.iFieldSecondLocalLanguageCheckBox.Checked)
        //        {
        //            translationExport += "\t" + brand.SecondLocalLabel;
        //        }

        //        translationExport += Environment.NewLine;
        //    }

        //    foreach (var subBrand in _brandlist.SubBrandList)
        //    {
        //        translationExport += "skuList." + subBrand.TrackerCode + ".text" + "\t" + "{#resource:\"" + subBrand.TrackerCode + ".jpg\",enlargeable:true,size:\"{#enImgSize#}%\"#}<br/>" + subBrand.GlobalLabel + "\t" + "{#resource:\"" + subBrand.TrackerCode + ".jpg\",enlargeable:true,size:\"{#enImgSize#}%\"#}<br/>" + subBrand.LocalLabel;

        //        if (ui.iFieldSecondLocalLanguageCheckBox.Checked)
        //        {
        //            translationExport += "\t" + "{#resource:\"" + subBrand.TrackerCode + ".jpg\",enlargeable:true,size:\"{#enImgSize#}%\"#}<br/>" + subBrand.SecondLocalLabel;
        //        }

        //        translationExport += Environment.NewLine;
        //    }

        //    foreach (var subBrand in _brandlist.SubBrandList)
        //    {
        //        translationExport += "skuListNoImage." + subBrand.TrackerCode + ".text" + "\t" + subBrand.GlobalLabel + "\t" + subBrand.LocalLabel;

        //        if (ui.iFieldSecondLocalLanguageCheckBox.Checked)
        //        {
        //            translationExport += "\t" + subBrand.SecondLocalLabel;
        //        }

        //        translationExport += Environment.NewLine;
        //    }


        //    return translationExport;
        //}

        private void CreateTXT(string listContent, string listName)
        {
            File.WriteAllText(Path.Combine(Dir, listName + ".txt"), listContent);
        }
    }
}
