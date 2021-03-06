﻿using System.Collections.Generic;
using System.Linq;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;

namespace Brandlist_Export_Assistant_V2.Classes.Brand
{
    public class MainBrand : Brand
    {
        public MainBrand()
        {
            SubBrandList = new List<SubBrand>();
        }

        public List<SubBrand> SubBrandList { get; set; }

        public bool IsExclusive { get; set; }

        public bool HasAnySubBrands { get; set; }

        public bool ContainedInCoreList { get; set; }

        public bool ContainedInBIList { get; set; }

        public void PopulateBrandsWithSubBrands(Brandlist brandList, MainBrand brand)
        {
            foreach (var subBrand in brandList.SubBrands.Where(subBrand => subBrand.BrandCode.Contains(brand.BrandCode)))
            {
                brand.SubBrandList.Add(subBrand);
                subBrand.HasMainBrand = true;
                brand.HasAnySubBrands = true;
            }
        }
    }
}
