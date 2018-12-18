using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTSSLib.Helpers
{
    internal static class GeoHelper
    {
        internal static decimal ToCoordinate(this int mpkCoord)
        {
            return mpkCoord / 3600000.0m;
        }
    }
}
