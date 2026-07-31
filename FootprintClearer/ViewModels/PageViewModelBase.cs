using System.Threading.Tasks;

namespace FootprintClearer.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public abstract Task Load();
}