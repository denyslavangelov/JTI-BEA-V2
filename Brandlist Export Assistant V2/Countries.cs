using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Brandlist_Export_Assistant.Classes
{
    public class Countries
    {
        public static Dictionary<string, string> ExportCountries(string excelCountry)
        {
            Dictionary<string, string> countries = new Dictionary<string, string>();

            List<string> list = new List<string>();

            string fileName = "Resources\\Countries.txt";

            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
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
            List<string> languagesList = new List<string>();

            string fileName = "Resources\\Countries_iField.txt";

            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var country = line.Split('$')[0].Trim();

                    if (country == projectCountry)
                    {
                        var languages = line.Split('$')[1].Trim().Split(',');

                        foreach (var language in languages)
                        {
                            languagesList.Add(language);
                        }
                    }
                }

                streamReader.Close();
            }

            return languagesList;
        }
    }
}
