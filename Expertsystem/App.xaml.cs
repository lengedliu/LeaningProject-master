using Expertsystem.Modules.ModuleName;
using Expertsystem.Services;
using Expertsystem.Services.Interfaces;
using Expertsystem.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Expertsystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<LoginSignUpView>();
        }
        //
        protected override void InitializeShell(Window shell)
        {
            //if (Container.Resolve<LoginSignUpView>().ShowDialog() == false)
            //{ 
            //  Application.Current?.Shutdown();
            //}
            //else 
            //{
            //   base.InitializeShell(shell);
            //}
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            containerRegistry.RegisterSingleton<ICognitoClients, CognitoClient>();
            containerRegistry.RegisterSingleton<IHttpRequestService, HttpRequestService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
