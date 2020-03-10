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
using TicketSystem.API.Domain.ViewModels;
using TicketSystem.API.Service.Contract;
using static TicketSystem.API.Domain.Enums;

namespace TicketSystem.API.Service.Implementation
{
    public class Client : IClient
    {
        #region properties
        private readonly IConfiguration _configuration;
        private readonly IApiHelper _apiHelper;
        private readonly IBase64Helper _base64Helper;
        private readonly ILogger<Client> _logger;
        #endregion

         #region constructor
        public Client(IConfiguration configuration, IApiHelper apiHelper, ILogger<Client> logger,IBase64Helper base64Helper)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _apiHelper = apiHelper ?? throw new ArgumentNullException(nameof(apiHelper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _base64Helper = base64Helper ?? throw new ArgumentNullException(nameof(base64Helper));
        }

        public async Task<ClientProfile> ClientProfile(string clientEmail)
        {
            ClientProfile res = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("clientProfile").Value+"email="+clientEmail;
                HttpClient client = _apiHelper.InitializeClient();

                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<ClientProfile>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<ClientProfile>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;

        }
        #endregion

        public bool DeleteClient(int clientID)
        {
            throw new NotImplementedException();
        }

        public async Task<Clients> GetAllClients()
        {
            Clients res = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getallclientprofiles").Value;
                HttpClient client = _apiHelper.InitializeClient();               
                
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<Clients>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<Clients>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }

        public async Task<ProfileClientUser> ProfileClientUser(ProfileClientUserVM model)
        {
            ProfileClientUser res = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("registerClientUser").Value;
                HttpClient client = _apiHelper.InitializeClient();
                model.profileClientUser.password = _base64Helper.convertToBase64(model.profileClientUser.password);
                var json = JsonConvert.SerializeObject(model.profileClientUser);
                HttpContent registrationDetails = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, registrationDetails);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<ProfileClientUser>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<ProfileClientUser>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }

        public async Task<GenericResponse> RegisterClient(Domain.ViewModels.ClientVM model)
        {
            GenericResponse res = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("registerClient").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var json = JsonConvert.SerializeObject(model);
                HttpContent registrationDetails = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint,registrationDetails);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }

        public async Task<GenericResponse> RegisterSupport(Support model)
        {
            GenericResponse res = null;
            try
            {
                string _accessType = Enum.GetName(typeof(AccessType), Convert.ToInt32(model.accessType));
                model.accessType = _accessType;
                model.password = _base64Helper.convertToBase64(model.password);
                var endpoint = _configuration.GetSection("API").GetSection("registerUser").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var json = JsonConvert.SerializeObject(model);
                HttpContent registrationDetails = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, registrationDetails);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<GenericResponse>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }


        Task<GenericResponse> IClient.UpdateClient(ClientVM model)
        {
            throw new NotImplementedException();
        }
    }
}
