using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTSSLib.Models.API
{
    /// <summary>
    /// Class containing things about stop, from autocomplete service.
    /// </summary>
    internal class Stop
    {
        /// <summary>
        /// Gets or sets the stop identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public int ID { get; set; }


        /// <summary>
        /// Gets or sets the stop name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
