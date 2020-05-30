using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandlist_Export_Assistant_V2
{
    interface ICollectData
    {
        Dictionary<Dictionary<int, string>, Dictionary<int, string[]>> CollectData(Worksheet worksheet);
    }
}
