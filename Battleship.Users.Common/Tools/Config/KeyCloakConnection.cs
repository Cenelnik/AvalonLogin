using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.Tools.Config
{
    public class KeyCloakConnection
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = "";
        [JsonProperty("Realm")]
        public string Realm { get; set; } = "";
        [JsonProperty("ClientId")]
        public string ClientId { get; set; } = "";
        [JsonProperty("ClientSecret")]
        public string ClientSecret { get; set; } = "";
        [JsonProperty("Host")]
        public string Host { get; set; } = "";
    }
}
