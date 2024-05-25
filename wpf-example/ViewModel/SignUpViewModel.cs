using System;
using System.ComponentModel;
using System.Windows;
using wpf_example.Service;

namespace wpf_example.ViewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private string username = string.Empty;
        private string password = string.Empty;

        private UserService userService;

        public event PropertyChangedEventHandler? PropertyChanged;

        
        public RelayCommand SignUpCommand { get; }

        public string Username
        {
            get => username;
            set
            {
                username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public SignUpViewModel()
        {
            userService = new UserService();
            SignUpCommand = new RelayCommand(x => SignUp());
        }

        private void SignUp()
        {
            try
            {
                userService.Create(Username, Password);
                MessageBox.Show("User has successfully registred", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Password = string.Empty;
            }
        }
    }
}
