using System;
using FootprintClearer.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FootprintClearer.Services;

public interface IPageFactory
{
    T Get<T>() where T : PageViewModelBase;
}

public class PageFactory : IPageFactory
{
    private readonly IServiceProvider _services;

    public PageFactory(IServiceProvider services)
    {
        _services = services;
    }

    public T Get<T>() where T : PageViewModelBase
    {
        try
        {
            return _services.GetRequiredService<T>();
        }
        catch (InvalidOperationException e)
        {
            throw new TypeLoadException(
                "No service of type \"" + typeof(T) + "\", has it been added to the collection?", e);
        }
    }
}