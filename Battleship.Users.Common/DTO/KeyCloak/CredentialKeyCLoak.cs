using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.DTO.KeyCloak
{
    /// <summary>
    /// Объект настройки доступов для пользователя в KeyCloak.
    /// </summary>
    public class CredentialKeyCLoak
    {
        public string type { get; set; } = "password";
        public string value { get; set; } = "password";
        public bool temporary { get; set; } = false;
    }
}
