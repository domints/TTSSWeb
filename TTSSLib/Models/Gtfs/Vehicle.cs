using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTSSLib.Models.Gtfs
{
    public class GtfsVehicle
    {
        public long TtssId { get; set; }
        public long GtfsId { get; set; }
        public string SideNo { get; set; }
        public GtfsVehicleModel Model { get; set; }
        public bool IsHeuristic { get; set; }
        public int HeuristicScore { get; set; }

        public override string ToString()
        {
            return $"{SideNo} - {GtfsId:D3} - {TtssId} - {(IsHeuristic ? "?" : "")}";
        }
    }
}