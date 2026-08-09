using FootprintClearer.Services;
using FootprintClearer.ViewModels.Components;
using ReactiveUI;

namespace FootprintClearer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public HeaderViewModel Header { get; }
    public SidebarViewModel Sidebar { get; }

    public INavigator Navigator { get; }
    
    public MainViewModel(SidebarViewModel sidebar, HeaderViewModel header, INavigator navigator)
    {
        Sidebar = sidebar;
        Header = header;
        Navigator = navigator;
    }
}