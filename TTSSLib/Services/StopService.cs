using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TTSSLib.Converters;
using TTSSLib.Helpers;
using TTSSLib.Interfaces;
using TTSSLib.Models.API;
using TTSSLib.Models.Data;
using TTSSLib.Models.Enums;

namespace TTSSLib.Services
{
    public class StopService : IStopService
    {
        public async Task<List<StopData>> GetAllStops(StopType requestedTypes = StopType.Other | StopType.Tram | StopType.Bus)
        {
            IEnumerable<StopData> tramFiltered = Enumerable.Empty<StopData>();
            IEnumerable<StopData> busFiltered = Enumerable.Empty<StopData>();

            if ((requestedTypes & StopType.Tram) == StopType.Tram)
            {
                var tramResponse = await Request.AllStops(false).ConfigureAwait(false);
                var tramPreparsed = JsonConvert.DeserializeObject<GeoStops>(tramResponse.Data).Stops;
                tramFiltered = tramPreparsed.Select(s => new StopData
                {
                    ID = int.Parse(s.ShortName),
                    Latitude = (double)s.Latitude.ToCoordinate(),
                    Longitude = (double)s.Longitude.ToCoordinate(),
                    Name = s.Name,
                    Type = StopCategoryConverter.Convert(s.Category)
                })
                .Where(s => (requestedTypes & s.Type) == s.Type);
            }
            if ((requestedTypes & StopType.Bus) == StopType.Bus)
            {
                var busResponse = await Request.AllStops(true).ConfigureAwait(false);
                var busPreparsed = JsonConvert.DeserializeObject<GeoStops>(busResponse.Data).Stops;
                busFiltered = busPreparsed.Select(s => new StopData
                {
                    ID = int.Parse(s.ShortName),
                    Latitude = (double)s.Latitude.ToCoordinate(),
                    Longitude = (double)s.Longitude.ToCoordinate(),
                    Name = s.Name,
                    Type = StopCategoryConverter.Convert(s.Category)
                })
                .Where(s => (requestedTypes & s.Type) == s.Type);
            }

            Dictionary<int, StopData> tramStops = tramFiltered.ToDictionary(k => k.ID);
            HashSet<int> matched = new HashSet<int>();

            return busFiltered.Select(bf =>
            {
                if (tramStops.ContainsKey(bf.ID))
                {
                    bf.Type = bf.Type | tramStops[bf.ID].Type;
                    matched.Add(bf.ID);
                }

                return bf;
            }).
            Concat(tramFiltered.Where(tf => !matched.Contains(tf.ID)))
            .OrderByDescending(s => s.Name)
            .ToList();
        }

        public async Task<List<StopBase>> GetCompletionFromService(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length <= 1)
            {
                return new List<StopBase>();
            }

            var response = await Request.AutoComplete(name).ConfigureAwait(false);

            var preparsed = JsonConvert.DeserializeObject<List<Stop>>(response.Data);

            return preparsed
                .Where(s => s.Type == "stop")
                .Select(s => new StopBase { ID = s.ID, Name = WebUtility.HtmlDecode(s.Name) })
                .ToList();
        }
    }
}
