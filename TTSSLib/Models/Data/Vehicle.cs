using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.Enums;
using TTSSLib.Models.Gtfs;

namespace TTSSLib.Models.Data
{

    public class Vehicle
    {
        public string RawId { get; set; }
        public VehicleFloorType FloorType { get; set; }
        public string SideNo { get; set; }
        public string ModelName { get; set; }

        public static Vehicle FromGtfsVehicle(GtfsVehicle source)
        {
            return new Vehicle
            {
                RawId = source.TtssId.ToString(),
                FloorType = source.Model.LowFloor,
                SideNo = source.SideNo,
                ModelName = source.Model.Name
            };
        }
    }
}
