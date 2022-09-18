using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTSSLib.Models.Gtfs;

namespace TTSSLib.Interfaces
{
    public interface IGtfsProviderService
    {
        Task<List<GtfsVehicle>> GetVehiclesForIds(GtfsVehicleType type, List<long> ids);
    }
}