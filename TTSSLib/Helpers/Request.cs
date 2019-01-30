using System.Threading.Tasks;
using TTSSLib.Models.Enums;
using TTSSLib.Models.Internal;

namespace TTSSLib.Helpers
{
    internal static class Request
    {
        internal static async Task<Response> AllRoutes(bool bus = false)
        {
            return await HttpHelper.GetString(Addresses.AllRoutes, bus).ConfigureAwait(false);
        }

        internal static async Task<Response> AllStops(bool bus)
        {
            return await HttpHelper.GetString(Addresses.AllStops, bus).ConfigureAwait(false);
        }

        internal static async Task<Response> AutoComplete(string query, bool bus = false)
        {
            return await HttpHelper.GetString(string.Format(Addresses.Autocomplete, query), bus).ConfigureAwait(false);
        }

        internal static async Task<Response> StopPassages(int stopId, StopPassagesType type, bool bus)
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

            return await HttpHelper.GetString(string.Format(Addresses.PassageInfo, stopId, stype), bus).ConfigureAwait(false);
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
