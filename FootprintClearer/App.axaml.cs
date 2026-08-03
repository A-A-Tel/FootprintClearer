using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FootprintClearer.Services;
using FootprintClearer.ViewModels;
using FootprintClearer.ViewModels.Start;
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

        ServiceProvider provider = collection
            .AddCommon()
            .AddViews()
            .BuildServiceProvider();

        MainViewModel mainViewModel = provider.GetRequiredService<MainViewModel>();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindowView
                {
                    DataContext = mainViewModel
                };
                break;
            case ISingleViewApplicationLifetime singleViewPlatform:
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = mainViewModel
                };
                break;
            default:
                throw new NotImplementedException("ApplicationLifetime not supported: " + ApplicationLifetime?.GetType());
        }

        base.OnFrameworkInitializationCompleted();
    }
}