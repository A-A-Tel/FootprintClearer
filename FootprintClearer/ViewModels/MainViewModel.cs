using FootprintClearer.ViewModels.Components;
using FootprintClearer.ViewModels.Start;
using FootprintClearer.Views.Components;

namespace FootprintClearer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public SidebarViewModel Sidebar { get; }

    public MainViewModel(SidebarViewModel sidebar)
    {
        Sidebar = sidebar;
    }

    public PageViewModelBase Page { get; set; } = new StartPageViewModel();
}