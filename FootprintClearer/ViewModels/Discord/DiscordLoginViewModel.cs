using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using FootprintClearer.Services;

namespace FootprintClearer.ViewModels.Discord;

public class DiscordLoginViewModel : PageViewModelBase
{
    private readonly ITextFileReader _textFileReader;

    public DiscordLoginViewModel(ITextFileReader textFileReader)
    {
        _textFileReader = textFileReader;
    }

    public async Task HandlePageLoad(NativeWebView webView)
    {
        string bridgeScript = await _textFileReader.GetFileContentsAsync("Scripts", "csBridge.js");
        string monitorScript = await _textFileReader.GetFileContentsAsync("Scripts", "getDiscordToken.js");
        
        await webView.InvokeScript(bridgeScript);
        await webView.InvokeScript(monitorScript);
    }
}