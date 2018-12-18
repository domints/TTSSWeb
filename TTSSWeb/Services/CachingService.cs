using System;
using System.Collections.Generic;
using TTSSWeb.Helpers;

namespace TTSSWeb.Services
{
    public static class CachingService
    {
        static Dictionary<string, object> caches;

        public static CachingDictionary<TKey, TValue> Get<TKey, TValue>(string dictName, Func<TKey, TValue> retrieveMethod, TimeSpan? validFor = null) {
            if(!caches.ContainsKey(dictName))
            {
                caches.Add(dictName, new CachingDictionary<TKey, TValue>(retrieveMethod));
            }

            return (CachingDictionary<TKey, TValue>)caches[dictName];
        }
    }
}