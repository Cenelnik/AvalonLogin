using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.DTO.KeyCloak
{
    /// <summary>
    /// Ответ от KeyCloak после запросна на новый токен или валидацию старого приходит в формете JSON
    /// </summary>
    public class ResponceToGetTokenKeyCLoak
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; } = "";
        [JsonProperty("expires_in")]
        public string expires_in { get; set; } = "";
        [JsonProperty("refresh_expires_in")]
        public string refresh_expires_in { get; set; } = "";
        [JsonProperty("refresh_token")]
        public string refresh_token { get; set; } = "";
        [JsonProperty("token_type")]
        public string token_type { get; set; } = "";
        [JsonProperty("not-before-policy")]
        public string not_before_policy { get; set; } = "";
        [JsonProperty("session_state")]
        public string session_state { get; set; } = "";
        [JsonProperty("scope")]
        public string scope { get; set; } = "";
    }
}
