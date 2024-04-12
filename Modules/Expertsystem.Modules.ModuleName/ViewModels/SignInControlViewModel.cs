using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using CommunityToolkit.Mvvm.Messaging;
using Expertsystem.Core;
using Expertsystem.Core.Mvvm;
using Expertsystem.Modules.ModuleName.Models;
using Expertsystem.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows.Media;


namespace Expertsystem.Modules.ModuleName.ViewModels
{
    public class SignInControlViewModel : ViewModelBase
    {

        private readonly IRegionManager _regionManager;
        private readonly IRegion _parentRegion;
        private readonly ICognitoClients _cognitoClients;
        public DelegateCommand ShowSignUpCommand { get; private set; }
        public DelegateCommand SignInCommand { get; private set; }



        private LoginModel _loginModel;
        public LoginModel LoginModel
        {
            get { return _loginModel; }
            set { SetProperty(ref _loginModel, value); RaisePropertyChanged(); }
        }
       
        public SignInControlViewModel(IRegionManager regionManager, ICognitoClients cognitoClients)
        {
            LoginModel = new LoginModel();
            _regionManager = regionManager;
            _cognitoClients = cognitoClients;
            ShowSignUpCommand = new DelegateCommand(ShowSignUp);
            SignInCommand = new DelegateCommand(SignIn);
        }

        //登陆事件
        private async void SignIn()
        {
            //
            if (!LoginModel.IsValidated)
            {
                return;
            }
            try
            {
                var result = await _cognitoClients.SignIn(LoginModel.Email, LoginModel.Password);
                if (!result.Success)
                {
                    LoginModel.LoginSubmitResult = result.Message;
                    LoginModel.BrushColor = Brushes.Red;
                }
                else
                {
                    LoginModel.BrushColor = Brushes.Green;
                    LoginModel.LoginSubmitResult = "Login Successful!";
                    var token = result.Message;
                }
            }
            catch
            {
                LoginModel.BrushColor = Brushes.Red;
                LoginModel.LoginSubmitResult = "An error occurred during sign-in.";
            }
            LoginModel.LoginSubmitResult = "SUcess";

        }

        //
        private void ShowSignUp()
        {
            _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate("SignUpControl");

        }



    }
}
