using System;
using System.Windows;
using wpf_example.Core;
using wpf_example.Service;

namespace wpf_example.ViewModel
{
    public class SignInViewModel : AViewModelBase
    {
        private INavigationService navigationService;
        private IUserService userService;

        private string username = string.Empty;
        private string password = string.Empty;

        public RelayCommand SignInCommand { get; }
        public RelayCommand NavigateToSignUpCommand { get; }

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public SignInViewModel(INavigationService navigationService, IUserService userService)
        {
            this.navigationService = navigationService;
            this.userService = userService;

            SignInCommand = new RelayCommand(x => SignIn());
            NavigateToSignUpCommand = new RelayCommand(x => NavigateToSignUp());
        }

        private void SignIn()
        {
            try
            {
                userService.SignIn(Username, Password);
                MessageBox.Show("Successfully login", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                Username = string.Empty;
                Password = string.Empty;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Password = string.Empty;
            }
        }

        private void NavigateToSignUp()
        {
            navigationService.Navigate<SignUpViewModel>();
        }
    }
}
