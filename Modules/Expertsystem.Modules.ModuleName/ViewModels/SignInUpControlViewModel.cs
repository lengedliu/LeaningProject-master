using CommunityToolkit.Mvvm.Messaging;
using Expertsystem.Core;
using Expertsystem.Core.Mvvm;
using Expertsystem.Modules.ModuleName.Models;
using Expertsystem.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Media;


namespace Expertsystem.Modules.ModuleName.ViewModels
{
    public class SignUpControlViewModel : ViewModelBase
    {
        private string _SignUpEmail = "";
        public DelegateCommand SignUpCommand { get; private set; }
        public DelegateCommand ShowSignInCommand { get; private set; }
        private readonly IRegionManager _regionManager;
        private readonly IRegion _parentRegion;
        private readonly ICognitoClients _cognitoService;

        private SignUp _signUpModel;
        public SignUp SignUpModel
        {
            get { return _signUpModel; }
            set { SetProperty(ref _signUpModel, value); RaisePropertyChanged(); }
        }

        public SignUpControlViewModel(IRegionManager regionManager, ICognitoClients cognitoClients)
        {
            SignUpModel = new SignUp();
            _regionManager = regionManager;
            _cognitoService = cognitoClients;
            SignUpCommand = new DelegateCommand(SignUp);
            ShowSignInCommand = new DelegateCommand(ShowSignIn);
        }


        //
        private async void SignUp()
        {
            if (!SignUpModel.IsValidated)
            {
                SignUpModel.ErrorMsg = "All fields need to be filled as required!";
                return;
            }
            SignUpModel.CompanyPhoneNumber = FormatPhoneNumber(SignUpModel.CompanyPhoneNumber);
            SignUpModel.ContactPersonPhoneNumber = FormatPhoneNumber(SignUpModel.ContactPersonPhoneNumber);

            IDictionary<string, string> CompanyInfo = new Dictionary<string, string>();
            CompanyInfo.Add("CompanyName", SignUpModel.CompanyName);
            CompanyInfo.Add("CompanyAddress", SignUpModel.CompanyAddress);
            CompanyInfo.Add("PostalCode", SignUpModel.PostalCode);
            CompanyInfo.Add("Country", SignUpModel.Country);
            CompanyInfo.Add("State", SignUpModel.State);
            CompanyInfo.Add("City", SignUpModel.City);
            CompanyInfo.Add("CompanyEmail", SignUpModel.CompanyEmail);
            CompanyInfo.Add("Password", SignUpModel.CreatePassword);
            CompanyInfo.Add("CompanyPhoneNumber", SignUpModel.CompanyPhoneNumber);
            CompanyInfo.Add("ReasonForContact", SignUpModel.ReasonForContact);
            CompanyInfo.Add("ContactPerson", SignUpModel.ContactPerson);
            CompanyInfo.Add("ContactPersonPhoneNumber", SignUpModel.ContactPersonPhoneNumber);
            try
            {
                var result = await _cognitoService.SignUp(CompanyInfo);
                if (!result.Success)
                {
                    SignUpModel.ClearControlBasedOnMessage();
                }
                else
                {
                    _SignUpEmail = SignUpModel.CompanyEmail;
                    SignUpModel.BrushColor = Brushes.Green;
                    SignUpModel.ClearControlBasedOnMessage();
                    _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate("UserVerificationControl");
                }
            }
            catch
            {
                SignUpModel.BrushColor = Brushes.Red;
                SignUpModel.ErrorMsg = "All fields need to be filled as required!";
            }

            SignUpModel.ErrorMsg = string.Empty;
            foreach (var item in CompanyInfo)
            {
                Debug.WriteLine($"{item.Key}: {item.Value}");
            }
            SignUpModel.ClearControlBasedOnMessage();
        }
        private void ShowSignIn()
        {
            _regionManager.Regions[RegionNames.ContentRegion].RequestNavigate("SignInControl");

        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            if (SignUpModel.SelectedCountry.Code == null) return string.Empty;

            var countryCode = SignUpModel.CountryAreaCodeModel.CountryAreaCode[SignUpModel.SelectedCountry.Code];
            return countryCode + new string(phoneNumber.Where(char.IsDigit).ToArray());
        }
    }
}
