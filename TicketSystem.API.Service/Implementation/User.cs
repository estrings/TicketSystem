using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.API.Common.Communication;
using TicketSystem.API.Common.Helpers;
using TicketSystem.API.Domain.ViewModels;
using TicketSystem.API.Service.Contract;

namespace TicketSystem.API.Service.Implementation
{
    public class User : IUser
    {
        #region properties
        private readonly IConfiguration _configuration;
        private readonly IApiHelper _apiHelper;
        private readonly ILogger<User> _logger;
        private readonly IBase64Helper _encrypt;
        #endregion 
         
        #region constructor
        public User(IConfiguration configuration, IApiHelper apiHelper, ILogger<User> logger,IBase64Helper encrypt)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _apiHelper = apiHelper ?? throw new ArgumentNullException(nameof(apiHelper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _encrypt = encrypt ?? throw new ArgumentNullException(nameof(encrypt));
        }
        #endregion

        //public void AuthenticateUser()
        public async Task<LoginRegisteredUser> AuthenticateUser(Authenticate model)
        {
            LoginRegisteredUser res = null;
            try
            {
                string psdEncrypt = _encrypt.convertToBase64(model.password);
                model.password = psdEncrypt;
                var endpoint = _configuration.GetSection("API").GetSection("authenticate").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var json = JsonConvert.SerializeObject(model);
                HttpContent loginDetails = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, loginDetails);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<LoginRegisteredUser>(await response.Content.ReadAsStringAsync());
                 }
                else
                {
                    res = JsonConvert.DeserializeObject<LoginRegisteredUser>(await response.Content.ReadAsStringAsync());
                }
            }           
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }

        public void ChangeAccountStatus()
        {
            throw new NotImplementedException();
        }

        public void ChangePassword()
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfile> GetUserProfile(string username)
        {
            UserProfile res = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getuserprofile").Value + "email=" + username;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<UserProfile>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<UserProfile>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }

        public async Task<SaveRegisteredUser> RegisterUser(Registration model)
        {
            SaveRegisteredUser res = null;
            try
            {
                //encrypt password to base64
                string psdEncrypt = _encrypt.convertToBase64(model.password); 
                model.password = psdEncrypt; 
                var endpoint = _configuration.GetSection("API").GetSection("registerUser").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var json = JsonConvert.SerializeObject(model);
                HttpContent registrationDetails = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, registrationDetails);
                if (response.IsSuccessStatusCode)
                {
                   res = JsonConvert.DeserializeObject<SaveRegisteredUser>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<SaveRegisteredUser>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }

        public void UpdateProfile()
        {
            throw new NotImplementedException();
        }
        
    }
}
