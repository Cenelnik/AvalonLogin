using Battleship.Game.Logic.Base.Services;

namespace Battleship.Game.Logic.Base.DTO
{
    /// <summary>
    /// Базовый объект, который будет двигаться на поле
    /// </summary>
    public abstract class Unit : IMovable
    {
        public Position CurrentPosition { get; set; }
        public virtual Position Move(GameField gameField)
        {
            throw new NotImplementedException();
        }
    }
}
