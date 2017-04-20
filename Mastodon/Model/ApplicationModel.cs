using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Mastodon.Model
{
    public class ApplicationModel
    {
        /// <summary>
        /// Name of the app
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Homepage URL of the app
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }
    }
}
