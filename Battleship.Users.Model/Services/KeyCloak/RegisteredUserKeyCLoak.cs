using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using Battleship.Users.Common.Tools.Config;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Battleship.Users.Common.DTO.KeyCloak;

namespace Battleship.Users.Model.Services.KeyCloak
{
    public class RegisteredUserKeyCLoak : INewUserRegisteredable
    {

        List<KeyCloakConnection> _keyCloakConnections;
        public RegisteredUserKeyCLoak(List<KeyCloakConnection> keyCloakConnections) 
        {
            _keyCloakConnections = keyCloakConnections;
        }
        
        public async Task<bool> Exec(UserRegistration newUser)
        {
            KeyCloakConnection clientKeyCLoakSetting = _keyCloakConnections.Where(c => c.Name == "Admin").First();

            var contentListForGetClientToken = new List<KeyValuePair<string, string>>();
            contentListForGetClientToken.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            contentListForGetClientToken.Add(new KeyValuePair<string, string>("client_id", clientKeyCLoakSetting.ClientId));
            contentListForGetClientToken.Add(new KeyValuePair<string, string>("client_secret", clientKeyCLoakSetting.ClientSecret));
            var contentClient = new FormUrlEncodedContent(contentListForGetClientToken);
            var cookies = new CookieContainer();
            using var handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            using HttpClient httpClient = new HttpClient(handler);
            using HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"{clientKeyCLoakSetting.Host}/realms/{clientKeyCLoakSetting.Realm}/protocol/openid-connect/token/", contentClient);
            ResponceToGetTokenKeyCLoak respClientToken = JsonConvert.DeserializeObject<ResponceToGetTokenKeyCLoak>(await httpResponseMessage.Content.ReadAsStringAsync());




            RegNewUserKeyCloak newUserKC = new RegNewUserKeyCloak();
            newUserKC.username = newUser.Email;
            newUserKC.email = newUser.Email;
            newUserKC.firstName = newUser.Login;
            newUserKC.credentials.Add(new CredentialKeyCLoak() { value = newUser.PasswordHash});
            cookies = new CookieContainer();
            using var handlerNewUser = new HttpClientHandler();
            handlerNewUser.CookieContainer = cookies;
            using HttpClient httpClientNewReg = new HttpClient(handlerNewUser);
            httpClientNewReg.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", respClientToken.access_token);
            JsonContent content = JsonContent.Create(newUserKC);
            using HttpResponseMessage httpResponseMessageNewReg = await httpClientNewReg.PostAsync($"{clientKeyCLoakSetting.Host}/admin/realms/{clientKeyCLoakSetting.Realm}/users/", content);  //http://127.0.0.1:8081/admin/realms/TestUsers/users/
            //Conflict
            //Created
            //Unauthorized

            if ($"{httpResponseMessageNewReg.StatusCode}" == "Created")
            {
                return true;
            }else if($"{httpResponseMessage.StatusCode}" == "Conflict")
            {
                return false;
            }else
            { 
                return false; 
            }

        }
    }
}
