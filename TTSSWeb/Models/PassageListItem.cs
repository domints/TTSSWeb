using System;
using TTSSLib.Models.Data;
using TTSSLib.Models.Enums;

namespace TTSSWeb.Models
{
    public class PassageListItem
    {
        public PassageListItem()
        { }

        public PassageListItem(Passage passage, bool isOld = false)
        {
            Line = passage.Line;
            Direction = passage.Direction;
            ModelName = passage?.Vehicle?.ModelName;
            SideNo = passage?.Vehicle?.SideNo;
            FloorType = passage?.Vehicle?.FloorType ?? VehicleFloorType.High;
            VehicleId = passage.Vehicle?.RawId;
            MixedTime = passage.Status == PassageStatus.Departed ? $"{passage.ActualRelative / 60} min" : passage.Status == PassageStatus.Stopping ? ">>>>>" : passage.MixedTime.Replace("%UNIT_MIN%", "min");
            DelayMinutes = passage.Status == PassageStatus.Planned ? (int?)null : (int)Math.Ceiling((passage.ActualTime - passage.PlannedTime).TotalMinutes);
            TripId = passage.TripId;

            IsOld = isOld;
            IsBus = passage.IsBus;
        }

        public string Line { get; set; }
        public string Direction { get; set; }
        public string ModelName { get; set; }
        public string SideNo { get; set; }
        public string MixedTime { get; set; }
        public int? DelayMinutes { get; set; }
        public string VehicleId { get; set; }
        public bool IsOld { get; set; }
        public string TripId { get; set; }
        public bool IsBus { get; set; }
        public VehicleFloorType FloorType { get; set; }
    }
}