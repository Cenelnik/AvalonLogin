using Avalonia;
using Avalonia.Controls;
using AvalonLogin.Views;
using ReactiveUI;
using System.Reactive;

namespace AvalonLogin.ViewModels;

using Battleship.Users.Avalonia.Views;
using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using ReactiveUI;

public class MainViewModel : ViewModelBase
{
    public IUserEditorable userEditor;

    private ViewModelBase _content;
    public ViewModelBase Context { get => _content; set => this._content = value; }
    public MainViewModel(IUserEditorable Editor)
    {
        LoginCommand = ReactiveCommand.Create(LoginButton);
        Context = this;
        userEditor = Editor;
    }
    
    private bool _visible = false;
    public bool Visible { get => _visible; set => this.RaiseAndSetIfChanged(ref _visible, value); }
    private string _loginLable = "Write your login:";
    public string LoginLable { get => _loginLable; set => this.RaiseAndSetIfChanged(ref _loginLable, value); } 
    private string _passwordLable = "Write your password:";
    public string PasswordLable { get => _passwordLable; set => this.RaiseAndSetIfChanged(ref _passwordLable, value); }
    private string _sustemText = "Login or password is wrong!";
    public string SystemText { get => _sustemText; set => this.RaiseAndSetIfChanged(ref _sustemText, value); }

    public string Login { get; set; }
    public string Password { get; set; }

    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public void CancelButton()
    {
        this.Visible = false;
        this.SystemText = "";

    }
    public async void LoginButton()
    {
        UserLogin dataLogin = new UserLogin();
        dataLogin.Mail = this.Login;
        dataLogin.PasswordHash = this.Password; // userEditor.Hash.GetHash(this.Password);
        bool result = userEditor.Checker.CheckPass(dataLogin);
        this.Visible = result;
        this.SystemText = result ? "Login or password is wrong!":"We passed login!";
    }
}
