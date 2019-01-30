using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Converters;
using TTSSLib.Helpers;
using TTSSLib.Interfaces;
using TTSSLib.Models.API;
using TTSSLib.Models.Data;
using TTSSLib.Models.Enums;
using TTSSLib.Models.Internal;

namespace TTSSLib.Services
{
    public class PassageService : IPassageService
    {
        private ResponseReason _respReason;
        public ResponseReason ResponseReason { get { return _respReason; } }

        public async Task<Passages> GetPassagesByStopId(int id, StopPassagesType type = StopPassagesType.Departure, StopType stopType = StopType.Tram | StopType.Bus)
        {
            StopInfo tramInfo;
            StopInfo busInfo;
            if ((stopType & StopType.Tram) == StopType.Tram)
            {
                var response = await Request.StopPassages(id, type, false).ConfigureAwait(false);
                tramInfo = JsonConvert.DeserializeObject<StopInfo>(response.Data);
            }
            else tramInfo = new StopInfo { ActualPassages = new List<StopPassage>(), OldPassages = new List<StopPassage>() };
            if ((stopType & StopType.Bus) == StopType.Bus)
            {
                var response = await Request.StopPassages(id, type, true).ConfigureAwait(false);
                busInfo = JsonConvert.DeserializeObject<StopInfo>(response.Data);
            }
            else busInfo = new StopInfo { ActualPassages = new List<StopPassage>(), OldPassages = new List<StopPassage>() };
            var result = new Passages();
            result.ActualPassages = tramInfo.ActualPassages
                .Concat(busInfo.ActualPassages)
                .OrderBy(p => p.ActualRelativeTime)
                .Select(ap => PassageConverter.Convert(ap))
                .ToList();
            result.OldPassages = tramInfo.OldPassages
                .Concat(busInfo.OldPassages)
                .OrderBy(p => p.ActualRelativeTime)
                .Select(ap => PassageConverter.Convert(ap))
                .ToList();
            return result;
        }

        public async Task<Passages> GetPassagesByStop(StopBase stop, StopPassagesType type = StopPassagesType.Departure, StopType stopType = StopType.Tram | StopType.Bus)
        {
            return await GetPassagesByStopId(stop.ID, type, stopType).ConfigureAwait(false);
        }

        public async Task<TripPassages> GetPassagesByTripId(string id, StopPassagesType type = StopPassagesType.Departure, StopType stopType = StopType.Tram | StopType.Bus)
        {
            var response = await Request.TripPassages(id, type).ConfigureAwait(false);
            var passage = JsonConvert.DeserializeObject<TripInfo>(response.Data);
            var result = new TripPassages();
            result.Direction = passage.DirectionText;
            result.RouteName = passage.RouteName;
            result.ActualPassages = passage.ActualPassages.Select(ap => PassageConverter.Convert(ap)).ToList();
            result.OldPassages = passage.OldPassages.Select(ap => PassageConverter.Convert(ap)).ToList();
            return result;
        }
    }
}
