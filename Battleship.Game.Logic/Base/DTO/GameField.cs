using Battleship.Game.Logic.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Game.Logic.Base.DTO
{
    /// <summary>
    /// Двух-мерное игровое поле, оно имеет Размеры, на нем располагаются Юниты и происходит какое то Действие по Правилам. 
    /// </summary>
    public abstract class GameField
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
        public int HeightSize { get; set; }
        public int WidthSize { get; set; }
        public FieldRulesTemplate GameLogic {get; set;}
    }
}
