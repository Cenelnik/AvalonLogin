using Battleship.Users.Common.DTO;

namespace Battleship.Users.Common.IServices
{
    /// <summary>
    /// Регистарция нового пользователя
    /// </summary>
    public interface INewUserRegisteredable
    {
        public Task<bool> Exec(UserRegistration newUser);
    }
}
