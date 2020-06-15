using System;
using System.IO;
using System.Linq;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Brandlist_Export_Assistant_V2.Controls;

namespace Brandlist_Export_Assistant_V2.Classes.Exports
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
        private string RRPBrandsNoImage { get; set; }
        private string RRPCoreListNoImage { get; set; }

        private string TobaccoExportDirectory => Dir + @"Tobacco BL\";
        private string RRPExportDirectory => Dir + @"RRP BL\";

        public virtual string Dir => $@"C:\Users\{Environment.UserName}\Documents\Brandlist Export Assistant\{ProjectSettings.CountryName}\JTI - {ProjectSettings.CountryName} {ProjectSettings.ProjectType} {ProjectSettings.Wave}\iFieldExport\";

        public IFieldExport(TobaccoBrandlist tobaccoBrandList,ProjectSettingsControl projectSettingsControl): base(tobaccoBrandList)
        {
            TobaccoBrandList = tobaccoBrandList;

            ProjectSettingsControl = projectSettingsControl;
        }

        public IFieldExport(RRPBrandlist rrpBrandlist, ProjectSettingsControl projectSettingsControl) : base(rrpBrandlist)
        {
            RRPBrandList = rrpBrandlist;

            ProjectSettingsControl = projectSettingsControl;
        }

        private void ExportTobaccoBrands(TobaccoBrandlist brandlist)
        {
            TobaccoBrands = @"Text" + "\t" + "Object Name" + "\t" + "Extended Properties" + "\t" + "Exclusive" + Environment.NewLine;

            foreach (var brand in brandlist.Brands)
            {
                var isExclusive = brand.IsExclusive ? "1" : "0";

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
            RRPBrands = @"Text" + "\t" + "Object Name" + "\t" + "Extended Properties" + "\t" + "Exclusive" +
                        Environment.NewLine;

            foreach (var brand in brandlist.Brands)
            {
                var isExclusive = brand.IsExclusive ? "1" : "0";

                RRPBrands += "{#resource:\"" + brand.TrackerCode +
                             ".jpg\",enlargeable:true,size:\"{#enImgSize#}%\"#}<br/>" + brand.GlobalLabel + "\t" +
                             brand.TrackerCode + "\t" + "{\"skuList\":\"" +
                             string.Join(",", brand.SubBrandList.Select(x => x.TrackerCode)) + "\"}" + "\t" +
                             isExclusive + Environment.NewLine;
            }
        }
        private void ExportRRPBIList(RRPBrandlist brandlist)
        {
            RRPBIList = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.BIList)
            {
                RRPBIList += "{#resource:\"" + sku.TrackerCode + ".jpg\",enlargeable:true,size:\"{#enImgSize#}%\"#}<br/>" + sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;
            }
        }
        private void ExportRRPBrandsNoImage(RRPBrandlist brandlist)
        {
            RRPBrandsNoImage = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.Brands)
            {
                RRPBrandsNoImage += sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;
            }
        }
        private void ExportRRPCoreList(RRPBrandlist brandlist)
        {
            RRPCoreList = @"Text" + "\t" + "Object Name" + "\t" + "Extended Properties" + "\t" + "Exclusive" + Environment.NewLine;

            foreach (var sku in brandlist.CoreList)
            {
                RRPCoreList += "{#resource:\"" + sku.TrackerCode + ".jpg\",enlargeable:true,size:\"{#enImgSize#}%\"#}<br/>" + sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;
            }
        }
        private void ExportRRPCoreListNoImage(RRPBrandlist brandlist)
        {
            RRPCoreListNoImage = @"Text" + "\t" + "Object Name" + Environment.NewLine;

            foreach (var sku in brandlist.CoreList)
            {
                RRPCoreListNoImage += sku.GlobalLabel + "\t" + sku.TrackerCode + Environment.NewLine;
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
        

        public virtual void ExportData()
        {
            if (ProjectSettings.TobaccoExport)
            {
                if (!Directory.Exists(TobaccoExportDirectory))
                {
                    Directory.CreateDirectory(TobaccoExportDirectory);
                }

                ExportTobaccoBrands(TobaccoBrandlist);
                ExportTobaccoSubBrands(TobaccoBrandlist);
                ExportTobaccoSubBrandsNoImage(TobaccoBrandlist);

                CreateTXT(TobaccoBrands, "1. List - brandList");
                CreateTXT(TobaccoSubBrands, "2. List - skuList");
                CreateTXT(TobaccoSubBrandsNoImage, "3. List - skuListNoImage");
            }

            if (ProjectSettings.RRPExport)
            {
                if (!Directory.Exists(RRPExportDirectory))
                {
                    Directory.CreateDirectory(RRPExportDirectory);
                }

                ExportRRPBrands(RRPBrandList);
                ExportRRPBIList(RRPBrandList);
                ExportRRPBrandsNoImage(RRPBrandList);
                ExportRRPCoreList(RRPBrandList);
                ExportRRPCoreListNoImage(RRPBrandList);
                ExportRRPSubBrands(RRPBrandList);
                ExportRRPSubBrandsNoImage(RRPBrandList);

                CreateTXT(RRPBrands, "1. List - ecigBrandsList");
                CreateTXT(RRPBIList, "2. List - ecigBrandsBrandImageList");
                CreateTXT(RRPBrandsNoImage, "3. List - ecigBrandsListNoImage");
                CreateTXT(RRPCoreList, "4. List - ecigBrandsCoreList");
                CreateTXT(RRPCoreListNoImage, "5. List - ecigBrandsCoreListNoImage");
                CreateTXT(RRPSubBrands, "6. List - ecigBrandsSkuList");
                CreateTXT(RRPSubBrandsNoImage, "7. List - ecigSkuListNoImage");
            }

            //if (ui.exportTranslationsCheckBox.Checked)
            //{
            //    CreateTXT(TranslationExport(ui), "Translations");
            //}
        }

        private void CreateTXT(string listContent, string listName)
        {
            if (listName.Contains("ecigBrands"))
            {
                File.WriteAllText(Path.Combine(RRPExportDirectory, listName + ".txt"), listContent);
            }
            else
            {
                File.WriteAllText(Path.Combine(TobaccoExportDirectory, listName + ".txt"), listContent);
            }
        }

        //public string TranslationExport(MainForm ui)
        //{
        //    var translationExport = "";

        //    var localLanguage = "";
        //    var secondLocalLanguage = "";

        //    var languages = Countries.ExportLanguages(ProjectSettings.CountryName);

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

    }
}
