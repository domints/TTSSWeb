using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.Internal;

namespace TTSSLib.Models.API
{
    /// <summary>
    /// Contains whole data returned by passage service.
    /// </summary>
    internal class StopInfo
    {
        /// <summary>
        /// Gets or sets the list of actual passages.
        /// </summary>
        /// <value>
        /// The actual passages.
        /// </value>
        [JsonProperty("actual")]
        public List<StopPassage> ActualPassages { get; set; }

        /// <summary>
        /// Gets or sets the directions. Kind of shit no one knows what it is.
        /// </summary>
        /// <value>
        /// The directions.
        /// </value>
        [JsonProperty("directions")]
        public List<object> Directions { get; set; }

        /// <summary>
        /// Gets or sets the first passage time. Kind of weird timestamp, multiplied by 1000. Don't think it's needed.
        /// </summary>
        /// <value>
        /// The first passage time.
        /// </value>
        [JsonProperty("firstPassageTime")]
        public long FirstPassageTime { get; set; }

        /// <summary>
        /// Gets or sets the general alerts. Another weird list, no one knows of what. Possibly strings.
        /// </summary>
        /// <value>
        /// The general alerts.
        /// </value>
        [JsonProperty("generalAlerts")]
        public List<object> GeneralAlerts { get; set; }

        /// <summary>
        /// Gets or sets the last passage time. Another weird timestamp, like before.
        /// </summary>
        /// <value>
        /// The last passage time.
        /// </value>
        [JsonProperty("lastPassageTime")]
        public long LastPassageTime { get; set; }

        /// <summary>
        /// Gets or sets the old passages, that were on stop and gone. Few of them.
        /// </summary>
        /// <value>
        /// The old passages.
        /// </value>
        [JsonProperty("old")]
        public List<StopPassage> OldPassages { get; set; }

        /// <summary>
        /// Gets or sets the routes. List of routes going by that stop.
        /// </summary>
        /// <value>
        /// The routes.
        /// </value>
        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }

        /// <summary>
        /// Gets or sets the name of the stop.
        /// </summary>
        /// <value>
        /// The name of the stop.
        /// </value>
        [JsonProperty("stopName")]
        public string StopName { get; set; }

        /// <summary>
        /// Gets or sets the short name of the stop.
        /// </summary>
        /// <value>
        /// The short name of the stop.
        /// </value>
        [JsonProperty("stopShortName")]
        public string StopShortName { get; set; }
    }
}
