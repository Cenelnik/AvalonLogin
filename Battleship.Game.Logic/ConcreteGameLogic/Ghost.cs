using Battleship.Game.Logic.Base.DTO;

namespace Battleship.Game.Logic.ConcreteGameLogic
{
    public class Ghost: Unit
    {
        public Ghost() 
        {
            
        }
        string[] _direction = { "Top", "Left", "Right", "Bottom" };
        public string Name { get; set; } = "";
        public override Position Move(GameField gameField)
        {

            Random random = new Random();
            int step = random.Next(0, 2);
            string vector = _direction[random.Next(0, _direction.Length)];
            switch (vector)
            {
                case "Top":
                    if ((step * 30 + CurrentPosition.Y) >= gameField.HeightSize)
                    {
                        CurrentPosition.Y = 80;
                    }
                    else
                    {
                        CurrentPosition.Y = step * 30 + CurrentPosition.Y;
                    }
                    break;

                case "Right":
                    if ((CurrentPosition.X + step * 30) >= gameField.WidthSize)
                    {
                        CurrentPosition.X = 0;
                    }
                    else
                    {
                        CurrentPosition.X = CurrentPosition.X + step * 30;
                    }
                    break;

                case "Left":
                    if ((CurrentPosition.X - step * 30) < 0)
                    {
                        CurrentPosition.X = gameField.WidthSize;
                    }
                    else
                    {
                        CurrentPosition.Y = CurrentPosition.X - step * 30;
                    }
                    break;

                case "Bottom":
                    if ((CurrentPosition.Y - step * 30) < 80)
                    {
                        CurrentPosition.Y = gameField.HeightSize;
                    }
                    else
                    {
                        CurrentPosition.Y = CurrentPosition.Y - step * 30;
                    }
                    break;
            }
            return CurrentPosition;
        }
    
    }
}
