using System;

namespace TTSSLib.Models.Gtfs
{
    [Flags]
    public enum GtfsVehicleType
    {
        None = 0,
        Tram = 1,
        Bus = 2
    }
}