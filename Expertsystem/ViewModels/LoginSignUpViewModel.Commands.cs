using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Expertsystem.ViewModels
{
    public partial class LoginSignUpViewModel
    {
        private string _SignUpEmail = "";


        private void NavigateTo(UserControl nextControl, bool needNavigateHistroy = true)
        {
            
        }

       
        private void GoBack()
        {
            
        }

     
        private async Task SignIn()
        {
            // for testing Email: nishanthaw.ca@gmail.com  password : Password@123

           
        }

      
        private async Task SignUp()
        {
            var propertyNamesToValidate = new List<string>
                {
                    nameof(CompanyName),
                    nameof(CreatePassword),
                    nameof(ConfirmPassword),
                    nameof(CompanyAddress),
                    nameof(PostalCode),
                    nameof(Country),
                    nameof(State),
                    nameof(City),
                    nameof(CompanyEmail),
                    nameof(CompanyPhoneNumber),
                    nameof(ReasonForContact),
                    nameof(ContactPerson),
                    nameof(ContactPersonPhoneNumber)
                };
           

        }


       
        private async Task VerificationCodeSubmit()
        {
           
        }

        private async Task ResetPassword()
        {
            
        }


      
        private void BackToSignInClearHistory()
        {
            
        }
    }
}
