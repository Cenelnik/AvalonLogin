using Battleship.Users.Common.Tools.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Battleship.Users.Model.Tools.Configs
{
    public class Configurator : BaseConfig
    {
        public Configurator(string pathToConf)
        {
            Init(pathToConf);

        }

        void Init(string pathToConf)
        {
            try
            {
                //string fileData = File.ReadAllText(@"C:\Users\AleSol\Documents\hlam\ProfC#Project\AvalonLogin\config.json");
                using (FileStream fstream = File.OpenRead(pathToConf))
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
