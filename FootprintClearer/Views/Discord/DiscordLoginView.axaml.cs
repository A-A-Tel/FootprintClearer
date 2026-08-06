using System;
using Avalonia.Controls;
using FootprintClearer.ViewModels.Discord;

namespace FootprintClearer.Views.Discord;

public partial class DiscordLoginView : UserControl
{
    private DiscordLoginViewModel ViewModel => (DataContext as DiscordLoginViewModel)!;

    public DiscordLoginView()
    {
        InitializeComponent();
    }

    private void NativeWebView_OnNavigationStarted(object? sender, WebViewNavigationStartingEventArgs webViewNavigationStartingEventArgs)
    {
        _ = ViewModel.HandlePageLoad(WebView);
    }

    private void WebView_OnWebMessageReceived(object? sender, WebMessageReceivedEventArgs e)
    {
        Console.WriteLine($"{DateTime.Now} - INCOMING MESSAGE: {e.Body}");
    }
}