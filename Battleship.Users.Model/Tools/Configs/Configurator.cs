using Battleship.Users.Common.Tools.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Battleship.Users.Model.Tools.Configs
{
    public class Configurator : BaseConfig
    {
        public Configurator()
        {
            Init();
            //switch (type)
            //{
            //    case ConfigType.DataBaseConnection:
            //        this.DataBaseConnection = GetDataBaseConnection();
            //        break;
            //    case ConfigType.KeyCloakConnection:
            //        this.KeyCloakConnection = GetKeyCloakConnections();
            //        break;
            //}
        }

        

        //public DBConnection GetDataBaseConnection() => new DBConnection() { ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1HUF!zLRnCKM-kV0;Database=Project" };
        //
        //public List<KeyCloakConnection> GetKeyCloakConnections()
        //{
        //    List<KeyCloakConnection> resp = new List<KeyCloakConnection>();
        //    resp.Add(new KeyCloakConnection() { ClientId = "Test-client", ClientSecret = "6PXOq1HUkxeuBRJOfL2NOYPllalrQ3ys", Name = "Manager", Host = "http://127.0.0.1:8081", Realm = "TestUsers" });
        //    resp.Add(new KeyCloakConnection() { ClientId = "admin-cli", ClientSecret = "nkfGNEmGk4RBXLyWXGe7gPvGiw7o6qpv", Name = "Admin", Host = "http://127.0.0.1:8081", Realm = "TestUsers" });
        //    return resp;
        //}

        void Init()
        {
            try
            {
                //string fileData = File.ReadAllText(@"C:\Users\AleSol\Documents\hlam\ProfC#Project\AvalonLogin\config.json");
                using (FileStream fstream = File.OpenRead(@"C:\Users\AleSol\Documents\hlam\ProfC#Project\AvalonLogin\config.json"))
                {
                    byte[] buffer = new byte[fstream.Length];
                    fstream.Read(buffer, 0, buffer.Length);
                    string textFromFile = Encoding.Default.GetString(buffer);
                    JObject jo = JObject.Parse(textFromFile);

                    JToken jtType = jo["TypeConf"];

                    switch (jtType.Value<string>())
                    {
                        case "KeyCloakConnection":
                            this.TypeConf = ConfigType.KeyCloakConnection;
                            JToken jtKC = jo["KeyCloakConnection"];
                            this.KeyCloakConnection = jtKC.ToObject<List<KeyCloakConnection>>();
                            break;

                        case "DataBaseConnection":
                            this.TypeConf = ConfigType.DataBaseConnection;
                            JToken jtBD = jo["DataBaseConnection"];
                            this.DataBaseConnection = jtBD.ToObject<DBConnection>();
                            break;
                        default:
                            break;
                    }


                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MSG = {ex.Message}; TRC = {ex.StackTrace}");
                throw ex;
            }
            
        }
    }
}
