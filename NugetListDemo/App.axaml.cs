using System.Transactions;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NugetListDemo.Views;
using NugetListDemo.ViewModels;
using MessageBox.Avalonia;
using System;

namespace NugetListDemo
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            base.OnFrameworkInitializationCompleted();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
                var vm = new MainWindowViewModel();
                vm.GetWindow += () => desktop.MainWindow;
                desktop.MainWindow.DataContext = vm;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
