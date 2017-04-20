using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Mastodon.Model
{
    public class ResultsModel
    {
        /// <summary>
        /// An array of matched <see cref="AccountModel"/>
        /// </summary>
        [JsonProperty("accounts")]
        public AccountModel[] Accounts { get; set; }

        /// <summary>
        /// An array of matchhed <see cref="Statuses"/>
        /// </summary>
        [JsonProperty("statuses")]
        public StatusModel[] Statuses { get; set; }

        /// <summary>
        /// An array of matched hashtags, as strings
        /// </summary>
        [JsonProperty("hashtags")]
        public string[] Hashtags { get; set; }
    }
}
