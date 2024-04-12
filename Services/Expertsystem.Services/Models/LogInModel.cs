namespace Expertsystem.Services.Models
{
    public class LogInModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LogInModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
