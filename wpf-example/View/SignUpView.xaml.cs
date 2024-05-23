using System.Windows.Controls;
using wpf_example.ViewModel;

namespace wpf_example.View
{
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
