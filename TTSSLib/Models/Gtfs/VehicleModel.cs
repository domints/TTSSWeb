using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTSSLib.Models.Enums;

namespace TTSSLib.Models.Gtfs
{
    public class GtfsVehicleModel
    {
        public string Name { get; set; }
        public VehicleFloorType LowFloor { get; set; }
        public GtfsVehicleType Type { get; set; }
    }
}