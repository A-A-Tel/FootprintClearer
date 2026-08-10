using System.Threading.Tasks;

namespace FootprintClearer.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public virtual Task Load()
    {
        return Task.CompletedTask;
    }

    public virtual Task Unload()
    {
        return Task.CompletedTask;
    }
}