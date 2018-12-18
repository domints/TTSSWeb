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
    internal class TripPassages
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
        [JsonProperty("directionText")]
        public string DirectionText { get; set; }

        /// <summary>
        /// Gets or sets the old passages, that were on stop and gone. Few of them.
        /// </summary>
        /// <value>
        /// The old passages.
        /// </value>
        [JsonProperty("old")]
        public List<StopPassage> OldPassages { get; set; }

        /// <summary>
        /// Gets or sets the name of the stop.
        /// </summary>
        /// <value>
        /// The name of the stop.
        /// </value>
        [JsonProperty("routeName")]
        public string routeName { get; set; }
    }
}
