using System.Net.Http;

namespace TicketSystem.API.Common.Helpers
{
    public interface IApiHelper
    {
        HttpClient InitializeClient();
    }
}
