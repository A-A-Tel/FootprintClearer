using FootprintClearer.ViewModels.Components;
using FootprintClearer.ViewModels.Start;
using FootprintClearer.Views.Components;

namespace FootprintClearer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public HeaderViewModel Header { get; }
    public SidebarViewModel Sidebar { get; }

    public MainViewModel(SidebarViewModel sidebar, HeaderViewModel header)
    {
        Sidebar = sidebar;
        Header = header;
    }

    public PageViewModelBase Page { get; set; } = new StartPageViewModel();
}