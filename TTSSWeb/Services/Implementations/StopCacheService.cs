using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTSSLib.Interfaces;
using TTSSLib.Models.Enums;
using TTSSWeb.Models;

namespace TTSSWeb.Services.Implementations
{
    public class StopCacheService : IStopCacheService
    {
        private readonly IStopService _stopService;

        public StopCacheService(IStopService stopService)
        {
            _stopService = stopService;

        }

        private ConcurrentDictionary<int, StopType> StopTypeCache;
        private ConcurrentBag<StopBase> StopsBase;

        public StopType GetStopType(int id)
        {
            if (StopTypeCache == null || StopTypeCache.Count == 0 || !StopTypeCache.ContainsKey(id))
                return StopType.Unknown;

            return StopTypeCache[id];

        }

        public async Task InitStaticData()
        {
            var stops = await _stopService.GetAllStops();
            if(StopTypeCache == null)
                StopTypeCache = new ConcurrentDictionary<int, StopType>();
            if(StopsBase == null)
                StopsBase = new ConcurrentBag<StopBase>();
            
            StopTypeCache.Clear();
            StopsBase.Clear();
            foreach(var stop in stops)
            {
                StopTypeCache.AddOrUpdate(stop.ID, stop.Type, (id, s) => stop.Type);
                StopsBase.Add(new StopBase { Id = stop.ID, Name = stop.Name.Trim() });
            }
        }

        public List<StopBase> GetAutocomplete(string query)
        {
            List<StopBase> results = new List<StopBase>();

            foreach(var s in StopsBase)
            {
                if(results.Count >= 20)
                    return results;

                if(s.Name.ToLower().Contains(query.Trim().ToLower()))
                    results.Add(s);
            }

            return results;
        }
    }
}
