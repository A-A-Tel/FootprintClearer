using System.Windows.Input;
using ReactiveUI;

namespace FootprintClearer.ViewModels.Components;

public class HeaderViewModel : ViewModelBase
{
    public HeaderViewModel(SidebarViewModel sidebar)
    {
        ToggleSidebarCommand = ReactiveCommand.Create(sidebar.ToggleVisibility);
    }

    public ICommand ToggleSidebarCommand { get; }
}