using FootprintClearer.Services;
using FootprintClearer.ViewModels;
using FootprintClearer.ViewModels.Components;
using FootprintClearer.ViewModels.Start;
using Microsoft.Extensions.DependencyInjection;

namespace FootprintClearer;

public static class ServiceExtensions
{
    extension(ServiceCollection collection)
    {
        public ServiceCollection AddCommon()
        {
            collection
                .AddSingleton<IPageFactory, PageFactory>()
                .AddSingleton<SidebarViewModel>()
                .AddSingleton<MainViewModel>()
                .AddSingleton<INavigator, Navigator>();
            return collection;
        }

        public ServiceCollection AddViews()
        {
            collection
                .AddSingleton<StartPageViewModel>();

            return collection;
        }
    }
}