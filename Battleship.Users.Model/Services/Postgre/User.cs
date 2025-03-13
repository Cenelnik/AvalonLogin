using Battleship.Users.Common.IServices;

namespace Battleship.Users.Model.Services.Postgre
{
    /// <summary>
    /// Расшерение для Battleship.Users.Model.Data.Postgre.UserDB
    /// </summary>
    public class User : IUserEditorable
    {
        private Checker _checker;
        private DeleteUser _deleteUser;
        private RegisteredUser _registeredUser;
        private Hash _hash;
        public User(string connect) 
        { 
            _checker = new Checker(connect);
            _deleteUser = new DeleteUser(connect);
            _registeredUser = new RegisteredUser(connect);
            _hash = new Hash();
        }
        
        public IUserCheckable Checker => _checker;
        public IOldUserDeletable DeleteUser => _deleteUser;
        public INewUserRegisteredable RegisteredUser => _registeredUser;
        public IHash Hash => _hash;
    }
}
