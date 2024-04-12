using Expertsystem.Core.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expertsystem.Modules.ModuleName.Models
{
    public class LoginModel : ValidateModelBase
    {
        private string _email;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "邮箱地址不合法")]
        public string Email
        {
            get => _email;
            set { _email = value; RaisePropertyChanged(); }
        }

        private string _password;
        [Required(ErrorMessage = "Password is required.")]
        public string Password
        {
            get => _password;
            set { _password = value; RaisePropertyChanged(); }
        }

        private string _loginSubmitResult;
        public string LoginSubmitResult
        {
            get { return _loginSubmitResult; }
            set
            {
                _loginSubmitResult = value;

            }
        }
    }
}
