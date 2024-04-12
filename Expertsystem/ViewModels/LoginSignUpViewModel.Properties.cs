using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Expertsystem.ViewModels
{
    public partial class LoginSignUpViewModel
    {
        //返回 标记 显示
        public Visibility GoBackVisibility => Visibility.Visible;

        

        private string _companyName;
        [Required(ErrorMessage = "Company name is required.")]
        public string CompanyName
        {
            get => _companyName;
            set => SetProperty(ref _companyName, value);
        }


        private string _createPassword;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password need to be more than 8")]
        [CustomValidation(typeof(LoginSignUpViewModel), nameof(ValidateCreatePassword))]
        public string CreatePassword
        {
            get => _createPassword;
            set
            {
                SetProperty(ref _createPassword, value);
            }
        }

        private string _confirmPassword;

        [Required(ErrorMessage = "Confirm password is required.")]
        [CustomValidation(typeof(LoginSignUpViewModel), nameof(ValidateConfirmPassword))]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                SetProperty(ref _confirmPassword, value);
            }
        }

        private string _companyAddress;

        [Required(ErrorMessage = "Company address is required.")]
        public string CompanyAddress
        {
            get => _companyAddress;
            set => SetProperty(ref _companyAddress, value);
        }

        private string _city;

        [Required(ErrorMessage = "City is required.")]
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private string _state;

        [Required(ErrorMessage = "State is required.")]
        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        private string _postalCode;

        [Required(ErrorMessage = "Postal code is required.")]
        public string PostalCode
        {
            get => _postalCode;
            set => SetProperty(ref _postalCode, value);
        }

        private string _country;

        [Required(ErrorMessage = "Country is required.")]
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private string _companyPhoneNumber;

        [Required(ErrorMessage = "phone number\n" + "is required")]
        public string CompanyPhoneNumber
        {
            get => _companyPhoneNumber;
            set => SetProperty(ref _companyPhoneNumber, value);
        }

        private string _companyEmail;

        [Required(ErrorMessage = "Company email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email format.")]
        public string CompanyEmail
        {
            get => _companyEmail;
            set => SetProperty(ref _companyEmail, value);
        }

        private string _reasonForContact;

        [Required(ErrorMessage = "Reason for contact is required.")]
        public string ReasonForContact
        {
            get => _reasonForContact;
            set => SetProperty(ref _reasonForContact, value);
        }

        private string _contactPerson;

        [Required(ErrorMessage = "Contact person is required.")]
        public string ContactPerson
        {
            get => _contactPerson;
            set => SetProperty(ref _contactPerson, value);
        }


        private string _contactPersonPhoneNumber;

        [Required(ErrorMessage = "phone number\n" + "is required")]
        [MaxLength(12, ErrorMessage = "The phone number is too long")]
        public string ContactPersonPhoneNumber
        {
            get => _contactPersonPhoneNumber;
            set => SetProperty(ref _contactPersonPhoneNumber, value);
        }

        private string _resetNewPassword;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password need to be more than 8")]
        [CustomValidation(typeof(LoginSignUpViewModel), nameof(ValidateCreatePassword))]
        public string ResetNewPassword
        {
            get => _resetNewPassword;
            set
            {
                SetProperty(ref _resetNewPassword, value);
            }
        }

        private string _confirmResetNewPassword;

        [Required(ErrorMessage = "Confirm password is required.")]
        [CustomValidation(typeof(LoginSignUpViewModel), nameof(ValidateConfirmResetNewPassword))]
        public string ConfirmResetNewPassword
        {
            get => _confirmResetNewPassword;
            set
            {
                SetProperty(ref _confirmResetNewPassword, value);
            }
        }

        private string _emailVerificationCode;

    

        public ObservableCollection<string> ReasonForContactList { get; } = new ObservableCollection<string>
        {
            "General Inquiries",
            "Price Quote",
            "Follow-up On Phone Conversation",
            "Others"
        };

        public static ValidationResult ValidateConfirmPassword(string confirmPassword, ValidationContext context)
        {
            var viewModel = context.ObjectInstance as LoginSignUpViewModel;
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
            var viewModel = context.ObjectInstance as LoginSignUpViewModel;
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
            var viewModel = context.ObjectInstance as LoginSignUpViewModel;
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
    }
}
