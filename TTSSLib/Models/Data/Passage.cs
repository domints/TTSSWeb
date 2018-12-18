using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.Enums;

namespace TTSSLib.Models.Data
{
    public class Passage
    {
        public string Line { get; set; }
        public string Direction { get; set; }
        public TimeSpan ActualTime { get; set; }
        public TimeSpan PlannedTime { get; set; }
        public int ActualRelative { get; set; }
        public string MixedTime { get; set; }
        public PassageStatus Status { get; set; }
        public Vehicle Vehicle { get; set; }
        public string TripId { get; set; }

        public override string ToString()
        {
            return $"{Line}|{Direction}|{ActualTime}|{PlannedTime}|{ActualRelative}|{MixedTime}|{Status}";
        }
    }
}
