using FootprintClearer.ViewModels.Start;

namespace FootprintClearer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public PageViewModelBase Page { get; set; } = new StartPageViewModel();
}