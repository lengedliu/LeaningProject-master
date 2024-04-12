using Expertsystem.Core;
using Expertsystem.Core.Mvvm;
using Expertsystem.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System.Security.Cryptography;

namespace Expertsystem.Modules.ModuleName.ViewModels
{
    public class SignUpSuccessControlViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        private readonly IRegionManager _regionManager;
        public SignUpSuccessControlViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            _regionManager = regionManager;
            Message = messageService.GetMessage();
            BackToSignInClearHistoryCommand = new DelegateCommand(BackToSignInClearHistory);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
        public DelegateCommand BackToSignInClearHistoryCommand { get; set; }
        private void BackToSignInClearHistory()
        {
            _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate("SignInControl");
        }
    }
}
