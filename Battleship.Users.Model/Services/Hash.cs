using Battleship.Users.Common.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Battleship.Users.Model.Services
{
    public class Hash : IHash
    {
        public string GenerateNewHash(string pass)
        {
            throw new NotImplementedException();
        }

        public string GetHash(string pass)
        {
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(pass);
                byte[] hashBytes = sha.ComputeHash(textBytes);
                return  BitConverter.ToString(hashBytes);
            }
        }
    }
}
