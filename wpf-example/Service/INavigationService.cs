using wpf_example.Core;

namespace wpf_example.Service
{
    public interface INavigationService
    {
        AViewModelBase CurrentViewModel { get; }

        void Navigate<TViewModel>() where TViewModel : AViewModelBase;
    }
}
