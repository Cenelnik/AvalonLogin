using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.Tools.Config
{
    public abstract class BaseConfig
    {
        [JsonProperty("TypeConf")]
        public ConfigType TypeConf { get; set; }
        public virtual void GetConfig() { }
        [JsonProperty("DataBaseConnection")]
        public DBConnection DataBaseConnection { get; set; }
        [JsonProperty("KeyCloakConnection")]
        public List<KeyCloakConnection> KeyCloakConnection { get; set; }
    }
}
