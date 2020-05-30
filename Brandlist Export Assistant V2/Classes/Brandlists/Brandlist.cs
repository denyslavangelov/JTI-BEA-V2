using System.Collections.Generic;
using Brandlist_Export_Assistant_V2.Classes.Brand;

namespace Brandlist_Export_Assistant_V2.Classes.Brandlists
{
    public class Brandlist
    {
        public List<MainBrand> Brands { get; set; }

        public List<SubBrand> SubBrands { get; set; }

        public List<MainBrand> Exclusives { get; set; }
    }
}
