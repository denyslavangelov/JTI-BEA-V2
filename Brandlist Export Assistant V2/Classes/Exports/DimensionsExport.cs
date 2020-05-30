using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Brandlist_Export_Assistant_V2;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brand;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using MDMLib;

namespace Brandlist_Export_Assistant.Classes
{

    public class DimensionsExport : Export
    {
        public TobaccoBrandlist TobaccoBrandList { get; }

        public RRPBrandlist RRPBrandList { get; }

        public MDDFile MDDFile { get; }

        public ProjectSettingsControl ProjectSettingsControl { get; }

        public Document MDD_Document { get; set; }

        public DimensionsExport(MDDFile mddFile, TobaccoBrandlist tobaccoBrandList, RRPBrandlist rrpBrandlist, ProjectSettingsControl projectSettingsControl) : base(tobaccoBrandList, rrpBrandlist)
        {
            TobaccoBrandList = tobaccoBrandList;
            RRPBrandList = rrpBrandlist;
            MDDFile = mddFile;

            ProjectSettingsControl = projectSettingsControl;

            CreateAndOpenDocument();
        }

        private bool IsSuccessful { get; set; }

        public override string Dir => $@"C:\Users\{Environment.UserName}\Documents\Brandlist Export Assistant\{ProjectSettings.CountryName}\JTI - {ProjectSettings.CountryName} {ProjectSettings.ProjectType} {ProjectSettings.Wave}\DimensionsExport\";

        public override void ExportData()
        {
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            if (ProjectSettings.RRPExport)
            {
                ExportRRPBrandlists();
            }

            if (ProjectSettings.TobaccoExport)
            {
                ExportTobaccoBrandlist();
                ExportCountry_Q();
            }

            SaveAndOpen();
        }

        private void CreateBrandQuestion(List<MainBrand> brandList, string brandListName)
        {
            IElements listMainBrands = MDD_Document.CreateElements(brandListName, "");
            MDD_Document.Types.Add(listMainBrands, 0);

            foreach (var brand in brandList)
            {
                if (brand.GlobalLabel.Contains("&") || brand.LocalLabel.Contains("&"))
                {
                    brand.GlobalLabel = brand.GlobalLabel.Replace("&", "&amp;");
                    brand.LocalLabel = brand.LocalLabel.Replace("&", "&amp;");
                }

                IElement element = MDD_Document.CreateElement(brand.TrackerCode, brand.GlobalLabel);
                element.Properties["SKU_List"] = "{" + string.Join(",", brand.SubBrandList.Select(x => x.TrackerCode)) + "}";

                listMainBrands.Add(element);

                for (int i = 0; i < MDD_Document.Languages.Count; i++)
                {
                    MDD_Document.Languages.Current = MDD_Document.Languages[i].Name;

                    if (MDD_Document.Languages.Current == "ENU")
                    {
                        element.Label = brand.GlobalLabel;
                    }
                    else
                    {
                        element.Label = brand.LocalLabel;
                    }

                    if (i == 2)
                    {
                        element.Label = brand.SecondLocalLabel;
                    }
                }
            }
        }

        private void CreateSubBrandQuestion(List<SubBrand> subBrandList, string subBrandListName)
        {
            IElements listSubBrands = MDD_Document.CreateElements(subBrandListName, "");
            MDD_Document.Types.Add(listSubBrands, 1);

            foreach (var subBrand in subBrandList)
            {
                if (subBrand.GlobalLabel.Contains("&") || subBrand.LocalLabel.Contains("&"))
                {
                    subBrand.GlobalLabel = subBrand.GlobalLabel.Replace("&", "&amp;");
                    subBrand.LocalLabel = subBrand.LocalLabel.Replace("&", "&amp;");
                }

                IElement element;

                element = MDD_Document.CreateElement(subBrand.TrackerCode, subBrand.GlobalLabel);
                element.Properties["ProductGroup"] = subBrand.ProductGroup;

                listSubBrands.Add(element);

                for (int i = 0; i < MDD_Document.Languages.Count; i++)
                {
                    MDD_Document.Languages.Current = MDD_Document.Languages[i].Name;

                    element.Label = MDD_Document.Languages.Current == "ENU" ? subBrand.GlobalLabel : subBrand.LocalLabel;

                    if (i == 2)
                    {
                        element.Label = subBrand.SecondLocalLabel;
                    }
                }
            }
        }

