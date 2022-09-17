using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.Enums;

namespace TTSSLib.Models.Data
{
    public class StopData : StopBase
    {
        public new string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public StopType Type { get; set; }

        public override string ToString()
        {
            return base.ToString() + $":{Latitude}:{Longitude}:{Type}";
        }
    }
}
