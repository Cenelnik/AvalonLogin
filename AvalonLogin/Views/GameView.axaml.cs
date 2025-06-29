using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using ReactiveUI;
using System;
using System.Windows.Input;

namespace Battleship.Users.Avalonia.Views
{
    public partial class GameView : UserControl
    {

        public GameView()
        {
            InitializeComponent();
            Canvas.SetBottom(SnakeBody, 80);
            Canvas.SetLeft(SnakeBody, 0);
        }

        public void PointerEvent(object sender, PointerEventArgs e)
        {
            Canvas.SetBottom(SnakeBody, 100);
            Canvas.SetLeft(SnakeBody, 100);
            ButtonStartGame.Content = $"{ButtonStartGame.Content}:aaaa";
        }
        public void KeyEvent(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W or Key.Up:
                    Canvas.SetBottom(SnakeBody, 30 + Canvas.GetBottom(SnakeBody));
                    break;

                case Key.D or Key.Right:
                    Canvas.SetLeft(SnakeBody, 30 + Canvas.GetLeft(SnakeBody));
                    break;

                case Key.A or Key.Left:
                    Canvas.SetLeft(SnakeBody,  Canvas.GetLeft(SnakeBody) -30);
                    break;

                case Key.S or Key.Down:
                    Canvas.SetBottom(SnakeBody, Canvas.GetBottom(SnakeBody)-30);
                    break;

                default:
                    break;

            }
        }


        
    }
}
