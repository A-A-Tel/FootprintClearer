using FootprintClearer.ViewModels.Components;

namespace FootprintClearer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(SidebarViewModel sidebar, HeaderViewModel header)
    {
        Sidebar = sidebar;
        Header = header;
    }

    public HeaderViewModel Header { get; }
    public SidebarViewModel Sidebar { get; }
    public PageViewModelBase? Page { get; set; }
}