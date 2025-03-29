using Avalonia;
using Avalonia.Controls;
using Battleship.Users.Avalonia.Views;
using ReactiveUI;
using System.Reactive;

namespace Battleship.Users.Avalonia.ViewModels;

public class GameViewModel : BasePageViewModel
{
    public GameViewModel()
    {
    }
    public override string StSubmit { get => "Play"; }

}
