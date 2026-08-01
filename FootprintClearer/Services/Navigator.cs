using System.Threading.Tasks;
using FootprintClearer.ViewModels;

namespace FootprintClearer.Services;

public interface INavigator
{
    public Task NavigateTo<T>() where T : PageViewModelBase;
}

public class Navigator : INavigator
{
    private readonly IPageFactory _pageFactory;
    private readonly MainViewModel _mainViewModel;

    public Navigator(IPageFactory pageFactory, MainViewModel mainViewModel)
    {
        _pageFactory = pageFactory;
        _mainViewModel = mainViewModel;
    }

    public async Task NavigateTo<T>()
        where T : PageViewModelBase
    {
        T page = _pageFactory.Get<T>();
        await page.Load();
        _mainViewModel.Page = page;
    }
}