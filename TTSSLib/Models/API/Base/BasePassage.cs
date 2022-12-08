using Newtonsoft.Json;

namespace TTSSLib.Models.API.Base
{
    internal class BasePassage
    {
        /// <summary>
        /// Gets or sets the actual departure/arrival time as text (like 12:32).
        /// </summary>
        /// <value>
        /// The actual time.
        /// </value>
        [JsonProperty("actualTime")]
        public string ActualTime { get; set; }
        
        /// <summary>
        /// Gets or sets the actual departure/arrival time as text (like 12:32).
        /// </summary>
        /// <value>
        /// The actual time.
        /// </value>
        [JsonProperty("plannedTime")]
        public string PlannedTime { get; set; }

        /// <summary>
        /// Gets or sets the status - predicted or planned.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty("status")]
        public string StatusString { get; set; }
    }
}
