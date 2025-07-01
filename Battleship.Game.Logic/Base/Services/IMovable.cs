using Battleship.Game.Logic.Base.DTO;

namespace Battleship.Game.Logic.Base.Services
{
    /// <summary>
    /// Способность объекта к движению по игровому полю
    /// </summary>
    public interface IMovable
    {
        public Position Move(GameField gameField);
    }
}
