using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.Enums;

namespace TTSSLib.Models.Data
{

    public class Vehicle
    {
        public string RawId { get; set; }
        public int? ID { get; set; }
        public VehicleFloorType FloorType { get; set; }
        public string SideNo { get; set; }
        public string ModelName { get; set; }
    }
}
