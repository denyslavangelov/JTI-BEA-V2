using Brandlist_Export_Assistant_V2.Classes.Brand;
using Brandlist_Export_Assistant_V2.Enums;
using System.Collections.Generic;
using System.Linq;
using Brandlist_Export_Assistant_V2.Classes.Sheet_Classes;
using Brandlist_Export_Assistant_V2.Controls;

namespace Brandlist_Export_Assistant_V2.Classes.Brandlists
{
    public class TobaccoBrandlist : Brandlist
    { 
        public bool ExportCustomProperty { get; set; }

        public int MarketCode { get; set; }

        public TobaccoBrandlist()
        {
            Brands = new List<MainBrand>();
            SubBrands = new List<SubBrand>();
            Exclusives = new List<MainBrand>(3) { new MainBrand(), new MainBrand(), new MainBrand() };
        }   

        public void PopulateBrands(TobaccoSheet tobaccoSheet, TobaccoSelectionControl tobaccoSelectionControl)
        {
            //Change the column indicator based on the input by user.
            foreach (var inner in tobaccoSheet.Data)
            {
                if (tobaccoSheet.GlobalLabelColumnIndex != inner.Key.FirstOrDefault(x => x.Value == tobaccoSelectionControl.ControlGlobalLabel).Key)
                {
                    tobaccoSheet.GlobalLabelColumnIndex = inner.Key.FirstOrDefault(x => x.Value == tobaccoSelectionControl.ControlGlobalLabel).Key;
                }

                if (tobaccoSheet.LocalLabelColumnIndex != inner.Key.FirstOrDefault(x => x.Value == tobaccoSelectionControl.ControlLocalLabel).Key)
                {
                    tobaccoSheet.LocalLabelColumnIndex = inner.Key.FirstOrDefault(x => x.Value == tobaccoSelectionControl.ControlLocalLabel).Key;
                }

                tobaccoSheet.SecondLocalLabelColumnIndex = inner.Key.FirstOrDefault(x => x.Value == tobaccoSelectionControl.ControlSecondLocalLabel).Key;
                tobaccoSheet.CustomPropertyColumnIndex = inner.Key.FirstOrDefault(x => x.Value == tobaccoSelectionControl.ControlCustomProperty).Key;
            }

            foreach (var data in tobaccoSheet.Data)
            {
                foreach (var row in data.Value)
                {
                    int productType;
                    int marketCode;
                    ProductType brandType;

                    var status = Status.Active;
                    var statusValue = row.Value[tobaccoSheet.StatusColumnIndex];

                    //A brand or a sub brand will be a valid one if its status is "active", otherwise it would be ignored.
                    if (statusValue.Trim().ToLower() != "active")
                    {
                        status = Status.Delisted;
                    }

                    marketCode = int.TryParse(row.Value[tobaccoSheet.MarketCodeColumnIndex], out marketCode) ? marketCode : 0;
                    this.MarketCode = marketCode;

                    productType = int.TryParse(row.Value[tobaccoSheet.ProductTypeColumnIndex], out productType) ? productType : 0;

                    switch (productType)
                    {
                        case 1:
                            brandType = ProductType.RMC;
                            break;
                        case 2:
                            brandType = ProductType.MYO;
                            break;
                        case 3:
                            brandType = ProductType.RYO;
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
                            TrackerCode = "br_" + row.Value[tobaccoSheet.TrackerCodeColumnIndex].Trim(),
                            GlobalLabel = row.Value[tobaccoSheet.GlobalLabelColumnIndex].Trim(),
                            LocalLabel = row.Value[tobaccoSheet.LocalLabelColumnIndex].Trim()
                        };

                        mainBrand.BrandCode = this.MarketCode.ToString().Length == 2
                            ? mainBrand.TrackerCode.Substring(5, 4)
                            : mainBrand.TrackerCode.Substring(6, 4);

                        mainBrand.IsExclusive = new[] { "9999", "9998" }.Any(c => mainBrand.BrandCode.Contains(c)) ? true : false;

                        if (tobaccoSelectionControl.asllSwitch.Checked)
                        {
                            mainBrand.SecondLocalLabel = row.Value[tobaccoSheet.SecondLocalLabelColumnIndex].Trim();
                        }

                        if (tobaccoSelectionControl.ecpSwitch.Checked)
                        {
                            mainBrand.CustomProperty = row.Value[tobaccoSheet.CustomPropertyColumnIndex].Trim();
                        }

                        if (Validator.ValidateBrand(mainBrand, row.Key)) {
                            this.Brands.Add(mainBrand);
                        }
                    }

                    if (status == Status.Active && brandType != ProductType.Brand)
                    {
                        var subBrand = new SubBrand()
                        {
                            TrackerCode = "br_" + row.Value[tobaccoSheet.TrackerCodeColumnIndex].Trim(),
                            GlobalLabel = row.Value[tobaccoSheet.GlobalLabelColumnIndex].Trim(),
                            LocalLabel = row.Value[tobaccoSheet.LocalLabelColumnIndex].Trim(),
                            Type = brandType
                        };

                        subBrand.BrandCode = this.MarketCode.ToString().Length == 2
                            ? subBrand.TrackerCode.Substring(5, 4)
                            : subBrand.TrackerCode.Substring(6, 4);

                        if (tobaccoSelectionControl.asllSwitch.Checked)
                        {
                            subBrand.SecondLocalLabel = row.Value[tobaccoSheet.SecondLocalLabelColumnIndex].Trim();
                        }

                        if (tobaccoSelectionControl.ecpSwitch.Checked)
                        {
                            subBrand.CustomProperty = row.Value[tobaccoSheet.CustomPropertyColumnIndex].Trim();
                        }

                        if (Validator.ValidateBrand(subBrand, row.Key)) {
                            this.SubBrands.Add(subBrand);
                        }
                    }
                }
            }

            foreach (var brand in this.Brands)
            {
                brand.PopulateBrandsWithSubBrands(this, brand);
            }

            MoveExclusiveAnswersToTheEnd();

            Validator.Validate_HasSubBrandList(this.Brands);

            Validator.Validate_HasMainBrand(this.SubBrands);

        }

        public void MoveExclusiveAnswersToTheEnd()
        {
            var values = new[] { "9998", "9997", "9999" };

            foreach (var brand in this.Brands)
            {
                if (values.Any(brand.BrandCode.Contains))
                {
                    switch (brand.BrandCode)
                    {
                        case "9997":
                            this.Exclusives.RemoveAt(0);
                            this.Exclusives.Insert(0, brand);
                            break;
                        case "9999":
                            this.Exclusives.RemoveAt(1);
                            this.Exclusives.Insert(1, brand);
                            break;
                        case "9998":
                            this.Exclusives.RemoveAt(2);
                            this.Exclusives.Insert(2, brand);
                            break;
                    }
                }
            }

            this.Brands = this.Brands.Except(this.Exclusives).ToList();
            this.Brands.AddRange(this.Exclusives);

            for (var i = this.SubBrands.Count - 1; i >= 0; i--)
            {
                if (values.Any(this.SubBrands[i].BrandCode.Contains))
                {
                    this.SubBrands.Insert(this.SubBrands.Count, this.SubBrands[i]);
                    this.SubBrands.RemoveAt(i);
                }
            }
        }
    }
}
