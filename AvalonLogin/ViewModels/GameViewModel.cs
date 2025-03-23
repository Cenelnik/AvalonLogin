using Avalonia;
using Avalonia.Controls;
using AvalonLogin.Views;
using ReactiveUI;
using System.Reactive;

namespace AvalonLogin.ViewModels;

using AvalonLogin.Views;
using ReactiveUI;

public class GameViewModel : BasePageViewModel
{
    public GameViewModel()
    {
    }
    public override string StSubmit { get => "Play"; }

}
