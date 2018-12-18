using System.Threading.Tasks;
using TTSSLib.Models.Enums;
using TTSSLib.Models.Internal;

namespace TTSSLib.Helpers
{
    internal static class Request
    {
        internal static async Task<Response> AllRoutes()
        {
            return await HttpHelper.GetString(Addresses.AllRoutes).ConfigureAwait(false);
        }

        internal static async Task<Response> AllStops()
        {
            return await HttpHelper.GetString(Addresses.AllStops).ConfigureAwait(false);
        }

        internal static async Task<Response> AutoComplete(string query)
        {
            return await HttpHelper.GetString(string.Format(Addresses.Autocomplete, query)).ConfigureAwait(false);
        }

        internal static async Task<Response> StopPassages(int stopId, StopPassagesType type)
        {
            string stype = string.Empty;
            switch (type)
            {
                case StopPassagesType.Arrival:
                    stype = "arrival";
                    break;
                case StopPassagesType.Departure:
                    stype = "departure";
                    break;
            }

            return await HttpHelper.GetString(string.Format(Addresses.PassageInfo, stopId, stype)).ConfigureAwait(false);
        }

        internal static async Task<Response> TripPassages(string tripId, StopPassagesType type)
        {
            string stype = string.Empty;
            switch (type)
            {
                case StopPassagesType.Arrival:
                    stype = "arrival";
                    break;
                case StopPassagesType.Departure:
                    stype = "departure";
                    break;
            }

            return await HttpHelper.GetString(string.Format(Addresses.TripPassages, tripId, stype)).ConfigureAwait(false);
        }
    }
}
