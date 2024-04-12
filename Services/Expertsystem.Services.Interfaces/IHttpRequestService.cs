using System.Threading.Tasks;

namespace Expertsystem.Services.Interfaces
{
    public interface IHttpRequestService
    {
        Task<string> HttpRequestGetMethod(string headerToken);
        Task<string> HttpRequestPostMethod(string headerToken, string strParam);
    }
}
