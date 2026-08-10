using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using FootprintClearer.Services;
using FootprintClearer.ViewModels.Discord;
using ReactiveUI;

namespace FootprintClearer.ViewModels.Components;

public class SidebarViewModel : ViewModelBase
{
    private readonly Dictionary<string, Func<Task>> _brandNavigation;
    private readonly INavigator _navigator;

    public SidebarViewModel(INavigator navigator)
    {
        _navigator = navigator;

        BrandPageCommand = ReactiveCommand.CreateFromTask<string>(NavigateBrandPage);

        _brandNavigation = new Dictionary<string, Func<Task>>
        {
            ["Discord"] = _navigator.NavigateTo<DiscordLoginViewModel>
        };
    }

    public ICommand BrandPageCommand { get; set; }

    public bool IsVisible
    {
        get;
        private set => this.RaiseAndSetIfChanged(ref field, value);
    }

    public void ToggleVisibility()
    {
        IsVisible = !IsVisible;
    }

    private async Task NavigateBrandPage(string brand)
    {
        Func<Task> navigationFunc = _brandNavigation[brand];
        await navigationFunc.Invoke();
    }
}