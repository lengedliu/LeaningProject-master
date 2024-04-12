using Expertsystem.ViewModels;
using Prism.Ioc;
using Prism.Regions;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Input;
using Expertsystem.Adapter.Information;
using Expertsystem.Core;

namespace Expertsystem.Views
{
    public partial class LoginSignUpView : Window
    {
        private readonly IContainerExtension _containerExtension;
        private readonly IRegionManager _regionManager;
        public LoginSignUpView(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _containerExtension = container;
            _regionManager = regionManager;
            //var viewModel = new LoginSignUpViewModel();
            //viewModel.LoginSuccess += OnLoginSucces;
            //this.DataContext = viewModel;
            Loaded += LoginSignUpView_Loaded;
        }

        private void LoginSignUpView_Loaded(object sender, RoutedEventArgs e)
        {
            var task = new Task(new Action(() =>
            {
                try
                {          
                    InfoAdapterConfig infoAdapter = InfoAdapterConfig.Load("Config\\InformationConfig.xml");
                    ExpertsystemContext.InitInformationAdapter(infoAdapter);
                }
                catch (Exception ex)
                {
                  
                }
            }));
            task.Start();
        }

        private void OnLoginSucces()
        {
            var mainWindow = _containerExtension.Resolve<MainWindow>();
            RegionManager.SetRegionManager(mainWindow,_regionManager);
            mainWindow.Show();
            this.Close();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
