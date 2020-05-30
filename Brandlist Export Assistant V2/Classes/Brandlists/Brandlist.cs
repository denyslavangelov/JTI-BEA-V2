using Brandlist_Export_Assistant.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brand;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brandlist_Export_Assistant_V2.Classes
{
    public class Brandlist
    {
        public string CountryName { get; set; }

        public string CurrentWave { get; set; }

        public string CountryCode => Countries.ExportCountries(Regex.Replace(CountryName, @"\s+", "")).FirstOrDefault(x => x.Key == Regex.Replace(CountryName, @"\s+", "")).Value;

        public List<MainBrand> Brands { get; set; }

        public List<SubBrand> SubBrands { get; set; }

        public List<MainBrand> Exclusives { get; set; }

        public Brandlist(TobaccoSheet sheet)
        {
            ProjectSettings.CountryName = sheet.Data.SelectMany(x => x.Value).ElementAt(sheet.CountryCoulmnIndex).Value.ElementAt(sheet.CountryCoulmnIndex);
           // ProjectSettings.Wave = Regex.Match(sheet.Sheet.Name, @"(W\d{1,1})").Groups[1].Value;
        }

        public Brandlist(RRPSheet sheet)
        {
            ProjectSettings.CountryName = sheet.Data.SelectMany(x => x.Value).ElementAt(sheet.CountryCoulmnIndex).Value.ElementAt(sheet.CountryCoulmnIndex);
           // ProjectSettings.Wave = Regex.Match(sheet.Sheet.Name, @"(W\d{1,1})").Groups[1].Value;
        }
    }
}
