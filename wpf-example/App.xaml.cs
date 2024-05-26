using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using wpf_example.Core;
using wpf_example.Service;
using wpf_example.ViewModel;

namespace wpf_example
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var container = new ServiceCollection();

            container.AddSingleton(x => new MainWindow
            {
                DataContext = x.GetRequiredService<MainViewModel>()
            });

            container.AddSingleton<MainViewModel>();
            container.AddSingleton<SignUpViewModel>();
            container.AddSingleton<SignInViewModel>();

            container.AddSingleton<INavigationService, NavigationService>();
            container.AddSingleton<IUserService, UserService>();

            container.AddSingleton<Func<Type, AViewModelBase>>(container => viewModelType => (AViewModelBase)container.GetRequiredService(viewModelType));

            serviceProvider = container.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
