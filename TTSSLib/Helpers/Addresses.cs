namespace TTSSLib.Helpers
{
    /// <summary>
    /// Class containing services URIs.
    /// </summary>
    internal class Addresses
    {
        public static readonly string TramHost = "http://www.ttss.krakow.pl/";
        public static readonly string BusHost = "http://91.223.13.70/";
        /// <summary>
        /// The autocomplete service address. Provides list of matching stop names. {0} indicates value, that you have already.
        /// </summary>
        public static readonly string Autocomplete = @"/internetservice/services/lookup/autocomplete/json?query={0}";

        /// <summary>
        /// The autocomplete service address. Provides list of stops nearby specified coords. {0} is latitude, {1} is longtitude.
        /// </summary>
        public static readonly string GpsAutocomplete = @"/internetservice/services/lookup/autocomplete/nearStops/json?lat={0}&lon={1}";

        /// <summary>
        /// The passage information service address. Returns list of trams passing by that stop, ans some useful info. {0} indicates stop ID, {1} indicates if "arrival" or "departure". I suggest using "departure".
        /// </summary>
        public static readonly string PassageInfo = @"/internetservice/services/passageInfo/stopPassages/stop?stop={0}&mode={1}";

        /// <summary>
        /// The route information containing list of stops (unfortunately not in order). {0} is stop ID.
        /// </summary>
        public static readonly string RouteInfo = @"/internetservice/services/routeInfo/routeStops?routeId={0}";

        /// <summary>
        /// List all all routes with possible directions
        /// </summary>
        public static readonly string AllRoutes = @"internetservice/services/routeInfo/route";

        /// <summary>
        /// List of all stops with lat/lon information
        /// </summary>
        public static readonly string AllStops = @"internetservice/geoserviceDispatcher/services/stopinfo/stops?left=-648000000&bottom=-324000000&right=648000000&top=324000000";

        /// <summary>
        /// The passage information for passages by TripId. {0} is Trip ID, {1} indicates if "arrival" or "departure". I suggest using "departure".
        /// </summary>
        public static readonly string TripPassages = @"/internetservice/services/tripInfo/tripPassages?tripId={0}&mode={1}";
    }
}
