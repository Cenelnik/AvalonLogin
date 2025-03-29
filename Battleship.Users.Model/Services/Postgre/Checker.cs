using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using Battleship.Users.Model.Data.Postgre;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using System.Security.Principal;
using System.Security.Cryptography;

namespace Battleship.Users.Model.Services.Postgre
{
    public class Checker : IUserCheckable
    {
        private static string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";


        private string _connectToDb = "";
        public Checker(string connect) 
        {
            _connectToDb = connect;
        }
        
        public async Task<bool> CheckPass(UserLogin user)
        {
            try
            {
                using (UserDbContext context = new UserDbContext(_connectToDb))
                {
                    UserDB userDb = await context.Users.Where(u => u.Mail == user.Mail).FirstOrDefaultAsync();
                    if (userDb != null)
                    {
                        return userDb.PasswordHash == user.PasswordHash;
                    }
                    else
                    {
                        //
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<string> GetToken(UserLogin user)
        {
            bool checkResult = await this.CheckPass(user);
            var handlerSecurity = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var identity = new ClaimsIdentity(new GenericIdentity("Identity"), new[] { new Claim( ClaimTypes.Email, $"{user.Mail}") });
            var claims = new List<Claim>();
            var tokenSecurity = handlerSecurity.CreateJwtSecurityToken(subject: identity,
                                                       signingCredentials: signingCredentials,
                                                       audience: "ExampleAudience",
                                                       issuer: "ExampleIssuer",
                                                       expires: DateTime.UtcNow.AddSeconds(300));
            string token = handlerSecurity.WriteToken(tokenSecurity);
            if(checkResult)
            {
                return handlerSecurity.WriteToken(tokenSecurity);
            }else
            {
                return "";
            }
            
        }

        public async Task<bool> ValudateToken(string userToken)
        {
            var handlerSecurity = new JwtSecurityTokenHandler();
            string secHash = "";
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] buff = hmac.ComputeHash(Encoding.UTF8.GetBytes($"{handlerSecurity.ReadJwtToken(userToken).RawHeader}.{handlerSecurity.ReadJwtToken(userToken).RawPayload}"));
                var hash = Base64UrlEncoder.Encode(buff);
                secHash = hash;
            }
            if (secHash == handlerSecurity.ReadJwtToken(userToken).RawSignature && handlerSecurity.ReadJwtToken(userToken).ValidTo > DateTime.UtcNow)
            {
                return true;
            }
            return false;
        }

        public async Task<string> UpdateToken(string token)
        {
            UserLogin userLogin = new UserLogin();
            var handlerSecurity = new JwtSecurityTokenHandler();
            foreach (var item in handlerSecurity.ReadJwtToken(token).Claims)
            {
                if (item.Type == "email") userLogin.Mail = item.Value;
            }
            if (await this.ValudateToken(token))
            { 
                return await this.GetToken(userLogin);
            }else
            {
                return "";
            }
        }
    }
}
