﻿using Brandlist_Export_Assistant_V2.Enums;

namespace Brandlist_Export_Assistant_V2.Classes
{
    public static class ProjectSettings
    {
        public static string CountryName { get; set; }
        public static string Wave { get; set; }
        public static bool RRPExport { get; set; }
        public static bool TobaccoExport { get; set; }
        public static Methodology Methodology { get; set; }
        public static ProjectType ProjectType { get; set; }
        public static Platform Platform { get; set; }
        public static string TobaccoSheetName { get; set; }
        public static string RRPSheetName { get; set; }
        public static string CountryCode { get; set; }
        public static bool TobaccoSecondLocalExported { get; set; }
        public static bool TobaccoCustomPropertyExported { get; set; }
        public static bool RRPSecondLocalExported { get; set; }
        public static bool RRPCustomPropertyExported { get; set; }

        public static void SetProjectSettings(bool rrpExport, bool tobaccoExport, Methodology methodology, ProjectType projectType, Platform platform,string tobaccoSheetName,string rrpSheetName)
        {
            RRPExport = rrpExport;
            TobaccoExport = tobaccoExport;
            Methodology = methodology;
            ProjectType = projectType;
            Platform = platform;
            TobaccoSheetName = tobaccoSheetName;
            RRPSheetName = rrpSheetName;
        }
    }
}
