using System.Windows.Controls;
using wpf_example.ViewModel;

namespace wpf_example.View
{
    public partial class SignInView : UserControl
    {
        public SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }
    }
}
