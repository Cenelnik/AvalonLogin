using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.DTO
{
    /// <summary>
    /// Данные с формы регистрации
    /// </summary>
    public  class UserRegistration
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
