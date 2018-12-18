using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.Enums;

namespace TTSSLib.Models.API
{
    internal class TripPassage
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
        /// Gets or sets the status - predicted or planned.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty("status")]
        public string StatusString { get; set; }

        /// <summary>
        /// Number in trip stops sequence
        /// </summary>
        [JsonProperty("stop_seq_num")]
        public int SequenceNo { get; set; }

        /// <summary>
        /// Stop
        /// </summary>
        [JsonProperty("stop")]
        public PassageStop Stop { get; set; }
    }
}
