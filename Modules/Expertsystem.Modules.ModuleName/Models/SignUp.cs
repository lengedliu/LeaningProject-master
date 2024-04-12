using Expertsystem.Core.Mvvm;
using Expertsystem.Modules.ModuleName.Models.LocationData;
using Expertsystem.Modules.ModuleName.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Expertsystem.Modules.ModuleName.Models
{
    public class SignUp : ValidateModelBase
    {


        private string _companyName;
        [Required(ErrorMessage = "Company name is required.")]
        public string CompanyName
        {
            get => _companyName;
            set { _companyName = value; RaisePropertyChanged(); }
        }


        private string _createPassword;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password need to be more than 8")]
        [CustomValidation(typeof(SignUp), nameof(ValidateConfirmPassword))]
        public string CreatePassword
        {
            get => _createPassword;
            set
            {
                _createPassword = value; RaisePropertyChanged();
            }
        }

        private string _confirmPassword;

        [Required(ErrorMessage = "Confirm password is required.")]
        [CustomValidation(typeof(SignUp), nameof(ValidateConfirmPassword))]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                RaisePropertyChanged();
            }
        }

        private string _companyAddress;

        [Required(ErrorMessage = "Company address is required.")]
        public string CompanyAddress
        {
            get => _companyAddress;
            set { _companyAddress = value; RaisePropertyChanged(); }
        }

        private string _city;

        [Required(ErrorMessage = "City is required.")]
        public string City
        {
            get => _city;
            set { _city = value; RaisePropertyChanged(); }
        }

        private string _state;

        [Required(ErrorMessage = "State is required.")]
        public string State
        {
            get => _state;
            set { _state = value; RaisePropertyChanged(); }
        }

        private string _postalCode;

        [Required(ErrorMessage = "Postal code is required.")]
        public string PostalCode
        {
            get => _postalCode;
            set { _postalCode = value; RaisePropertyChanged(); }
        }

        private string _country;

        [Required(ErrorMessage = "Country is required.")]
        public string Country
        {
            get => _country;
            set { _country = value; RaisePropertyChanged(); }
        }

        private string _companyPhoneNumber;

        [Required(ErrorMessage = "phone number\n" + "is required")]
        public string CompanyPhoneNumber
        {
            get => _companyPhoneNumber;
            set { _companyPhoneNumber = value; RaisePropertyChanged(); }
        }

        private string _companyEmail;

        [Required(ErrorMessage = "Company email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email format.")]
        public string CompanyEmail
        {
            get => _companyEmail;
            set { _companyEmail = value; RaisePropertyChanged(); }
        }

        private string _reasonForContact;

        [Required(ErrorMessage = "Reason for contact is required.")]
        public string ReasonForContact
        {
            get => _reasonForContact;
            set { _reasonForContact = value; RaisePropertyChanged(); }
        }

        private string _contactPerson;

        [Required(ErrorMessage = "Contact person is required.")]
        public string ContactPerson
        {
            get => _contactPerson;
            set { _contactPerson = value; RaisePropertyChanged(); }
        }


        private string _contactPersonPhoneNumber;

        [Required(ErrorMessage = "phone number\n" + "is required")]
        [MaxLength(12, ErrorMessage = "The phone number is too long")]
        public string ContactPersonPhoneNumber
        {
            get => _contactPersonPhoneNumber;
            set { _contactPersonPhoneNumber = value; RaisePropertyChanged(); }
        }

        private string _resetNewPassword;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password need to be more than 8")]
        [CustomValidation(typeof(SignUp), nameof(ValidateCreatePassword))]
        public string ResetNewPassword
        {
            get => _resetNewPassword;
            set { _resetNewPassword = value; RaisePropertyChanged(); }
        }

        private string _confirmResetNewPassword;

        [Required(ErrorMessage = "Confirm password is required.")]
        [CustomValidation(typeof(SignUp), nameof(ValidateCreatePassword))]
        public string ConfirmResetNewPassword
        {
            get => _confirmResetNewPassword;
            set { _confirmResetNewPassword = value; RaisePropertyChanged(); }
        }




        private string _emailVerificationCode;

        public CountryStatesModel CountryStatesModel { get; } = new CountryStatesModel();

        public CountryAreaCodeModel CountryAreaCodeModel { get; } = new CountryAreaCodeModel();

        private ObservableCollection<string> _statesList = new ObservableCollection<string> { "Please select Country first" };
        public ObservableCollection<string> StatesList
        {
            get => _statesList;
            set
            {
                if (!EqualityComparer<ObservableCollection<string>>.Default.Equals(_statesList, value))
                {
                    _statesList = value;
                }
            }
        }

        private CountriesCodeModel _selectedCountry;

        public CountriesCodeModel SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                if (value != null)
                {
                    var countryCode = SelectedCountry.Code;
                    Country = SelectedCountry.Name;
                    StatesList.Clear();
                    foreach (var state in CountryStatesModel.CountryStates[countryCode])
                    {
                        StatesList.Add(state);
                    }
                }
            }
        }
        private ObservableCollection<CountriesCodeModel> _countries = new ObservableCollection<CountriesCodeModel> {
            new CountriesCodeModel("United States", "US"),
            new CountriesCodeModel("Canada", "CA"),
            new CountriesCodeModel("Australia", "AU")
        };
        public ObservableCollection<CountriesCodeModel> Countries
        {
            get { return _countries; }
            set
            {
                _countries = value;
            }
        }
        public ObservableCollection<string> ReasonForContactList { get; } = new ObservableCollection<string>
        {
            "General Inquiries",
            "Price Quote",
            "Follow-up On Phone Conversation",
            "Others"
        };

        public static ValidationResult ValidateConfirmPassword(string confirmPassword, ValidationContext context)
        {
            var viewModel = context.ObjectInstance as SignUp;
            if (viewModel == null)
            {
                return ValidationResult.Success!;
            }

            if (!string.Equals(viewModel.CreatePassword, confirmPassword))
            {
                return new ValidationResult("Confirm password does not\n" + "match Create password.");
            }

            return ValidationResult.Success!;
        }

        public static ValidationResult ValidateConfirmResetNewPassword(string confirmPassword, ValidationContext context)
        {
            var viewModel = context.ObjectInstance as SignUp;
            if (viewModel == null)
            {
                return ValidationResult.Success!;
            }

            if (!string.Equals(viewModel.ResetNewPassword, confirmPassword))
            {
                return new ValidationResult("Confirm password does not\n" + "match Create password.");
            }

            return ValidationResult.Success!;
        }

        public static ValidationResult ValidateCreatePassword(string createPassword, ValidationContext context)
        {
            var viewModel = context.ObjectInstance as SignUp;
            if (viewModel == null)
            {
                return ValidationResult.Success!;
            }

            var passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";

            if (!Regex.IsMatch(createPassword, passwordPattern))
            {
                return new ValidationResult(
                    "Password must contain:\n" +
                    "- At least one uppercase letter\n" +
                    "- At least one lowercase letter\n" +
                    "- At least one number\n" +
                    "- At least one special character."
                );
            }

            return ValidationResult.Success!;
        }
        private string _errorMsg;
        public string ErrorMsg
        {
            get => _errorMsg;
            set { _errorMsg = value; RaisePropertyChanged(); }
        }

        public void ClearControlBasedOnMessage()
        {
            CompanyName = "";
            CompanyAddress = "";
            PostalCode = "";
            Country = "";
            State = "";
            City = "";
            CompanyEmail = "";
            CreatePassword = "";
            ConfirmPassword = "";
            CompanyPhoneNumber = "";
            ReasonForContact = "";
            ContactPerson = "";
            ContactPersonPhoneNumber = "";
        }
    }
}
