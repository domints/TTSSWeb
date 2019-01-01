using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTSSLib.Interfaces;
using TTSSWeb.Models;

namespace TTSSWeb.Services
{
    public class AutocompleteService : IAutocompleteService
    {
        private ConcurrentDictionary<string, Lazy<Task<ICollection<StopBase>>>> data 
            = new ConcurrentDictionary<string, Lazy<Task<ICollection<StopBase>>>>();
        private readonly IStopService stopService;

        public AutocompleteService(IStopService stopService)
        {
            this.stopService = stopService;
        }

        public Task<ICollection<StopBase>> GetAutocomplete(string query)
        {
            if(string.IsNullOrWhiteSpace(query))
                return Task.FromResult((ICollection<StopBase>)new List<StopBase>());
                
            return data.GetOrAdd(query, (key) => GetLazyResult(key)).Value;
        }

        private Lazy<Task<ICollection<StopBase>>> GetLazyResult(string query)
        {
            return new Lazy<Task<ICollection<StopBase>>>(
                async () =>
                    (await this.stopService.GetCompletionFromService(query))
                        .Select(s => new StopBase { Id = s.ID, Name = s.Name }).ToList());
        }
    }
}