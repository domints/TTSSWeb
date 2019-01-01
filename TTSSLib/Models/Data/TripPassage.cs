using System;
using TTSSLib.Models.Enums;

namespace TTSSLib.Models.Data
{
    public class TripPassage
    {
        public TimeSpan ActualTime { get; set; }
        public PassageStatus Status { get; set; }
        public int SeqNumber { get; set; }
        public string StopId { get; set; }
        public string StopName { get; set; }
    }
}