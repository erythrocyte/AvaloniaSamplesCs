using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BattleCity.Models;

namespace BattleCity;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();

            var field = new GameField();
            var game = new Game(field);
            game.Start();
            desktop.MainWindow.DataContext = field;
        }

        base.OnFrameworkInitializationCompleted();
    }
}