using Battleship.Game.Logic.Base.DTO;
using Battleship.Game.Logic.ConcreteGameLogic;

namespace Battleship.Game.Logic.Base.Services
{
    public class PacManGameField: GameField
    {
        public PacManGameField(List<Unit> uints, int h, int w) 
        {
            HeightSize = h; 
            WidthSize = w;
            Units = uints;
            GameLogic = new PacManFieldRules(Units, this);
        }
    }
}
