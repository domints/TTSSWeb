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

        public async Task<Passages> GetPassagesByStopId(int id, StopPassagesType type = StopPassagesType.Departure)
        {
            var response = await Request.StopPassages(id, type).ConfigureAwait(false);
            var passage = JsonConvert.DeserializeObject<StopInfo>(response.Data);
            var result = new Passages();
            result.ActualPassages = passage.ActualPassages.Select(ap => PassageConverter.Convert(ap)).ToList();
            result.OldPassages = passage.OldPassages.Select(ap => PassageConverter.Convert(ap)).ToList();
            return result;
        }

        public async Task<Passages> GetPassagesByStop(StopBase stop, StopPassagesType type = StopPassagesType.Departure)
        {
            return await GetPassagesByStopId(stop.ID, type).ConfigureAwait(false);
        }

        public async Task<Passages> GetPassagesByTripId(string id, StopPassagesType type = StopPassagesType.Departure)
        {
            var response = await Request.TripPassages(id, type).ConfigureAwait(false);
            var passage = JsonConvert.DeserializeObject<TripPassages>(response.Data);
            var result = new Passages();
            result.ActualPassages = passage.ActualPassages.Select(ap => PassageConverter.Convert(ap)).ToList();
            result.OldPassages = passage.OldPassages.Select(ap => PassageConverter.Convert(ap)).ToList();
            return result;
        }
    }
}
