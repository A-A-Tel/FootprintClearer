using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Platform;

namespace FootprintClearer.Services;

public interface ITextFileReader
{
    string GetFileContents(string assetDir, string fileName);
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

    private string ReadFile(string path)
    {
        string fullPath = Path.Combine("FootprintClearer/Assets/", path);
        Uri uri = new("avares://" + fullPath);
        
        using Stream resource = AssetLoader.Open(new Uri("avares://FootprintClearer/Assets/Scripts/monitor.js"));
        using StreamReader reader = new(resource);
        string content = reader.ReadToEnd();

        _cachedFiles[path] = content;
        return content;
    }
}