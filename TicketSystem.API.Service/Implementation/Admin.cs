using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.API.Common.Communication;
using TicketSystem.API.Common.Helpers;
using TicketSystem.API.Service.Contract;

namespace TicketSystem.API.Service.Implementation
{
    public class Admin : IAdmin
    {
        #region properties
        private readonly IConfiguration _configuration;
        private readonly IApiHelper _apiHelper;
        private readonly ILogger<Admin> _logger;
        #endregion

        #region constructor
        public Admin(IConfiguration configuration, IApiHelper apiHelper, ILogger<Admin> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _apiHelper = apiHelper ?? throw new ArgumentNullException(nameof(apiHelper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion
        public async Task<int?> GetClientCount()
        {
            int? count = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getclientcount").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    GenericResponse res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                    count = res.recordCount;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return count;
        }

        public async Task<int?> GetClosedTicketCount()
        {
            int? count = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getclosedticketcount").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    GenericResponse res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                    count = res.recordCount;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return count;
        }

        public async Task<int?> GetOpenTicketCount()
        {
            int? count = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getopenticketcount").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    GenericResponse res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                    count = res.recordCount;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return count;
        }

        public async Task<int?> GetTicketCount()
        {
            int? count = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getticketcount").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    GenericResponse res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                    count = res.recordCount;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return count;
        }

        public async Task<int?> GetTicketInProgressCount()
        {
            int? count = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getinprogressticketcount").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    GenericResponse res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                    count = res.recordCount;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return count;
        }
    }
}
