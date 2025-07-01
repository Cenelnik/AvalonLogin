using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Battleship.Users.Avalonia.Views;
using Microsoft.AspNetCore.Http.HttpResults;
using ReactiveUI;
using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Battleship.Users.Avalonia.ViewModels;

public class GameViewModel : BasePageViewModel
{
    private bool _visibleStartGame = true;
    private bool _visibleVisibleCavas = false;
    private static string _lableSt = "";
    private string _lableStBuff = "";
    public GameViewModel()
    {
        Go = ReactiveCommand.Create(GoComand);
    }

    public string LableSt { get => _lableSt; set => this.RaiseAndSetIfChanged(ref _lableSt, value); }


    public async Task CheckerAsync()
    {
        await Task.Run(Checker);              
    }

    public void Checker()
    {
        Thread.Sleep(1000);
        LableSt = "test";
        
    }

    public ICommand Go { get; }
    private async void GoComand()
    {
        if (_visibleStartGame)
        {
            VisibleStartGame = false;
            VisibleCavas = true;
        }
        //await CheckerAsync();
    }
    public bool VisibleStartGame { get => _visibleStartGame; set => this.RaiseAndSetIfChanged(ref _visibleStartGame, value); }
    public bool VisibleCavas { get => _visibleVisibleCavas; set => this.RaiseAndSetIfChanged(ref _visibleVisibleCavas, value); }
    public override string StSubmit { get => "Play"; }
    public override string StCancel { get => "Exit"; }
}
