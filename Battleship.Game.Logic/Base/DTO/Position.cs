using System;
using System.Collections.Generic;
namespace Battleship.Game.Logic.Base.DTO
{
    /// <summary>
    /// Определет позицию персонажа на поле
    /// </summary>
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
    }
}