        public void ExportRRPBrandlists()
        {
            var ecigFullBrandListName = $"List_Ecig_Brands_Full";
            var ecigCoreBrandListName = $"List_Ecig_Brands_Core";
            var ecigBIBrandListName = $"List_Ecig_Brands_BI";
            var ecigSubBrandsListName = $"List_ECIG_SubBrands";

            string[] lists = { ecigFullBrandListName, ecigCoreBrandListName, ecigBIBrandListName, ecigSubBrandsListName};

            // Remove all lists + master lists.
            foreach (var list in lists)
            {
                if (MDD_Document.Types.Exist[list])
                {
                    MDD_Document.Types.Remove(list);
                }
            }

            CreateBrandQuestion(RRPBrandList.Brands, ecigFullBrandListName);

            CreateBrandQuestion(RRPBrandList.CoreList, ecigCoreBrandListName);

            CreateBrandQuestion(RRPBrandList.BIList, ecigBIBrandListName);

            CreateSubBrandQuestion(RRPBrandList.SubBrands, ecigSubBrandsListName);
        }

        public void ExportTobaccoBrandlist()
        {
            var masterBrandListName = $"List_Main_Brands_HUN";
            var mastersubBrandListName = $"List_SubBrands_HUN";

            var mainBrandListName = $"List_Main_Brands_" + tobaccoBrandlist.CountryCode;
            var subBrandListName = $"List_SubBrands_" + tobaccoBrandlist.CountryCode;

            var xxxMainListName = "List_Main_Brands_XXX";
            var xxxSubBrandListName = "List_SubBrands_XXX";

            string[] lists = { masterBrandListName, mastersubBrandListName, mainBrandListName, subBrandListName, xxxMainListName, xxxSubBrandListName };

            // Remove all lists + master lists.
            foreach (var list in lists)
            {
                if (MDD_Document.Types.Exist[list])
                {
                    MDD_Document.Types.Remove(list);
                }
            }
            

            IElements listMainBrands = MDD_Document.CreateElements(mainBrandListName, "Brand");
            MDD_Document.Types.Add(listMainBrands, 0);

            foreach (var brand in tobaccoBrandlist.Brands)
            {
                if (brand.GlobalLabel.Contains("&") || brand.LocalLabel.Contains("&"))
                {
                    brand.GlobalLabel = brand.GlobalLabel.Replace("&", "&amp;");
                    brand.LocalLabel = brand.LocalLabel.Replace("&", "&amp;");
                }

                IElement element = MDD_Document.CreateElement(brand.TrackerCode, brand.GlobalLabel);

                element.Properties["SKU_List"] = "{" + string.Join(",", brand.SubBrandList.Select(x => x.TrackerCode)) + "}";
                element.Properties["Value"] = int.Parse(brand.TrackerCode.Replace("br_", ""));
                element.Properties["Salto_Code"] = brand.TrackerCode;

                //if (ui.customPropertyCheckBox.Checked)
                //{
                //    element.Properties["Custom_Property"] = brand.CustomProperty;
                //}

                var values = new[] { "9998", "9999" };

                if (values.Any(brand.BrandCode.Contains))
                {
                    element.Flag = CategoryFlagConstants.flExclusive;
                }

                listMainBrands.Add(element);

                for (int i = 0; i < MDD_Document.Languages.Count; i++)
                {
                    MDD_Document.Languages.Current = MDD_Document.Languages[i].Name;

                    if (MDD_Document.Languages.Current == "ENU")
                    {
                        element.Label = brand.GlobalLabel;
                    }
                    else
                    {
                        element.Label = brand.LocalLabel;
                    }

                    if (i == 2)
                    {
                        element.Label = brand.SecondLocalLabel;
                    }
                }
            }
            // {Main Brand List Creation End}

            // {Main XXX List Creation Start}
            IElements xxxMainBrands = MDD_Document.CreateElements(xxxMainListName);
            MDD_Document.Types.Add(xxxMainBrands);

            xxxMainBrands.Reference = listMainBrands;
            xxxMainBrands.Namespace = false;
            xxxMainBrands.Inline = true;
            // {Main XXX List Creation End}


            // {Sub Brand List Creation Start}
            IElements listSubBrands = MDD_Document.CreateElements(subBrandListName, "SKU");
            MDD_Document.Types.Add(listSubBrands, 1);

            foreach (var subBrand in tobaccoBrandlist.SubBrands)
            {
                if (subBrand.GlobalLabel.Contains("&") || subBrand.LocalLabel.Contains("&"))
                {
                    subBrand.GlobalLabel = subBrand.GlobalLabel.Replace("&", "&amp;");
                    subBrand.LocalLabel = subBrand.LocalLabel.Replace("&", "&amp;");
                }

                IElement element;

                element = MDD_Document.CreateElement(subBrand.TrackerCode, subBrand.GlobalLabel);
                element.Properties["Value"] = int.Parse(subBrand.TrackerCode.Replace("br_", ""));
                element.Properties["Salto_Code"] = subBrand.TrackerCode;
                
                if (tobaccoBrandlist.ExportCustomProperty)
                {
                    element.Properties["Custom_Property"] = subBrand.CustomProperty;
                }

                listSubBrands.Add(element);

                for (int i = 0; i < MDD_Document.Languages.Count; i++)
                {
                    MDD_Document.Languages.Current = MDD_Document.Languages[i].Name;

                    if (MDD_Document.Languages.Current == "ENU")
                    {
                        element.Label = subBrand.GlobalLabel;
                    }
                    else
                    {
                        element.Label = subBrand.LocalLabel;
                    }

                    if (i == 2)
                    {
                        element.Label = subBrand.SecondLocalLabel;
                    }
                }
            }
            // {Sub Brand List Creation End}

            // {SubBrands XXX List Creation Start}
            IElements xxxSubBrands = MDD_Document.CreateElements(xxxSubBrandListName);
            MDD_Document.Types.Add(xxxSubBrands);

            xxxSubBrands.Reference = listSubBrands;
            xxxSubBrands.Namespace = false;
            xxxSubBrands.Inline = true;
            // {SubBrands XXX List Creation End}
        }

