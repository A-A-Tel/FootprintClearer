using FootprintClearer.Services;
using FootprintClearer.ViewModels;
using FootprintClearer.ViewModels.Start;
using Microsoft.Extensions.DependencyInjection;

namespace FootprintClearer;

public static class ServiceExtensions
{
    public static ServiceCollection AddCommon(this ServiceCollection collection)
    {
        collection
            .AddSingleton<IPageFactory, PageFactory>()
            .AddSingleton<MainViewModel>()
            .AddSingleton<INavigator, Navigator>();
        return collection;
    }

    public static ServiceCollection AddViews(this ServiceCollection collection)
    {
        collection
            .AddSingleton<StartPageViewModel>();

        return collection;
    }
}