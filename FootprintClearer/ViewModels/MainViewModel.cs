using FootprintClearer.ViewModels.Components;
using FootprintClearer.ViewModels.Start;
using FootprintClearer.Views.Components;

namespace FootprintClearer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public HeaderViewModel Header { get; }
    public SidebarViewModel Sidebar { get; }
    public PageViewModelBase Page { get; set; }

    public MainViewModel(SidebarViewModel sidebar, HeaderViewModel header, StartPageViewModel page)
    {
        Sidebar = sidebar;
        Header = header;
        Page = page;
    }

}