        public void ExportCountry_Q()
        {
            if (MDD_Document.Fields.Exist["COUNTRY_Q"])
            {
                MDD_Document.Fields.Remove("COUNTRY_Q");
            }

            IVariable country_Q = MDD_Document.CreateVariable("COUNTRY_Q");

            country_Q.DataType = DataTypeConstants.mtCategorical;
            country_Q.MinValue = 1;
            country_Q.MaxValue = 1;

            MDD_Document.Fields.Add(country_Q, 0);

            IElement category = MDD_Document.CreateElement("_" + tobaccoBrandlist.MarketCode.ToString());
            country_Q.Elements.Add(category);

            for (int i = 0; i < MDD_Document.Languages.Count; i++)
            {
                MDD_Document.Languages.Current = MDD_Document.Languages[i].Name;

                category.Label = TobaccoBrandList.CountryName;
                country_Q.Label = "Country";
            }

            var other = tobaccoBrandlist.Brands.First(x => x.BrandCode == "9997").TrackerCode;
            var none = tobaccoBrandlist.Brands.First(x => x.BrandCode == "9999").TrackerCode;
            var dontKnow = tobaccoBrandlist.Brands.First(x => x.BrandCode == "9998").TrackerCode;

            var rmcProducts = tobaccoBrandlist.SubBrands.Where(x => x.Type == ProductType.RMC).Select(x => x.TrackerCode);
            var ryoProducts = tobaccoBrandlist.SubBrands.Where(x => x.Type == ProductType.RYO).Select(x => x.TrackerCode);
            var myoProducts = tobaccoBrandlist.SubBrands.Where(x => x.Type == ProductType.MYO).Select(x => x.TrackerCode);

            category.Properties["ShortName"] = "TEST";
            category.Properties["SurveyLang"] = "";
            category.Properties["DayLimit"] = "1";
            category.Properties["WeekLimit"] = "7";
            category.Properties["OtherResponse"] = "{" + other + "}";
            category.Properties["NoneResponse"] = "{" + none + "}";
            category.Properties["DKResponse"] = "{" + dontKnow + "}";
            category.Properties["NoneDK"] = "{" + none + "," + dontKnow + "}";
            category.Properties["ProjectType"] = "{tracker}";
            category.Properties["ImagesLink"] = "";
            category.Properties["SharedAssetsLink"] = "";
            category.Properties["CurrentWave"] = TobaccoBrandList.CurrentWave;
            category.Properties["OtherResponses"] = "{" + string.Join(",", tobaccoBrandlist.Brands.First(x => x.BrandCode == "9997").SubBrandList.Select(x => x.TrackerCode)) + "}";
            category.Properties["RMC_Products"] = "{" + string.Join(",", rmcProducts) + "}";
            category.Properties["MYO_Products"] = "{" + string.Join(",", myoProducts) + "}";
            category.Properties["RYO_Products"] = "{" + string.Join(",", ryoProducts) + "}";
        }

        public void SaveAndOpen()
        {
            var mddDirectory = MDDFile.FullName.Substring(0, MDDFile.FullName.Length - 4);

            if (!mddDirectory.Contains("_Updated"))
            {
                mddDirectory += "_Updated";
            }

            if (!Validator.IsFileOpen(this, mddDirectory) && IsSuccessful)
            {
                MDD_Document.Save(Dir + MDDFile.ShortName);
                //MDD_Document.Save(mddDirectory + ".mdd");
            }
            else
            {
                return;
            }

            MDD_Document.Close();

            //Process.Start(MDDFile.Path);

            //ui.mddRestartBtn.PerformClick();
        }

        private void CreateAndOpenDocument()
        {
            MDD_Document = new Document();

            MDD_Document.Open(MDDFile.FullName);

            if (!Validator.IsFileOpen(this, MDDFile.FullName))
            {
                
                IsSuccessful = true;
            }
            else
            {
                IsSuccessful = false;
                return;
            }
        }

        //public void RestartExport(MainUI UI)
        //{
        //    UI.mddRestartBtn.PerformClick();

        //    MDD_Document.Close();
        //}
    }
}