using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.DTO
{
    /// <summary>
    /// DTO пользователя, который уже зашел в игру
    /// </summary>
    public  class UserGame
    {
        public string Name { get; set; }
        public IEnumerable<UserGame> friends { get; set; }
        public string Mail { get; set; }
    }
}
