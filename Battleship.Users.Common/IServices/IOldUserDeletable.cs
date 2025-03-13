using Battleship.Users.Common.DTO;

namespace Battleship.Users.Common.IServices
{
    /// <summary>
    /// Возможность удалить старую записть пользователя
    /// </summary>
    public interface IOldUserDeletable
    {
        public bool Exec(UserGame user);
    }
}
