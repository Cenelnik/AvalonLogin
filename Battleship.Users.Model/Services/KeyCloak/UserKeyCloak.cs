using Battleship.Users.Common.IServices;
using Battleship.Users.Common.Tools.Config;
using Battleship.Users.Model.Services.Postgre;
using Battleship.Users.Model.Tools.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Model.Services.KeyCloak
{
    public class UserKeyCloak: IUserEditorable
    {
        private CheckerKeycloak _checker;
        private DeleteUserKeyCloak _deleteUser;
        private RegisteredUserKeyCLoak _registeredUser;
        private Hash _hash;
        public UserKeyCloak(BaseConfig config)
        {
            _checker = new CheckerKeycloak(config);
            _deleteUser = new DeleteUserKeyCloak();
            _registeredUser = new RegisteredUserKeyCLoak(config.KeyCloakConnection);
            _hash = new Hash();
        }

        public IUserCheckable Checker => _checker;
        public IOldUserDeletable DeleteUser => _deleteUser;
        public INewUserRegisteredable RegisteredUser => _registeredUser;
        public IHash Hash => _hash;
    }
}

