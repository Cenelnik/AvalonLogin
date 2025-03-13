using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using AvalonLogin.ViewModels;
using AvalonLogin.Views;
using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using Battleship.Users.Model.Services.Postgre;

namespace AvalonLogin;

public partial class App : Application
{
    IUserEditorable userEditor;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        userEditor = new User("Server=localhost;Port=5432;User Id=postgres;Password=1HUF!zLRnCKM-kV0;Database=Project");
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(userEditor)
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel(userEditor)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
