using Brandlist_Export_Assistant_V2.Classes.Brand;
using Brandlist_Export_Assistant_V2.Enums;
using System.Collections.Generic;
using System.Linq;
using Brandlist_Export_Assistant_V2.Classes.Sheet_Classes;
using Brandlist_Export_Assistant_V2.Controls;

namespace Brandlist_Export_Assistant_V2.Classes.Brandlists
{
    public class RRPBrandlist : Brandlist
    {
        public RRPBrandlist()
        {
            Brands = new List<MainBrand>();
            SubBrands = new List<SubBrand>();
            CoreList = new List<MainBrand>();
            BIList = new List<MainBrand>();
        }

        public List<MainBrand> CoreList { get; set; }

        public List<MainBrand> BIList { get; set; }

        public void PopulateBrands(RRPSheet rrpSheet, RRPSelectionControl rrpSelectionControl)
        {
            //Change the column indicator based on the input by user.
            foreach (var inner in rrpSheet.Data)
            {
                if (rrpSheet.GlobalLabelColumnIndex != inner.Key.FirstOrDefault(x => x.Value == rrpSelectionControl.ControlGlobalLabel).Key)
                {
                    rrpSheet.GlobalLabelColumnIndex = inner.Key.FirstOrDefault(x => x.Value == rrpSelectionControl.ControlGlobalLabel).Key;
                }

                if (rrpSheet.LocalLabelColumnIndex != inner.Key.FirstOrDefault(x => x.Value == rrpSelectionControl.ControlLocalLabel).Key)
                {
                    rrpSheet.LocalLabelColumnIndex = inner.Key.FirstOrDefault(x => x.Value == rrpSelectionControl.ControlLocalLabel).Key;
                }

                rrpSheet.SecondLocalLabelColumnIndex = inner.Key.FirstOrDefault(x => x.Value == rrpSelectionControl.ControlSecondLocalLabel).Key;
                rrpSheet.CustomPropertyColumnIndex = inner.Key.FirstOrDefault(x => x.Value == rrpSelectionControl.ControlCustomProperty).Key;
            }

            foreach (var data in rrpSheet.Data)
            {
                foreach (var row in data.Value)
                {
                    int productType;
                    int marketCode;
                    ProductType brandType;

                    var status = Status.Active;
                    var statusValue = row.Value[rrpSheet.StatusColumnIndex];

                    //A brand or a sub brand will be a valid one if its status is "active", otherwise it would be ignored.
                    if (statusValue.Trim().ToLower() != "active")
                    {
                        status = Status.Delisted;
                    }

                    marketCode = int.TryParse(row.Value[rrpSheet.MarketCodeColumnIndex], out marketCode) ? marketCode : 0;
                    productType = int.TryParse(row.Value[rrpSheet.ProductTypeColumnIndex], out productType) ? productType : 0;

                    rrpSheet.MarketCode = marketCode;

                    switch (productType)
                    {
                        case 7:
                            brandType = ProductType.RRP;
                            break;
                        case 9:
                            brandType = ProductType.Brand;
                            break;
                        default:
                            brandType = ProductType.Other;
                            break;
                    }

                    if (status == Status.Active && brandType == ProductType.Brand)
                    {
                        var mainBrand = new MainBrand()
                        {
                            TrackerCode = "br_" + row.Value[rrpSheet.TrackerCodeColumnIndex].Trim(),
                            GlobalLabel = row.Value[rrpSheet.GlobalLabelColumnIndex].Trim(),
                            LocalLabel = row.Value[rrpSheet.LocalLabelColumnIndex].Trim()
                        };

                        mainBrand.ContainedInCoreList = row.Value[rrpSheet.CoreListColumnIndex].Trim().ToLower() == "yes".Trim() ? true : false;
                        mainBrand.ContainedInBIList = row.Value[rrpSheet.BIListColumnIndex].Trim().ToLower() == "yes".Trim() ? true : false;

                        if (mainBrand.ContainedInCoreList)
                        {
                            this.CoreList.Add(mainBrand);
                        }

                        if (mainBrand.ContainedInBIList)
                        {
                            this.BIList.Add(mainBrand);
                        }

                        mainBrand.BrandCode = mainBrand.TrackerCode;

                        mainBrand.IsExclusive = new[] { "9999", "9998" }.Any(c => mainBrand.BrandCode.Contains(c)) ? true : false;

                        if (rrpSelectionControl.asllSwitch.Checked)
                        {
                            mainBrand.SecondLocalLabel = row.Value[rrpSheet.SecondLocalLabelColumnIndex].Trim();
                        }

                        if (rrpSelectionControl.ecpSwitch.Checked)
                        {
                            mainBrand.CustomProperty = row.Value[rrpSheet.CustomPropertyColumnIndex].Trim();
                        }

                        Validator.ValidateBrand(mainBrand, row.Key);
                        this.Brands.Add(mainBrand);
                    }

                    if (status == Status.Active && brandType != ProductType.Brand)
                    {
                        var subBrand = new SubBrand()
                        {
                            TrackerCode = "br_" + row.Value[rrpSheet.TrackerCodeColumnIndex].Trim(),
                            GlobalLabel = row.Value[rrpSheet.GlobalLabelColumnIndex].Trim(),
                            LocalLabel = row.Value[rrpSheet.LocalLabelColumnIndex].Trim(),
                            Type = brandType
                        };

                        var productGroup = row.Value[rrpSheet.ProductGroupColumnIndex].Trim();

                        switch(productGroup)
                        {
                            case "Heated Tobacco":
                                subBrand.ProductGroup = "T-Vape";
                                break;
                            case "E - Vapor":
                                subBrand.ProductGroup = "E-Vape";
                                break;
                            case "Not Applicable":
                                subBrand.ProductGroup = "Not Applicable";
                                break;
                        }

                        subBrand.BrandCode = subBrand.TrackerCode;

                        if (rrpSelectionControl.asllSwitch.Checked)
                        {
                            subBrand.SecondLocalLabel = row.Value[rrpSheet.SecondLocalLabelColumnIndex].Trim();
                        }

                        if (rrpSelectionControl.ecpSwitch.Checked)
                        {
                            subBrand.CustomProperty = row.Value[rrpSheet.CustomPropertyColumnIndex].Trim();
                        }

                        Validator.ValidateBrand(subBrand, row.Key);

                        this.SubBrands.Add(subBrand);
                    }
                }
            }

            foreach (var brand in this.Brands)
            {
                brand.PopulateBrandsWithSubBrands(this, brand);
            }
        }
    }
}
