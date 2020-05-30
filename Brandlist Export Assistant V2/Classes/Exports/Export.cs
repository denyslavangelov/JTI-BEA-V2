using Brandlist_Export_Assistant_V2;
using Brandlist_Export_Assistant_V2.Classes;
using Brandlist_Export_Assistant_V2.Classes.Brandlists;

namespace Brandlist_Export_Assistant.Classes
{
    public abstract class Export
    {
        protected readonly Brandlist brandlist;

        protected readonly TobaccoBrandlist tobaccoBrandlist;
        protected readonly RRPBrandlist rrpBrandlist;

        protected Export(TobaccoBrandlist TobaccoBrandlist, RRPBrandlist RRPBrandList)
        {
            this.tobaccoBrandlist = TobaccoBrandlist;
            this.rrpBrandlist = RRPBrandList;
        }

        protected Export(TobaccoBrandlist TobaccoBrandlist)
        {
            this.tobaccoBrandlist = TobaccoBrandlist;
        }

        protected Export(RRPBrandlist rrpBrandList)
        {
            rrpBrandlist = rrpBrandList;
        }

        public abstract string Dir { get; }

        public abstract void ExportData();
    }
}
