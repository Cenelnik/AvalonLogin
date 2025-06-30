using Battleship.Game.Logic.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public FieldRulesTemplate (List<Unit> units)
        { }
        public override sealed void RaundAction()
        {
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
