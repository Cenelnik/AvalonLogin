using Battleship.Game.Logic.Base.DTO;

namespace Battleship.Game.Logic.Base.Services
{
    /// <summary>
    /// Темплейт игровой логики. Действуем по шаблону: 
    /// 1. Движение
    /// 2. Экшен.
    /// 3. Результат.
    /// </summary>
    public abstract class FieldRulesTemplate : LoggicTemplate
    {
        protected Position _userPosition;
        public FieldRulesTemplate (List<Unit> units, GameField gameField)
        { }
        public override sealed void RaundAction(Position userPosition)
        {
            _userPosition = userPosition;
            MoveUnits();
            ActionOnFieled();
            RoundResult();
        }

        protected virtual void MoveUnits()
        {
        }

        protected virtual void RoundResult()
        {
        }
        protected virtual void ActionOnFieled()
        {
        }
    }
}
