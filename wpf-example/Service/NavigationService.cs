using System;
using wpf_example.Core;

namespace wpf_example.Service
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, AViewModelBase> viewModelFactory;

        private AViewModelBase currentViewModel;

        public AViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            private set
            {
                currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, AViewModelBase> viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }

        public void Navigate<TViewModel>() where TViewModel : AViewModelBase
        {
            var viewModel = viewModelFactory.Invoke(typeof(TViewModel));
            CurrentViewModel = viewModel;
        }
    }
}
