using wpf_example.Core;
using wpf_example.Service;

namespace wpf_example.ViewModel
{
    public class MainViewModel : AViewModelBase
    {
        private INavigationService navigationService;

        public INavigationService NavigationService
        {
            get => navigationService;
            private set
            {
                navigationService = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigationService.Navigate<SignUpViewModel>();
        }
    }
}
