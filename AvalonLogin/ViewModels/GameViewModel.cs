using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Battleship.Users.Avalonia.Views;
using Microsoft.AspNetCore.Http.HttpResults;
using ReactiveUI;
using System;
using System.Reactive;
using System.Windows.Input;

namespace Battleship.Users.Avalonia.ViewModels;

public class GameViewModel : BasePageViewModel
{
    private bool _visibleStartGame = true;
    private bool _visibleVisibleCavas = false;

    public GameViewModel()
    {
        Go = ReactiveCommand.Create(GoComand);
    }
    public override string StSubmit { get => "Play"; }
    public override string StCancel { get => "Exit"; }

    public ICommand Go { get; }

    private async void GoComand()
    {
        if (_visibleStartGame)
        {
            VisibleStartGame = false;
            VisibleCavas = true;
        }
    }

    public bool VisibleStartGame { get => _visibleStartGame; set => this.RaiseAndSetIfChanged(ref _visibleStartGame, value); }
    public bool VisibleCavas { get => _visibleVisibleCavas; set => this.RaiseAndSetIfChanged(ref _visibleVisibleCavas, value); }
}
