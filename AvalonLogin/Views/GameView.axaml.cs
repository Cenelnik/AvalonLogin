using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Battleship.Game.Logic.Base.DTO;
using Battleship.Game.Logic.Base.Services;
using Battleship.Game.Logic.ConcreteGameLogic;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
//using Battleship.Game.Logic.Base.DTO;
//using Battleship.Game.Logic.ConcreteGameLogic;

namespace Battleship.Users.Avalonia.Views
{
    public partial class GameView : UserControl
    {
        Random _random = new Random();
        BattleField battleField;
        PacManGameField _gameField;
        public GameView()
        {
            InitializeComponent();
            Canvas.SetBottom(SnakeBody, 90);
            Canvas.SetLeft(SnakeBody, 0);
            Canvas.SetBottom(Ghost1, 380);
            Canvas.SetLeft(Ghost1, 300);
            Canvas.SetBottom(Ghost2, 410);
            Canvas.SetLeft(Ghost2, 240);
            Canvas.SetBottom(Ghost3, 350);
            Canvas.SetLeft(Ghost3, 360);
            WinLable.IsVisible = false;
            Canvas.SetLeft(WinLable, 200);
            battleField = new BattleField(540, 770);
            battleField.Ghosts.Add(new GhostObject("Ghost1", new Position(300, 380)));
            battleField.Ghosts.Add(new GhostObject("Ghost2", new Position(240, 410)));
            battleField.Ghosts.Add(new GhostObject("Ghost3", new Position(360, 350)));

            List<Unit> gosts = new List<Unit>();
            
            gosts.Add(new Ghost() { CurrentPosition = new Game.Logic.Base.DTO.Position(300, 380), Name = "Ghost1" });
            gosts.Add(new Ghost() { CurrentPosition = new Game.Logic.Base.DTO.Position(240, 410), Name = "Ghost2" });
            gosts.Add(new Ghost() { CurrentPosition = new Game.Logic.Base.DTO.Position(360, 350), Name = "Ghost3" });
            PacManGameField gameField = new PacManGameField(gosts, 770, 540);
            _gameField = gameField;
        }

        public void PointerEvent(object sender, PointerEventArgs e)
        {
            Canvas.SetBottom(SnakeBody, 100);
            Canvas.SetLeft(SnakeBody, 100);
            ButtonStartGame.Content = $"{ButtonStartGame.Content}:aaaa";
        }
        public async void KeyEvent(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W or Key.Up:
                    if(30 + Canvas.GetBottom(SnakeBody) >= battleField.HeightSize)
                    {
                        Canvas.SetBottom(SnakeBody, 90);//80
                    }else
                    {
                        Canvas.SetBottom(SnakeBody, 30 + Canvas.GetBottom(SnakeBody));
                    }
                    break;

                case Key.D or Key.Right:
                    if(30 + Canvas.GetLeft(SnakeBody) >= battleField.WidthSize)
                    {
                        Canvas.SetLeft(SnakeBody, 0);
                    }else
                    {
                        Canvas.SetLeft(SnakeBody, 30 + Canvas.GetLeft(SnakeBody));
                    }
                    break;

                case Key.A or Key.Left:
                    if(Canvas.GetLeft(SnakeBody) - 30 < 0)
                    {
                        Canvas.SetLeft(SnakeBody, battleField.WidthSize);
                    }else
                    {
                        Canvas.SetLeft(SnakeBody, Canvas.GetLeft(SnakeBody) - 30);
                    }
                    break;

                case Key.S or Key.Down:
                    if(Canvas.GetBottom(SnakeBody) - 30 < 80)
                    {
                        Canvas.SetBottom(SnakeBody, battleField.HeightSize);
                    }else
                    {
                        Canvas.SetBottom(SnakeBody, Canvas.GetBottom(SnakeBody) - 30);
                    }
                    break;

                default:
                    break;

            }

            battleField.NewRaund();
            _gameField.GameLogic.RaundAction(new Game.Logic.Base.DTO.Position((int)Canvas.GetLeft(SnakeBody), (int)Canvas.GetBottom(SnakeBody)));

            //Lable.Text = $"PacMan={Canvas.GetBottom(SnakeBody)}:{Canvas.GetLeft(SnakeBody)}; Ghost={Canvas.GetBottom(Ghost1)}:{Canvas.GetLeft(Ghost1)} Ghost2={Canvas.GetBottom(Ghost2)}:{Canvas.GetLeft(Ghost2)} Ghost3={Canvas.GetBottom(Ghost3)}:{Canvas.GetLeft(Ghost3)}";
            Ghost test = (Ghost)_gameField.Units[0];
            Lable.Text = $"PacMan={Canvas.GetBottom(SnakeBody)}:{Canvas.GetLeft(SnakeBody)}; {test.Name} {_gameField.Units[0].CurrentPosition.X}:{_gameField.Units[0].CurrentPosition.Y}; {_gameField.Units[1].CurrentPosition.X}:{_gameField.Units[1].CurrentPosition.Y}; {_gameField.Units[2].CurrentPosition.X}:{_gameField.Units[2].CurrentPosition.Y}";
            
