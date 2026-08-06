using FootprintClearer.Services;
using FootprintClearer.ViewModels;
using FootprintClearer.ViewModels.Components;
using FootprintClearer.ViewModels.Discord;
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
                .AddSingleton<ITextFileReader, TextFileFileReader>()
                .AddSingleton<IPageFactory, PageFactory>()
                .AddSingleton<INavigator, Navigator>();
            return collection;
        }

        public ServiceCollection AddComponents()
        {
            collection
                .AddSingleton<MainViewModel>()
                .AddSingleton<SidebarViewModel>()
                .AddSingleton<HeaderViewModel>();
            return collection;
        }

        public ServiceCollection AddPages()
        {
            collection
                .AddSingleton<StartPageViewModel>()
                .AddSingleton<DiscordLoginViewModel>();
            return collection;
        }
    }
}