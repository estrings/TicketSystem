using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TicketSystem.API.Common.Helpers
{
    public class ApiHelper : IApiHelper
    {
        #region properties
        private readonly IConfiguration _configuration;
        private HttpClient ApiClient { get; set; }
        #endregion

        #region constructor
        public ApiHelper(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion        

        public HttpClient InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return ApiClient;
        }
    }
}
