using Avalonia;
using Avalonia.Controls;
using Battleship.Users.Avalonia.ViewModels;
using Battleship.Users.Avalonia.Views;
using ReactiveUI;
using System.Reactive;

namespace Battleship.Users.Avalonia.ViewModels;

using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using ReactiveUI;
using System;
using System.Threading.Tasks;

public class RegitrationViewModel : BasePageViewModel
{
    private IUserEditorable _userEditor;
    public RegitrationViewModel()
    {
    }
    public RegitrationViewModel(IUserEditorable Editor)
    {
        _userEditor = Editor;
    }

    public override string StSubmit { get => "Registration"; }

    private string _login;
    public string Login { get => _login; set => this.RaiseAndSetIfChanged(ref _login, value); }
    private string _password2;
    public string Password2 { get => _password2; set => this.RaiseAndSetIfChanged(ref _password2, value); }
    private string _password1;
    public string Password1 { get => _password1; set => this.RaiseAndSetIfChanged(ref _password1, value); }
    private string _email;
    public string Email { get => _email; set => this.RaiseAndSetIfChanged(ref _email, value); }

    private bool _visible = false;
    public bool Visible { get => _visible; set => this.RaiseAndSetIfChanged(ref _visible, value); }

    private string _systemText;
    public string SystemText { get => _systemText; set => this.RaiseAndSetIfChanged(ref _systemText, value); }

    public override async Task<bool> Submit()
    {
        UserRegistration dataReg = new UserRegistration();
        dataReg.Login = Login;
        dataReg.Email = Email;
        if (Password2 == Password1)
        {
            dataReg.PasswordHash = _userEditor.Hash.GetHash(this.Password1);
        }else
        {
            SystemText = "Passwords don't match. Please check its.";
            return false;
        }
        try
        {
            bool resp = await _userEditor.RegisteredUser.Exec(dataReg);
            if (resp)
            {
                return true;
            }else
            {
                this.SystemText = "This email is using already.";
                return false;
            }

        } catch (Exception ex)
        {
            this.SystemText = $"{ex.Message}";
            return false;
        }
        
    }

    public override async Task ErrorEvent()
    {
        this.Visible = true;
        return;
    }
}
