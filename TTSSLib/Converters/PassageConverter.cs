using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Helpers;
using TTSSLib.Models.API;
using TTSSLib.Models.Data;

namespace TTSSLib.Converters
{
    internal class PassageConverter
    {
        internal static Passage Convert(StopPassage passage, Dictionary<string, Vehicle> vehicleLookup, bool isBus = false)
        {
            Vehicle vehicle = null;
            if (!string.IsNullOrWhiteSpace(passage.VehicleID) && vehicleLookup.ContainsKey(passage.VehicleID))
                vehicle = vehicleLookup[passage.VehicleID];
            return new Passage
            {
                ActualRelative = passage.ActualRelativeTime,
                ActualTime = passage.ActualTime != null ? TimeSpan.ParseExact(passage.ActualTime, "g", System.Globalization.CultureInfo.InvariantCulture) : new TimeSpan(),
                PlannedTime = TimeSpan.ParseExact(passage.PlannedTime, "g", System.Globalization.CultureInfo.InvariantCulture),
                MixedTime = passage.MixedTime,
                Direction = passage.Direction,
                Line = passage.PatternText,
                Status = PassageStatusConverter.Convert(passage.StatusString),
                Vehicle = vehicle,
                TripId = passage.TripID,
                IsBus = isBus
            };
        }

        internal static Models.Data.TripPassage Convert(Models.API.TripPassage passage)
        {
            return new Models.Data.TripPassage
            {
                ActualTime = passage.ActualTime != null ? TimeSpan.ParseExact(passage.ActualTime, "g", System.Globalization.CultureInfo.InvariantCulture) : (passage.PlannedTime != null ? TimeSpan.ParseExact(passage.PlannedTime, "g", System.Globalization.CultureInfo.InvariantCulture) : new TimeSpan()),
                Status = PassageStatusConverter.Convert(passage.StatusString),
                SeqNumber = passage.SequenceNo,
                StopId = passage.Stop?.ID,
                StopName = passage.Stop?.Name
            };
        }
    }
}
