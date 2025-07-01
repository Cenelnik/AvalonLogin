using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.Tools.Config
{
    public class DBConnection
    {
        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; } = "";
    }
}
