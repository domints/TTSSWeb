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
        internal static Passage Convert(StopPassage passage)
        {
            return new Passage
            {
                ActualRelative = passage.ActualRelativeTime,
                ActualTime = passage.ActualTime != null ? TimeSpan.ParseExact(passage.ActualTime, "g", System.Globalization.CultureInfo.InvariantCulture) : new TimeSpan(),
                PlannedTime = TimeSpan.ParseExact(passage.PlannedTime, "g", System.Globalization.CultureInfo.InvariantCulture),
                MixedTime = passage.MixedTime,
                Direction = passage.Direction,
                Line = passage.PatternText,
                Status = PassageStatusConverter.Convert(passage.StatusString),
                Vehicle = passage.GetVehicle()
            };
        }
    }
}
