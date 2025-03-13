using Avalonia;
using Avalonia.Controls;
using AvalonLogin.Views;
using ReactiveUI;
using System.Reactive;

namespace AvalonLogin.ViewModels;

using Battleship.Users.Avalonia.Views;
using ReactiveUI;

public class GameViewModel : ViewModelBase
{

    public ViewModelBase Context { get; set; }
    public GameViewModel()
    {
        Context = this;
    }

}
