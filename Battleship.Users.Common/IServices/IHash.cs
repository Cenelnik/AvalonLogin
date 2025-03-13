using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.IServices
{
    /// <summary>
    /// Чтобы не хранить\передавать в системе пароль в открытом виде мы будем использовать hash
    /// </summary>
    public  interface IHash
    {
        public string GetHash(string pass);

        public string GenerateNewHash(string pass);
    }
}
