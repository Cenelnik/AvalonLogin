using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Battleship.Users.Avalonia.ViewModels;   
using Battleship.Users.Common.IServices;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Battleship.Users.Avalonia.ViewModels;

public class MainWindowViewModel: ViewModelBase
{
    private static IUserEditorable _userEditor;
    private BasePageViewModel _curetPage;
    private string _stSubmit = "";
    private string _stCancel = "Cancel";
    private int _size = 100;
    private int _height = 100;
    private int _width = 100;
    private bool _visibleSubmit = true;
    public MainWindowViewModel()
    { 
    }
    public MainWindowViewModel(IUserEditorable Editor)
    {
        _userEditor = Editor;

        _pageCollection.Add(new LoginViewModel(Editor));
        _pageCollection.Add(new GameViewModel());
        _pageCollection.Add(new RegitrationViewModel(Editor));

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

    public int HeightWindow
    {
        get { return _height; }
        private set { this.RaiseAndSetIfChanged(ref _height, _size * 4); }
    }

    public int WidthtWindow
    {
        get { return _width; }
        private set { this.RaiseAndSetIfChanged(ref _width, _size * 3); }
    }

    public bool VisibleSubmit
    {
        get { return _visibleSubmit; }
        private set { this.RaiseAndSetIfChanged(ref _visibleSubmit, value); }
    }

    public int Size
    {
        get
        {
            return _size; 
        }

        private set 
        {
            this.RaiseAndSetIfChanged(ref _size, value); 
        }
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
                    stSubmit = CurrentPage.StSubmit;
                    stCancel = CurrentPage.StCancel;
                    Size = 120;
                    WidthtWindow = WidthtWindow;
                    HeightWindow = HeightWindow;
                    break;

                case "Registration":
                    CurrentPage = _pageCollection[0];
                    stSubmit = CurrentPage.StSubmit;
                    stCancel = CurrentPage.StCancel;
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
        try
        {
            if (await CurrentPage.Submit())
            {
                switch (CurrentPage.StSubmit)
                {
                    case "Login":
                        CurrentPage = _pageCollection[1];
                        stSubmit = CurrentPage.StSubmit;
                        stCancel = CurrentPage.StCancel;
                        Size = 200;
                        WidthtWindow = WidthtWindow;
                        HeightWindow = HeightWindow;
                        VisibleSubmit = false;
                        VisibleSubmit = VisibleSubmit;
                        break;

                    case "Registration":
                        CurrentPage = _pageCollection[0];
                        stSubmit = CurrentPage.StSubmit;
                        stCancel = CurrentPage.StCancel;
                        Size = 100;
                        WidthtWindow = WidthtWindow;
                        HeightWindow = HeightWindow;
                        break;

                    case "Play":
                        _visibleSubmit = false;
                        VisibleSubmit = VisibleSubmit;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                await CurrentPage.ErrorEvent();
            }
        }catch (Exception ex) 
        {

        }
        
    }

 }

