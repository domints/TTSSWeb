using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTSSLib.Models.Data
{
    /// <summary>
    /// Object holding single result from autocomplete query
    /// </summary>
    public class StopBase
    {
        protected string _name;
        protected int _id;
        /// <summary>
        /// Gets or sets the stop identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }


        /// <summary>
        /// Gets or sets the stop name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            return $"{ID}:{Name}";
        }
    }
}
