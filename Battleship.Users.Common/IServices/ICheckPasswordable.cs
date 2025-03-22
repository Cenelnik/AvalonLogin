using Battleship.Users.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.IServices
{
    /// <summary>
    /// Возможность проверки корректности пароля
    /// </summary>
    public interface IUserCheckable
    {
        /// <summary>
        /// Проверка логина пароля на валидность
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> CheckPass(UserLogin user);
        /// <summary>
        /// Получения токена
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GetToken (UserLogin user);
    }
}
