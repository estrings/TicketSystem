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
using TicketSystem.API.Domain;
using TicketSystem.API.Domain.ViewModels;
using TicketSystem.API.Service.Contract;
using static TicketSystem.API.Domain.Enums;

namespace TicketSystem.API.Service.Implementation
{
    public class Ticket : ITicket
    {
        #region properties
        private readonly IConfiguration _configuration;
        private readonly IApiHelper _apiHelper;
        private readonly ILogger<Ticket> _logger;
        #endregion

        #region constructor
        public Ticket(IConfiguration configuration, IApiHelper apiHelper, ILogger<Ticket> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _apiHelper = apiHelper ?? throw new ArgumentNullException(nameof(apiHelper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Tickets> GetAllTicket()
        {
            Tickets res = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getalltickets").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<Tickets>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<Tickets>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }

        public async Task<TicketDetail> GetTicket(string ticketID)
        {
            TicketDetail res = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getticket").Value + "ticketId=" + ticketID;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<TicketDetail>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<TicketDetail>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }

        public async Task<Tickets> GetTicketByClientId(string clientID)
        {
            Tickets res = null;
            try
            {
                var endpoint = _configuration.GetSection("API").GetSection("getallticketsbyclientid").Value+"clientid="+clientID;
                HttpClient client = _apiHelper.InitializeClient();
                var response = await client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    res = JsonConvert.DeserializeObject<Tickets>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    res = JsonConvert.DeserializeObject<Tickets>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex?.InnerException?.InnerException?.Message}");
            }
            return res;
        }
        #endregion

        public async Task<GenericResponse> RaiseTicket(TicketVM model)
        {
            GenericResponse res = null;
            try
            {
                string _requestType = Enum.GetName(typeof(RequestType),Convert.ToInt32(model.requestType));
                string _priorityLevel = Enum.GetName(typeof(PriorityLevel),Convert.ToInt32(model.priorityLevel));
                model.ticket.requestType = _requestType;
                model.ticket.priorityLevel = _priorityLevel;
                var endpoint = _configuration.GetSection("API").GetSection("raiseticket").Value;
                HttpClient client = _apiHelper.InitializeClient();
                var json = JsonConvert.SerializeObject(model.ticket);
                HttpContent raiseTicket = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endpoint, raiseTicket);
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
    }
}
