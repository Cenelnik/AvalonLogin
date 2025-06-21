using Battleship.Users.Common.Tools.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Model.Tools.Configs
{
    public class Configurator : BaseConfig
    {
        ConfigType _type;
        public Configurator(ConfigType type)
        {
            switch (type)
            {
                case ConfigType.DataBaseConnectionConfig:
                    this.DataBaseConnection = GetDataBaseConnection();
                    break;
                case ConfigType.KeyCloakConnectionConfig:
                    this.KeyCloakConnection = GetKeyCloakConnections();
                    break;
            }
        }

        

        public DBConnection GetDataBaseConnection() => new DBConnection() { ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1HUF!zLRnCKM-kV0;Database=Project" };

        public List<KeyCloakConnection> GetKeyCloakConnections()
        {
            List<KeyCloakConnection> resp = new List<KeyCloakConnection>();
            resp.Add(new KeyCloakConnection() { ClientId = "Test-client", ClientSecret = "6PXOq1HUkxeuBRJOfL2NOYPllalrQ3ys", Name = "Manager", Host = "http://127.0.0.1:8081", Realm = "TestUsers" });
            resp.Add(new KeyCloakConnection() { ClientId = "admin-cli", ClientSecret = "nkfGNEmGk4RBXLyWXGe7gPvGiw7o6qpv", Name = "Admin", Host = "http://127.0.0.1:8081", Realm = "TestUsers" });
            return resp;
        }
    }
}
