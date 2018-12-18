using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.Enums;

namespace TTSSLib.Converters
{
    internal static class StopCategoryConverter
    {
        internal static StopType Convert(string category)
        {
            switch(category)
            {
                case "tram":
                    return StopType.Tram;

                case "other":
                    return StopType.Other;
            }

            return StopType.Unknown;
        }
    }
}
