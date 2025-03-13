using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.DTO
{
    /// <summary>
    /// Данные с формы логина
    /// </summary>
    public class UserLogin
    {
        public string PasswordHash { get; set; }
        public string Mail { get; set; }
    }
}
