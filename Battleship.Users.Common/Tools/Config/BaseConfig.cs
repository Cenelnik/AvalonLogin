using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.Tools.Config
{
    public abstract class BaseConfig
    {
        public virtual void GetConfig() { }

        public DBConnection DataBaseConnection { get; set; }
        public List<KeyCloakConnection> KeyCloakConnection { get; set; }
    }
}
