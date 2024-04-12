
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Expertsystem.Services.Interfaces
{
        
    public interface ICognitoClients
    {
        Task<Response> SignUp(IDictionary<string,string> CompanyInfo);
        Task<Response> ConfirmSignUp(string email, string confirmationCode);
        Task<Response> SignIn(string email, string password);
        Task<Response> PasswordResetRequest(string userName);
        Task<Response> ChangePassword(string verificationCode, string newPassword);
    }
}
