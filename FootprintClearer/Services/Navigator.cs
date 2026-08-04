using System.Threading.Tasks;
using FootprintClearer.ViewModels;
using FootprintClearer.ViewModels.Start;
using ReactiveUI;

namespace FootprintClearer.Services;

public interface INavigator
{
    PageViewModelBase CurrentPage { get; }
    public Task NavigateTo<T>() where T : PageViewModelBase;
}

public class Navigator : ReactiveObject, INavigator
{
    private readonly IPageFactory _pageFactory;
    
    public PageViewModelBase CurrentPage
    {
        get => field;
        private set => this.RaiseAndSetIfChanged(ref field, value);
    }

    public Navigator(IPageFactory pageFactory, StartPageViewModel startPage)
    {
        _pageFactory = pageFactory;
        CurrentPage = startPage;
    }

    public async Task NavigateTo<T>()
        where T : PageViewModelBase
    {
        T page = _pageFactory.Get<T>();
        await page.Load();
        CurrentPage = page;
    }
}