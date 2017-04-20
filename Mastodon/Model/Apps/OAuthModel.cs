using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Mastodon.Model.Apps
{
    public class OAuthModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }
    }
}
