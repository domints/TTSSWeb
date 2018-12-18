using System.Threading.Tasks;
using TTSSLib.Models.Data;
using TTSSLib.Models.Enums;

namespace TTSSLib.Interfaces
{
    public interface IPassageService
    {
        ResponseReason ResponseReason { get; }
        Task<Passages> GetPassagesByStopId(int id, StopPassagesType type = StopPassagesType.Departure);
        Task<Passages> GetPassagesByStop(StopBase stop, StopPassagesType type = StopPassagesType.Departure);
        Task<Passages> GetPassagesByTripId(string id, StopPassagesType type = StopPassagesType.Departure);
    }
}
