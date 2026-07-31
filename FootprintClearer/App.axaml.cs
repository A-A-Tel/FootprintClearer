using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FootprintClearer.Services;
using FootprintClearer.ViewModels;
using FootprintClearer.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FootprintClearer;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ServiceCollection collection = new();

        collection.AddSingleton<IPageFactory, PageFactory>();
        
        collection.AddSingleton<MainViewModel>();
        collection.AddSingleton<INavigator, Navigator>();
        
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindowView
                {
                    DataContext = new MainViewModel()
                };
                break;
            case ISingleViewApplicationLifetime singleViewPlatform:
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel()
                };
                break;
            default:
                throw new NotImplementedException("ApplicationLifetime not supported: " + ApplicationLifetime?.GetType());
        }

        base.OnFrameworkInitializationCompleted();
    }
}