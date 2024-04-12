

using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using Expertsystem.Adapter.Information;
using Expertsystem.Services;
using Expertsystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Expertsystem.Services
{
    public class CognitoClient : ICognitoClients
    {

        private AmazonCognitoIdentityProviderClient _cognitoClient;
        private string _userPoolId;
        private string _appClientId;
        private readonly string Success = "success";

        public CognitoClient()
        {
           
        }



        public async Task<Response> SignUp(IDictionary<string, string> CompanyInfo)
        {
            SetParmar();
            string name = CompanyInfo["CompanyName"];
            try
            {
                var regRequest = new SignUpRequest
                {
                    // username must be phone number or email and will store as unique hashed string in aws USERPOOL. 
                    Username = CompanyInfo["CompanyEmail"],
                    ClientId = _appClientId,
                    Password = CompanyInfo["Password"],
                    UserAttributes = { new AttributeType { Name = "email", Value = CompanyInfo["CompanyEmail"] },
                                       new AttributeType { Name = "phone_number", Value=CompanyInfo["CompanyPhoneNumber"] },
                                       new AttributeType { Name = "custom:company_name", Value = CompanyInfo["CompanyName"] },
                                       new AttributeType { Name = "custom:company_address", Value = CompanyInfo["CompanyAddress"] },
                                       new AttributeType { Name = "custom:company_postalcode", Value = CompanyInfo["PostalCode"] },
                                       new AttributeType { Name = "custom:company_state", Value = CompanyInfo["PostalCode"] },
                                       new AttributeType { Name = "custom:company_city", Value = CompanyInfo["City"] },
                                       new AttributeType { Name = "custom:company_state", Value = CompanyInfo["State"] },
                                       new AttributeType { Name = "custom:company_country", Value = CompanyInfo["Country"] },
                                       new AttributeType { Name = "custom:contact_person", Value = CompanyInfo["ContactPerson"] },
                                       new AttributeType { Name = "custom:contact_person_phone", Value = CompanyInfo["ContactPersonPhoneNumber"] },
                                       new AttributeType { Name = "custom:reason_for_contact", Value = CompanyInfo["ReasonForContact"] }

                                      },

                };

                var ret = await _cognitoClient.SignUpAsync(regRequest);
                return new Response { Success = true, Message = ret.UserSub };

            }
            catch (Exception e)
            {

                Console.WriteLine($"{e.Message}");
                return new Response { Success = false, Message = e.Message };
            }

        }

        public async Task<Response> ConfirmSignUp(string email, string confirmationCode)
        {
            SetParmar();
            try
            {
                var confirmSignUpRequest = new ConfirmSignUpRequest
                {
                    Username = email,
                    ClientId = _appClientId,
                    ConfirmationCode = confirmationCode,
                };

                var ret = await _cognitoClient.ConfirmSignUpAsync(confirmSignUpRequest);

                Console.WriteLine(ret);
                return new Response { Success = true, Message = "Success" };
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                // ignoring lamda error response for now since its not doing any harm to process
                if (e.Message == "Invalid lambda function output : Invalid JSON")
                {
                    return new Response { Success = true, Message = "Success" };
                }
                return new Response { Success = false, Message = e.Message };

            }
        }

        //
        public async Task<Response> SignIn(string userName, string password)
        {
            SetParmar();
            try
            {
                var cognitoUserPool = new CognitoUserPool(_userPoolId, _appClientId, _cognitoClient);
                var cognitoUser = new CognitoUser(userName, _appClientId, cognitoUserPool, _cognitoClient);

                AuthFlowResponse authResponse = await cognitoUser.StartWithSrpAuthAsync(new InitiateSrpAuthRequest { Password = password });

                var accessToken = authResponse.AuthenticationResult.AccessToken;
                Console.WriteLine(accessToken);
                return new Response { Success = true, Message = accessToken };

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return new Response { Success = false, Message = e.Message };

            }

        }

        public async Task<Response> PasswordResetRequest(string userName)
        {
            SetParmar();
            try
            {
                var passwordReset = new ForgotPasswordRequest
                {
                    ClientId = _appClientId,
                    Username = userName

                };

                var res = await _cognitoClient.ForgotPasswordAsync(passwordReset);
                return new Response { Success = true, Message = "success" };
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return new Response { Success = false, Message = e.Message };
            }
        }

        public async Task<Response> ChangePassword(string verificationCode, string newPassword)
        {
            SetParmar();
            try
            {
                var confirmPassword = new ConfirmForgotPasswordRequest
                {
                    ClientId = _appClientId,
                    ConfirmationCode = verificationCode,
                    Password = newPassword
                };

                var res = await _cognitoClient.ConfirmForgotPasswordAsync(confirmPassword);
                return new Response { Success = true, Message = "success" };
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return new Response { Success = false, Message = e.Message };
            }
        }


        public async Task<Response> ResendConfirmationCode(string userName)
        {
            SetParmar();
            try
            {
                var codeRequest = new ResendConfirmationCodeRequest
                {
                    ClientId = _appClientId,
                    Username = userName,
                };
                var res = await _cognitoClient.ResendConfirmationCodeAsync(codeRequest);
                return new Response { Success = true, Message = "Success" };
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return new Response { Success = true, Message = e.Message };

            }
        }

        private void SetParmar()
        {
            _cognitoClient = AdapterInfo._cognitoClient;
            _userPoolId = AdapterInfo._userPoolId;
            _appClientId = AdapterInfo._appClientId;
        }
    }

}
