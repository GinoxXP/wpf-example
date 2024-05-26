using System;
using System.ComponentModel;
using System.Windows;
using wpf_example.Core;
using wpf_example.Service;

namespace wpf_example.ViewModel
{
    public class SignUpViewModel : AViewModelBase
    {
        private INavigationService navigationService;
        private IUserService userService;

        private string username = string.Empty;
        private string password = string.Empty;

        public RelayCommand SignUpCommand { get; }

        public RelayCommand NavigateToSignInCommand { get; }

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

        public SignUpViewModel(INavigationService navigationService, IUserService userService)
        {
            this.navigationService = navigationService;
            this.userService = userService;

            SignUpCommand = new RelayCommand(x => SignUp());
            NavigateToSignInCommand = new RelayCommand(x => NavigateToSignIn());
        }

        private void SignUp()
        {
            try
            {
                userService.SignUp(Username, Password);
                MessageBox.Show("User has successfully registred", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                NavigateToSignIn();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Password = string.Empty;
            }
        }

        private void NavigateToSignIn()
        {
            navigationService.Navigate<SignInViewModel>();
        }
    }
}
