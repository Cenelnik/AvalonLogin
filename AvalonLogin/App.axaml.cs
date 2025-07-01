using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Battleship.Users.Avalonia.ViewModels;
using Battleship.Users.Avalonia.Views;
using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using Battleship.Users.Common.Tools.Config;
using Battleship.Users.Model.Services.KeyCloak;
using Battleship.Users.Model.Services.Postgre;
using Battleship.Users.Model.Tools.Configs;
using System;

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
        BaseConfig baseConfig =  Configurator.GetConfig(@".\config.json");
        switch(baseConfig.TypeConf)
        {
            case ConfigType.DataBaseConnection:
                userEditor = new User($"{baseConfig.DataBaseConnection.ConnectionString}");
                break;

            case ConfigType.KeyCloakConnection:
                userEditor = new UserKeyCloak(baseConfig);
                break;

            default:
                throw new Exception("Uncorrect config.");
        }
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
