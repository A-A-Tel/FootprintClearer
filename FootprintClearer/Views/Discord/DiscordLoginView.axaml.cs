using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Platform;
using FootprintClearer.ViewModels.Discord;

namespace FootprintClearer.Views.Discord;

public partial class DiscordLoginView : UserControl
{
    public DiscordLoginView()
    {
        InitializeComponent();
    }

    private DiscordLoginViewModel ViewModel => (DataContext as DiscordLoginViewModel)!;

    private async void WebView_OnNavigationStarted(object? sender, WebViewNavigationStartingEventArgs e)
    {
        await ViewModel.HandlePageLoad(WebView);
    }

    private void WebView_OnWebMessageReceived(object? sender, WebMessageReceivedEventArgs e)
    {
        if (e.Body is null) return;

        Console.WriteLine(e.Body);
        return;
    }

    private void WebView_OnEnvironmentRequested(object? sender, WebViewEnvironmentRequestedEventArgs e)
    {
        e.EnableDevTools = true;

        switch (e)
        {
            case WindowsWebView2EnvironmentRequestedEventArgs args:
                args.IsInPrivateModeEnabled = true;
                break;
            case AppleWKWebViewEnvironmentRequestedEventArgs args:
                args.NonPersistentDataStore = true;
                break;
            case LinuxWpeWebViewEnvironmentRequestedEventArgs wpeArgs:

                string privateDirectory = Path.Combine(
                    Path.GetTempPath(),
                    "footprintclearer",
                    Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(privateDirectory);
                
                wpeArgs.DataDirectory = privateDirectory;
                wpeArgs.CacheDirectory = Path.Combine(privateDirectory, "cache");
                break;
            case GtkWebViewEnvironmentRequestedEventArgs gtkArgs:
                gtkArgs.EphemeralDataManager = true;
                break;
        }
    }
}