using Battleship.Game.Logic.Base.Services;

namespace Battleship.Game.Logic.Base.DTO
{
    /// <summary>
    /// Базовый объект, который будет двигаться на поле
    /// </summary>
    public abstract class Unit : IMovable
    {
        /// <summary>
        /// Текущая позиция на этот ход
        /// </summary>
        public Position CurrentPosition { get; set; }

        /// <summary>
        /// Активен ли объект или нет
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Как он двигается
        /// </summary>
        /// <param name="gameField"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Position Move(GameField gameField)
        {
            throw new NotImplementedException();
        }
    }
}
