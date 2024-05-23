using System.ComponentModel;

namespace wpf_example.ViewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private string? username;
        private string? password;

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public RelayCommand SignUpCommand { get; }

        public string? Username
        {
            get => username;
            set
            {
                username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }

        public string? Password
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
            SignUpCommand = new RelayCommand(x => SignUp());
        }

        private void SignUp()
        {
            Password = string.Empty;
        }
    }
}
