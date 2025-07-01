using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Common.DTO.KeyCloak
{
    /// <summary>
    /// ОБъект для регистарции нового опльзователя в KeyCloak
    /// </summary>
    public class RegNewUserKeyCloak
    {
        public string username { get; set; } = "example_user";
        public string email { get; set; } = "example@example.com";
        public string firstName { get; set; } = "John";
        public string lastName { get; set; } = "Doe";
        public bool enabled { get; set; } = true;
        public List<CredentialKeyCLoak> credentials { get; set; } = new List<CredentialKeyCLoak>();
    }
}
