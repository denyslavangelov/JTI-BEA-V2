using Brandlist_Export_Assistant_V2.Classes.Brandlists;

namespace Brandlist_Export_Assistant_V2.Classes.Exports
{
    public abstract class Export
    {
        protected readonly TobaccoBrandlist TobaccoBrandlist;
        protected readonly RRPBrandlist RrpBrandlist;

        protected Export(TobaccoBrandlist tobaccoBrandlist, RRPBrandlist rrpBrandList)
        {
            this.TobaccoBrandlist = tobaccoBrandlist;
            this.RrpBrandlist = rrpBrandList;
        }
    }
}
