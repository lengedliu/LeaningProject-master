using Expertsystem.Services;
using Expertsystem.Services.Interfaces;

namespace Expertsystem.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
