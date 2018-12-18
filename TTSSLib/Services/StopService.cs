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
        public async Task<List<StopData>> GetAllStops(StopType requestedTypes = StopType.Other | StopType.Tram)
        {
            var response = await Request.AllStops().ConfigureAwait(false);
            var preparsed = JsonConvert.DeserializeObject<GeoStops>(response.Data).Stops;
            return preparsed.Select(s => new StopData {
                ID = int.Parse(s.ShortName),
                Latitude = (double)s.Latitude.ToCoordinate(),
                Longitude = (double)s.Longitude.ToCoordinate(),
                Name = s.Name,
                Type = StopCategoryConverter.Convert(s.Category)
            })
            .Where(s => (requestedTypes & s.Type) == s.Type)
            .OrderBy(s => s.Name)
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
