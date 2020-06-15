using Brandlist_Export_Assistant_V2.Classes.Brandlists;

namespace Brandlist_Export_Assistant_V2.Classes.Exports
{
    public abstract class Export
    {
        protected readonly TobaccoBrandlist TobaccoBrandlist;
        protected readonly RRPBrandlist RRPBrandlist;

        protected Export(TobaccoBrandlist tobaccoBrandlist)
        {
            this.TobaccoBrandlist = tobaccoBrandlist;
        }

        protected Export(RRPBrandlist rrpBrandList)
        {
            this.RRPBrandlist = rrpBrandList;
        }
    }
}
