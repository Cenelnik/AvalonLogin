using Avalonia;
using Avalonia.Controls;
using AvalonLogin.Views;
using ReactiveUI;
using System.Reactive;
using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using ReactiveUI;

namespace AvalonLogin.ViewModels;

public class LoginViewModel : BasePageViewModel
{
    public IUserEditorable userEditor;

    private ViewModelBase _content;
    public ViewModelBase Context { get => _content; set => this._content = value; }
    public LoginViewModel(IUserEditorable Editor)
    {
        LoginCommand = ReactiveCommand.Create(LoginButton);
        Context = this;
        userEditor = Editor;
    }

    public LoginViewModel()
    {
    }
    public override string StSubmit { get => "Login"; }

    private bool _visible = false;
    public bool Visible { get => _visible; set => this.RaiseAndSetIfChanged(ref _visible, value); }
    private string _loginLable = "Write your login:";
    public string LoginLable { get => _loginLable; set => this.RaiseAndSetIfChanged(ref _loginLable, value); } 
    private string _passwordLable = "Write your password:";
    public string PasswordLable { get => _passwordLable; set => this.RaiseAndSetIfChanged(ref _passwordLable, value); }
    private string _sustemText = "Login or password is wrong!";
    public string SystemText { get => _sustemText; set => this.RaiseAndSetIfChanged(ref _sustemText, value); }

    private string _login;
    public string Login { get => _login; set => this.RaiseAndSetIfChanged(ref _login, value); }
    private string _password;   
    public string Password { get => _login; set => this.RaiseAndSetIfChanged(ref _login, value); }

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
        this.SystemText = result ? "We passed login!": "Login or password is wrong!";
    }
}
