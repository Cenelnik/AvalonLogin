using Battleship.Users.Common.DTO;

namespace Battleship.Users.Common.IServices
{
    /// <summary>
    /// Регистарция нового пользователя
    /// </summary>
    public interface INewUserRegisteredable
    {
        public bool Exec(UserRegistration newUser);
    }
}
