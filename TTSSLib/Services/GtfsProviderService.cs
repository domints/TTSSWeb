using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TTSSLib.Interfaces;
using TTSSLib.Models.Gtfs;

namespace TTSSLib.Services
{
    public class GtfsProviderService : IGtfsProviderService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://gtfs.dszymanski.pl";
        public GtfsProviderService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<GtfsVehicle>> GetVehiclesForIds(GtfsVehicleType type, List<long> ids)
        {
            var url = $"{BaseUrl}/vehicles/manyByTtss?Type={type}&ids={string.Join(",", ids)}";
            var jsonResponse = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<GtfsVehicle>>(jsonResponse);
        }
    }
}