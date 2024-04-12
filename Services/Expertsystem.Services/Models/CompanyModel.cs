using CommunityToolkit.Mvvm.ComponentModel;

namespace Expertsystem.Services.Models
{
    public partial class CompanyModel : ObservableValidator
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string ReasonForContact { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonPhoneNumber { get; set; }
        public CompanyModel(string companyName, string companyAddress, string city, string state, string postalCode, string country, string companyPhoneNumber, string companyEmail, string reasonForContact, string contactPerson, string contactPersonPhoneNumber)
        {
            CompanyName = companyName;
            CompanyAddress = companyAddress;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            CompanyPhoneNumber = companyPhoneNumber;
            CompanyEmail = companyEmail;
            ReasonForContact = reasonForContact;
            ContactPerson = contactPerson;
            ContactPersonPhoneNumber = contactPersonPhoneNumber;
        }
    }
}

