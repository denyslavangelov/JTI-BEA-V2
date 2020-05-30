using Brandlist_Export_Assistant_V2.Enums;

namespace Brandlist_Export_Assistant_V2.Classes.Brand
{
    public class SubBrand : Brand
    {
        public string ProductGroup { get; set; }

        public ProductType Type { get; set; }

        public bool HasMainBrand { get; set; }
    }
}
