using FootprintClearer.ViewModels.Components;
using ReactiveUI;

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

    public PageViewModelBase? Page
    {
        get;
        set => this.RaiseAndSetIfChanged(ref field, value);
    }
}