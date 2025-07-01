using Battleship.Game.Logic.Base.DTO;
using Battleship.Game.Logic.Base.Services;

namespace Battleship.Game.Logic.ConcreteGameLogic
{
    public class PacManFieldRules : FieldRulesTemplate
    {
        List<Unit> _units = new List<Unit>();
        GameField _gameField;
        
        public PacManFieldRules(List<Unit> units, GameField gameField) : base(units, gameField)
        {
            _units = units;
            _gameField = gameField;
        }

        protected override void MoveUnits()
        {
            Parallel.ForEach<Unit>(_units, n => n.Move(_gameField));
        }
        protected override void RoundResult()
        {
            Parallel.ForEach<Unit>(_units, n => {
                if ((Math.Abs(n.CurrentPosition.X - _userPosition.X) <= 10)
                &&
                (n.CurrentPosition.Y - _userPosition.Y) <= 10) 
                {
                    n.IsVisible = false;
                }  
            });
        }
    }
}
/*
 if (Math.Abs(CurrentPosition.X - userPosition.X) <= 10)
                this.IsVisible = false;*/
