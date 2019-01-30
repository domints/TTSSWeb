using System.Collections.Generic;
using System.Threading.Tasks;
using TTSSLib.Models.Enums;
using TTSSWeb.Models;

namespace TTSSWeb.Services
{
    public interface IStopCacheService
    {
         StopType GetStopType(int id);
         Task InitStaticData();
         List<StopBase> GetAutocomplete(string query);
    }
}