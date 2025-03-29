using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using Battleship.Users.Avalonia.ViewModels;
using Battleship.Users.Avalonia.Views;
using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using Battleship.Users.Model.Services.Postgre;

namespace Battleship.Users.Avalonia;

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
                DataContext = new MainWindowViewModel(userEditor)
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainWindow
            {
                DataContext = new MainWindowViewModel(userEditor)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
