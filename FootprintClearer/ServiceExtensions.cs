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
                .AddSingleton<MainViewModel>()
                .AddSingleton<INavigator, Navigator>();
            return collection;
        }

        public ServiceCollection AddComponents()
        {
            collection
                .AddSingleton<SidebarViewModel>()
                .AddSingleton<HeaderViewModel>();
            return collection;
        }

        public ServiceCollection AddViewModels()
        {
            collection
                .AddSingleton<StartPageViewModel>();
            return collection;
        }
    }
}