using System.Collections.Generic;

namespace FootprintClearer.Services;

public interface ITokenStorage
{
    void StoreToken(string key, string token);
    string? GetToken(string key);
}

public class TokenStorage : ITokenStorage
{
    private readonly Dictionary<string, string> _tokens = new();
    
    public void StoreToken(string key, string token)
    {
        _tokens[key.ToLowerInvariant()] = token;
    }

    public string? GetToken(string key)
    {
        _tokens.TryGetValue(key.ToLowerInvariant(), out string? value);
        return value;
    }
    
    // possible token saving in the future
}