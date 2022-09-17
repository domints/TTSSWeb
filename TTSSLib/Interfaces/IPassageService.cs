using System.Threading.Tasks;
using TTSSLib.Models.Data;
using TTSSLib.Models.Enums;

namespace TTSSLib.Interfaces
{
    public interface IPassageService
    {
        ResponseReason ResponseReason { get; }
        Task<Passages> GetPassagesByStopId(int id, StopPassagesType type = StopPassagesType.Departure, StopType stopType = StopType.Tram | StopType.Bus);
        Task<Passages> GetPassagesByStop(StopBase stop, StopPassagesType type = StopPassagesType.Departure, StopType stopType = StopType.Tram | StopType.Bus);
        Task<TripPassages> GetPassagesByTripId(string id, bool isBus, StopPassagesType type = StopPassagesType.Departure);
    }
}
