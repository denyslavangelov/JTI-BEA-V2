using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Brandlist_Export_Assistant_V2
{
    public class Countries
    {
        public static Dictionary<string, string> ExportCountries(string excelCountry)
        {
            var countries = new Dictionary<string, string>();

            const string fileName = "Resources\\Countries.txt";

            const int bufferSize = 128;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var country = line.Substring(0, line.Length - 3);
                    var countryCode = line.Substring(line.Length - 3, 3);

                    if (country.Contains(excelCountry))
                    {
                        countries.Add(country, countryCode);
                        break;
                    }
                }
                streamReader.Close();
            }

            return countries;
        }

        public static List<string> ExportLanguages(string projectCountry)
        {
            var languagesList = new List<string>();

            const string fileName = "Resources\\Countries_iField.txt";

            const int BufferSize = 128;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var country = line.Split('$')[0].Trim();

                    if (country == projectCountry)
                    {
                        var languages = line.Split('$')[1].Trim().Split(',');

                        languagesList.AddRange(languages);
                    }
                }

                streamReader.Close();
            }

            return languagesList;
        }
    }
}
