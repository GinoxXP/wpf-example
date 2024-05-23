using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace wpf_example.Controls
{
    public partial class BindablePasswordBox : UserControl
    {
        private bool isPasswordChanging;

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox),
                new FrameworkPropertyMetadata(string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    PasswordPropertyChanged,
                    null,
                    false,
                    UpdateSourceTrigger.PropertyChanged));

        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            isPasswordChanging = true;
            Password = passwordBox.Password;
            isPasswordChanging = false;
        }

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindablePasswordBox passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }

        private void UpdatePassword()
        {
            if (isPasswordChanging)
                return;

            passwordBox.Password = Password;
        }
    }
}
