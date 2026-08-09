using System.Threading.Tasks;

namespace FootprintClearer.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public virtual Task Load() => Task.CompletedTask;
    public virtual Task Unload() => Task.CompletedTask;
}