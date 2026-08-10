using FootprintClearer.Services;
using FootprintClearer.ViewModels.Components;

namespace FootprintClearer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(SidebarViewModel sidebar, HeaderViewModel header, INavigator navigator)
    {
        Sidebar = sidebar;
        Header = header;
        Navigator = navigator;
    }

    public HeaderViewModel Header { get; }
    public SidebarViewModel Sidebar { get; }

    public INavigator Navigator { get; }
}