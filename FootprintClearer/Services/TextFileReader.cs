using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Platform;

namespace FootprintClearer.Services;

public interface ITextFileReader
{
    string GetFileContents(string assetDir, string fileName);
    Task<string> GetFileContentsAsync(string assetDir, string fileName);
}

public class TextFileFileReader : ITextFileReader
{
    private readonly Dictionary<string, string> _cachedFiles = new();
    
    public string GetFileContents(string assetDir, string fileName)
    {
        string path = Path.Combine(assetDir, fileName);
        _cachedFiles.TryGetValue(path, out var fileContent);

        return fileContent ?? ReadFile(path);
    }

    public async Task<string> GetFileContentsAsync(string assetDir, string fileName)
    {
        string path = Path.Combine(assetDir, fileName);
        _cachedFiles.TryGetValue(path, out var fileContent);

        return fileContent ?? await ReadFileAsync(path);
    }

    private string ReadFile(string path)
    {
        string fullPath = Path.Combine("FootprintClearer/Assets/", path);
        Uri uri = new("avares://" + fullPath);
        
        using Stream resource = AssetLoader.Open(uri);
        using StreamReader reader = new(resource);
        string content = reader.ReadToEnd();

        _cachedFiles[path] = content;
        return content;
    }
    
    private async Task<string> ReadFileAsync(string path)
    {
        string fullPath = Path.Combine("FootprintClearer/Assets/", path);
        Uri uri = new("avares://" + fullPath);

        await using Stream resource = AssetLoader.Open(uri);
        using StreamReader reader = new(resource);
        string content = await reader.ReadToEndAsync();

        _cachedFiles[path] = content;
        return content;
    }
}