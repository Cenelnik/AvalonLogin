using Battleship.Users.Common.DTO;

namespace Battleship.Users.Common.IServices
{
    /// <summary>
    /// Интерфейс позовляющий рабоать с моудлем пользователей
    /// </summary>
    public interface IUserEditorable
    {
        IUserCheckable Checker { get; }
        IOldUserDeletable DeleteUser { get;}
        INewUserRegisteredable RegisteredUser { get; }
        IHash Hash { get; }
    }
}
