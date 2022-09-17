using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.API.Base;
using TTSSLib.Models.Enums;

namespace TTSSLib.Models.API
{
    internal class TripPassage : BasePassage
    {
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
