using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Avalonia.Controls;
using FootprintClearer.Services;

namespace FootprintClearer.ViewModels.Discord;

public partial class DiscordLoginViewModel : PageViewModelBase
{
    private readonly ITextFileReader _textFileReader;
    private readonly ITokenStorage _tokenStorage;

    public DiscordLoginViewModel(ITextFileReader textFileReader, ITokenStorage tokenStorage)
    {
        _textFileReader = textFileReader;
        _tokenStorage = tokenStorage;
    }

    [GeneratedRegex(@"^(mfa\.[\w-]{84}|[\w-]{24,26}\.[\w-]{6}\.[\w-]{25,110})$")]
    private static partial Regex TokenPattern();

    public async Task HandlePageLoad(NativeWebView webView)
    {
        string monitorScript = await _textFileReader.GetFileContentsAsync("Scripts", "getDiscordToken.js");

        await webView.InvokeScript(monitorScript);
    }

    public void HandleMessage(string message)
    {
        Console.WriteLine("Received: " + message);

        Regex pattern = TokenPattern();
        if (!pattern.IsMatch(message)) return;

        _tokenStorage.StoreToken("discord", message);
        Console.WriteLine("Validated and stored: " + message);
    }
}