using ReactiveUI;

namespace FootprintClearer.ViewModels.Components;

public class SidebarViewModel : ViewModelBase
{
    public bool IsVisible
    {
        get;
        private set => this.RaiseAndSetIfChanged(ref field, value);
    }

    public void ToggleVisibility()
    {
        IsVisible = !IsVisible;
    }
}