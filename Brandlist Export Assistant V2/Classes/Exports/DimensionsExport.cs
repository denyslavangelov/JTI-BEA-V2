using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Brandlist_Export_Assistant_V2.Classes.Brand;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;
using Brandlist_Export_Assistant_V2.Controls;
using Brandlist_Export_Assistant_V2.Enums;
using MDMLib;

namespace Brandlist_Export_Assistant_V2.Classes.Exports
{

    public class DimensionsExport : Export
    {
        private TobaccoBrandlist TobaccoBrandList { get; }

        private RRPBrandlist RRPBrandList { get; }

        private MDDFile MDDFile { get; }

        public Document MDD_Document { get; set; }

        public DimensionsExport(MDDFile mddFile, TobaccoBrandlist tobaccoBrandList) : base(tobaccoBrandList)
        {
            TobaccoBrandList = tobaccoBrandList;
            MDDFile = mddFile;

            CreateAndOpenDocument();
        }

        public DimensionsExport(MDDFile mddFile, RRPBrandlist rrpBrandlist) : base(rrpBrandlist)
        {
            RRPBrandList = rrpBrandlist;
            MDDFile = mddFile;

            CreateAndOpenDocument();
        }

        private bool IsSuccessful { get; set; }

        public virtual string Dir => $@"C:\Users\{Environment.UserName}\Documents\Brandlist Export Assistant\{ProjectSettings.CountryName}\JTI - {ProjectSettings.CountryName} {ProjectSettings.ProjectType} {ProjectSettings.Wave}\DimensionsExport\";

        public virtual void ExportData()
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

        private void CreateBrandQuestion(IEnumerable<MainBrand> brandList, string brandListName)
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

        private void CreateSubBrandQuestion(IEnumerable<SubBrand> subBrandList, string subBrandListName)
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

                var element = MDD_Document.CreateElement(subBrand.TrackerCode, subBrand.GlobalLabel);
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

            var mainBrandListName = $"List_Main_Brands_TEST" + ProjectSettings.CountryCode;
            var subBrandListName = $"List_SubBrands_TEST" + ProjectSettings.CountryCode;

            var xxxMainListName = "List_Main_Brands_XXX";
            var xxxSubBrandListName = "List_SubBrands_XXX";

            string[] lists = { masterBrandListName, mastersubBrandListName, mainBrandListName, subBrandListName };

            //Remove all lists (except the XXX ones).
            foreach (var list in lists)
            {
                if (MDD_Document.Types.Exist[list])
                {
                    MDD_Document.Types.Remove(list);
                }
            }

            IElements listMainBrands = MDD_Document.CreateElements(mainBrandListName, "Brand");
            MDD_Document.Types.Add(listMainBrands, 0);

            foreach (var brand in TobaccoBrandlist.Brands)
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

                for (var i = 0; i < MDD_Document.Languages.Count; i++)
                {
                    MDD_Document.Languages.Current = MDD_Document.Languages[i].Name;

                    element.Label = MDD_Document.Languages.Current == "ENU" ? brand.GlobalLabel : brand.LocalLabel;

                    if (i == 2)
                    {
                        element.Label = brand.SecondLocalLabel;
                    }
                }
            }
            // {Main Brand List Creation End}

            IElements xxxMainBrands = MDD_Document.Types[xxxMainListName];
            xxxMainBrands.Reference = listMainBrands;

            // {Sub Brand List Creation Start}
            IElements listSubBrands = MDD_Document.CreateElements(subBrandListName, "SKU");
            MDD_Document.Types.Add(listSubBrands, 1);

            foreach (var subBrand in TobaccoBrandlist.SubBrands)
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

                if (TobaccoBrandlist.ExportCustomProperty)
                {
                    element.Properties["Custom_Property"] = subBrand.CustomProperty;
                }

                listSubBrands.Add(element);

                for (var i = 0; i < MDD_Document.Languages.Count; i++)
                {
                    MDD_Document.Languages.Current = MDD_Document.Languages[i].Name;

                    element.Label = MDD_Document.Languages.Current == "ENU" ? subBrand.GlobalLabel : subBrand.LocalLabel;

                    if (i == 2)
                    {
                        element.Label = subBrand.SecondLocalLabel;
                    }
                }
            }
            // {Sub Brand List Creation End}

            IElements xxxSubBrands = MDD_Document.Types[xxxSubBrandListName];
            xxxSubBrands.Reference = listSubBrands;
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

            IElement category = MDD_Document.CreateElement("_" + TobaccoBrandlist.MarketCode.ToString());
            country_Q.Elements.Add(category);

            for (int i = 0; i < MDD_Document.Languages.Count; i++)
            {
                MDD_Document.Languages.Current = MDD_Document.Languages[i].Name;

                category.Label = ProjectSettings.CountryName;
                country_Q.Label = "Country";
            }

            var other = TobaccoBrandlist.Brands.First(x => x.BrandCode == "9997").TrackerCode;
            var none = TobaccoBrandlist.Brands.First(x => x.BrandCode == "9999").TrackerCode;
            var dontKnow = TobaccoBrandlist.Brands.First(x => x.BrandCode == "9998").TrackerCode;

            var rmcProducts = TobaccoBrandlist.SubBrands.Where(x => x.Type == ProductType.RMC).Select(x => x.TrackerCode);
            var ryoProducts = TobaccoBrandlist.SubBrands.Where(x => x.Type == ProductType.RYO).Select(x => x.TrackerCode);
            var myoProducts = TobaccoBrandlist.SubBrands.Where(x => x.Type == ProductType.MYO).Select(x => x.TrackerCode);

            category.Properties["ShortName"] = ProjectSettings.CountryCode;
            category.Properties["DayLimit"] = "1";
            category.Properties["WeekLimit"] = "7";

            switch (ProjectSettings.ProjectType)
            {
                case ProjectType.Incidence:
                    category.Properties["ProjectType"] = "{incidence}";
                    break;
                case ProjectType.OneTracker:
                    category.Properties["ProjectType"] = "{onetracker}";
                    break;
                case ProjectType.Tracker:
                    category.Properties["ProjectType"] = "{tracker}";
                    break;
                case ProjectType.SwitchingBoost:
                    break;
                default:
                    category.Properties["ProjectType"] = "{tracker}";
                    break;
            }

            category.Properties["ImagesLink"] = ProjectSettings.Methodology == Methodology.CAWI ? $"https://images1.ipsosinteractive.com/GOHBG/Programs/JTI/Tracker/{ProjectSettings.CountryName}/{ProjectSettings.ProjectType}/" : "";
            category.Properties["CurrentWave"] = ProjectSettings.Wave;
            category.Properties["OtherResponse"] = "{" + other + "}";
            category.Properties["NoneResponse"] = "{" + none + "}";
            category.Properties["DKResponse"] = "{" + dontKnow + "}";
            category.Properties["NoneDK"] = "{" + none + "," + dontKnow + "}";
            category.Properties["OtherResponses"] = "{" + string.Join(",", TobaccoBrandlist.Brands.First(x => x.BrandCode == "9997").SubBrandList.Select(x => x.TrackerCode)) + "}";
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
                MDD_Document.Save(mddDirectory + ".mdd");
            }
            else
            {
                return;
            }

            MDD_Document.Close();
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
    }
}