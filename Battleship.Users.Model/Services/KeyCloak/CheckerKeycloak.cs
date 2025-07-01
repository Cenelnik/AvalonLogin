using Battleship.Users.Common.DTO;
using Battleship.Users.Common.DTO.KeyCloak;
using Battleship.Users.Common.IServices;
using Battleship.Users.Common.Tools.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Battleship.Users.Model.Services.KeyCloak
{
    public class CheckerKeycloak : IUserCheckable
    {
        static HttpClient httpClient;
        static HttpResponseMessage httpResponseMessage;
        BaseConfig _config;
        public CheckerKeycloak(BaseConfig config) 
        { 
            _config = config;
        }
        public async Task<bool> CheckPass(UserLogin user)
        {
            string token = await GetToken(user);
            return await ValudateToken(token);
        }

        public async Task<string> GetToken(UserLogin user)
        {
            var contentListForGetUserToken = new List<KeyValuePair<string, string>>();
            contentListForGetUserToken.Add(new KeyValuePair<string, string>("grant_type", "password"));
            contentListForGetUserToken.Add(new KeyValuePair<string, string>("client_id", $"{_config.KeyCloakConnection.Where(c => c.Name == "Manager").First().ClientId}"));
            contentListForGetUserToken.Add(new KeyValuePair<string, string>("username", $"{user.Mail}"));
            contentListForGetUserToken.Add(new KeyValuePair<string, string>("password", $"{user.PasswordHash}"));
            contentListForGetUserToken.Add(new KeyValuePair<string, string>("client_secret", $"{_config.KeyCloakConnection.Where(c => c.Name == "Manager").First().ClientSecret}"));

            var content = new FormUrlEncodedContent(contentListForGetUserToken);
            var cookies = new CookieContainer();
            using var handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            string uri = $"{_config.KeyCloakConnection.Where(c => c.Name == "Manager").First().Host}/realms/{_config.KeyCloakConnection.Where(c => c.Name == "Manager").First().Realm}/protocol/openid-connect/token/";
            httpClient = new HttpClient(handler);
            httpResponseMessage = await httpClient.PostAsync(uri, content);
            ResponceToGetTokenKeyCLoak resp = JsonConvert.DeserializeObject<ResponceToGetTokenKeyCLoak>(await httpResponseMessage.Content.ReadAsStringAsync());
            return resp.access_token;
        }

        public Task<string> UpdateToken(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValudateToken(string token)
        {
            Uri uri = new Uri ($"{_config.KeyCloakConnection.Where(c => c.Name == "Manager").First().Host}/realms/{_config.KeyCloakConnection.Where(c => c.Name == "Manager").First().Realm}/protocol/openid-connect/token/introspect/");

            var contentList = new List<KeyValuePair<string, string>>();
            contentList.Add(new KeyValuePair<string, string>("client_secret", $"{_config.KeyCloakConnection.Where(c => c.Name == "Manager").First().ClientSecret}"));
            contentList.Add(new KeyValuePair<string, string>("client_id", $"{_config.KeyCloakConnection.Where(c => c.Name == "Manager").First().ClientId}"));
            contentList.Add(new KeyValuePair<string, string>("token", $"{token}"));
            var content = new FormUrlEncodedContent(contentList);
            var cookies = new CookieContainer();
            using var handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            httpClient = new HttpClient(handler);
            httpResponseMessage = await httpClient.PostAsync(uri, content);
            string resp = await httpResponseMessage.Content.ReadAsStringAsync();
            if(resp.Contains("\"active\":true"))
            {
                return true;
            }else if(resp.Contains("\"active\":false"))
            {
                return false;
            }else
            {
                return false;
            }
        }
    }
}
