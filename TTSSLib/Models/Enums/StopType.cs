using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTSSLib.Models.Enums
{
    [Flags]
    public enum StopType : int
    {
        Unknown = 1,
        Tram = 2,
        Other = 4     
    }
}
