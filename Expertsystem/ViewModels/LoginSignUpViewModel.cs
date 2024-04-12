//using Amazon;
//using Amazon.CognitoIdentityProvider;
//using Amazon.Runtime;
using Expertsystem.Core;
using Expertsystem.Core.Events;
using Expertsystem.Core.Mvvm;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Configuration;

namespace Expertsystem.ViewModels
{
    public partial class LoginSignUpViewModel : ViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public event Action  LoginSuccess;
        public DelegateCommand LoginCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }

        private IEventAggregator _eventAggregator;
        public LoginSignUpViewModel(IRegionManager regionManager,IEventAggregator eventAggregator)        
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            LoginCommand = new DelegateCommand(OnLogin);
            GoBackCommand = new DelegateCommand(GoBackView);
            _eventAggregator.GetEvent<MessageEvent>().Subscribe(EventHandle);
        }
        /// <summary>
        /// 登陆命令执行的方法
        /// </summary>
        private void OnLogin()
        {
            //登陆成功后触发事件
            OnLoginSuccess();
        }

        private void OnLoginSuccess()
        { 
           LoginSuccess?.Invoke();
        }
        private void EventHandle(string msg)
        { 
        
        }
        private void GoBackView()
        {
            _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate("SignInControl");
        }
    }
}
