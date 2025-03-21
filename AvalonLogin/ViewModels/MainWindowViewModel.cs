using AvalonLogin.ViewModels;
using Battleship.Users.Common.IServices;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvalonLogin.ViewModels;

public class MainWindowViewModel: ViewModelBase
 {
    private static IUserEditorable _userEditor;
    private BasePageViewModel _curetPage;
    private string _stSubmit = "";
    private string _stCancel = "Cancel";
    public MainWindowViewModel()
    { 
    }
    public MainWindowViewModel(IUserEditorable Editor)
    {
        CurrentPage = _pageCollection[0];
        stSubmit = CurrentPage.StSubmit;
        stCancel = CurrentPage.StCancel;
        _userEditor = Editor;

        CancelCommand = ReactiveCommand.Create(Cncl);

        SubmittCommand = ReactiveCommand.Create(Sbm);
    }

    public BasePageViewModel CurrentPage
    {
        get { return _curetPage; }
        private set { this.RaiseAndSetIfChanged(ref _curetPage, value); }
    }

    public string stSubmit
    {
        get { return _stSubmit; }
        private set { this.RaiseAndSetIfChanged(ref _stSubmit, value); }
    }

    public string stCancel
    {
        get { return _stCancel; }
        private set { this.RaiseAndSetIfChanged(ref _stCancel, value); }
    }

    

    public ICommand CancelCommand { get; }

    public ICommand SubmittCommand { get; }

    private BasePageViewModel[] _pageCollection =
    {
        new LoginViewModel(_userEditor),
        new GameViewModel(),
        new RegitrationViewModel()
    };

    private void Cncl()
    {
        int index = _pageCollection.IndexOf(CurrentPage) - 1;
        stSubmit = _pageCollection[index].StSubmit;
        CurrentPage = _pageCollection[index];
    }

    private void Sbm()
    {
        int index = _pageCollection.IndexOf(CurrentPage) + 1;
        stSubmit = _pageCollection[index].StSubmit;
        CurrentPage = _pageCollection[index];
    }


 }

