using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.Tools.Config
{
    public class KeyCloakConnection
    {
        public string Name { get; set; } = "";  
        public string Realm { get; set; } = "";
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string Host { get; set; } = "";
    }
}