            foreach (GhostObject ghost in battleField.Ghosts.Where(n => n.IsVisible == true))
            {
                switch (ghost.Name)
                {
                    case "Ghost1":
                        Canvas.SetBottom(Ghost1, ghost.CurrentPosition.Y);
                        Canvas.SetLeft(Ghost1, ghost.CurrentPosition.X);
                        break;

                    case "Ghost2":
                        Canvas.SetBottom(Ghost2, ghost.CurrentPosition.Y);
                        Canvas.SetLeft(Ghost2, ghost.CurrentPosition.X);
                        break;

                    case "Ghost3":
                        Canvas.SetBottom(Ghost3, ghost.CurrentPosition.Y);
                        Canvas.SetLeft(Ghost3, ghost.CurrentPosition.X);
                        break;
                }

            }
            battleField.ResultRaund(new Position((int)Canvas.GetLeft(SnakeBody), (int)Canvas.GetBottom(SnakeBody)));
            foreach(GhostObject ghost in battleField.Ghosts)
            {
                switch (ghost.Name)
                {
                    case "Ghost1":
                        Ghost1.IsVisible = ghost.IsVisible;
                        break;

                    case "Ghost2":
                        Ghost2.IsVisible = ghost.IsVisible;
                        break;

                    case "Ghost3":
                        Ghost3.IsVisible = ghost.IsVisible;
                        break;
                }
            }
            if(battleField.Ghosts.Where(n => n.IsVisible == true).ToList().Count == 0)
            {
                WinLable.IsVisible = true;
                Canvas.SetBottom(WinLable, 650);
            }

        }

        class BattleField
        {
            public int HeightSize { get; set; }
            public int WidthSize { get; set; }
            public List<GhostObject> Ghosts { get; set; }  = new List<GhostObject>();
            public BattleField(int width, int height)
            {
                HeightSize = height;
                WidthSize = width;
            }

            public void NewRaund()
            {
                Parallel.ForEach<GhostObject>(Ghosts, n => n.Move(WidthSize, HeightSize));
            }
            public void ResultRaund(Position curentPositionUser)
            {
                Parallel.ForEach<GhostObject>(Ghosts, n => n.ResultMoving(curentPositionUser));
            }

        }

        class GhostObject
        {
            string[] _direction = {"Top", "Left", "Right", "Bottom" };
            public GhostObject(string name, Position position)
            {
                Name = name;
                CurrentPosition = position;
            }
            public string Name { get; set; }
            public Position CurrentPosition { get; set; } = new Position(0,0);
            public bool IsVisible { get; set; } = true;
            public Position Move(int width, int height)
            {
                Random random = new Random();
                int step = random.Next(0,2);
                string vector = _direction[random.Next(0, _direction.Length)];
                switch (vector)
                {
                    case "Top":
                        if((step*30 + CurrentPosition.Y) >= height)
                        {
                            CurrentPosition.Y = 80;
                        }else
                        {
                            CurrentPosition.Y = step * 30 + CurrentPosition.Y;
                        }
                        break;

                    case "Right":
                        if ((CurrentPosition.X + step * 30) >= width)
                        {
                            CurrentPosition.X = 0;
                        }else
                        {
                            CurrentPosition.X = CurrentPosition.X + step * 30;
                        }
                        break;

                    case "Left":
                        if ((CurrentPosition.X - step * 30) < 0)
                        {
                            CurrentPosition.X = width;
                        }else
                        {
                            CurrentPosition.Y = CurrentPosition.X - step * 30;
                        }
                        break;

                    case "Bottom":
                        if ((CurrentPosition.Y - step * 30) < 80)
                        {
                            CurrentPosition.Y = height;
                        }else
                        {
                            CurrentPosition.Y = CurrentPosition.Y - step * 30;
                        }
                        break;
                }
                return CurrentPosition;
            }

            public void ResultMoving(Position userPosition)
            {
                if((Math.Abs(CurrentPosition.X - userPosition.X) <= 10)&& (Math.Abs(CurrentPosition.Y - userPosition.Y) <= 10))
                    this.IsVisible = false;
            }
        }
        class Position
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
}
