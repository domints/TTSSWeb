using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTSSLib.Models.API
{
    internal class GeoStops
    {
        [JsonProperty("stops")]
        public List<GeoStop> Stops { get; set; }
    }
}
