using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class Clients
    {
        public int responseCode { get; set; }
        public int recordCount { get; set; }
        public string responseMessage { get; set; }
        public IEnumerable<ClientDetails> responseObject { get; set; }
    }

    public class ClientDetails
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
    }
}
