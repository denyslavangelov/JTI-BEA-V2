using Brandlist_Export_Assistant.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brand;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brandlist_Export_Assistant_V2.Classes
{
    public class Brandlist
    {
        public List<MainBrand> Brands { get; set; }

        public List<SubBrand> SubBrands { get; set; }

        public List<MainBrand> Exclusives { get; set; }
    }
}
