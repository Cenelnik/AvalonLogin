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
        _userEditor = Editor;

        _pageCollection.Add(new LoginViewModel(Editor));
        _pageCollection.Add(new GameViewModel());
        _pageCollection.Add(new RegitrationViewModel());

        CurrentPage = _pageCollection[0];
        stSubmit = CurrentPage.StSubmit;
        stCancel = CurrentPage.StCancel;

        CancelCommand = ReactiveCommand.Create(Cncl);
        SubmittCommand = ReactiveCommand.Create(Sbm);
    }

    public BasePageViewModel CurrentPage
    {
        get { return _curetPage; }
        protected set { this.RaiseAndSetIfChanged(ref _curetPage, value); }
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

    private List<BasePageViewModel> _pageCollection = new List<BasePageViewModel>();

    private async void Cncl()
    {
        if (await CurrentPage.Return())
        {
            switch (CurrentPage.StSubmit)
            {
                case "Login":
                    CurrentPage = _pageCollection[2];
                    break;

                case "Registration":
                    CurrentPage = _pageCollection[0];
                    break;

                default:
                    break;
            }
        }
        else
        {
            await CurrentPage.ErrorEvent();
        }

    }

    private async void Sbm()
    {
        if (await CurrentPage.Submit())
        {
            switch (CurrentPage.StSubmit)
            {
                case "Login":
                    CurrentPage = _pageCollection[1];
                    break;

                case "Registration":
                    CurrentPage = _pageCollection[0];
                    break;

                default:
                    break;
            }
        }
        else 
        {
            await CurrentPage.ErrorEvent();
        }
    }

 }

