using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class ClientProfile
    {
        public int responseCode { get; set; }
        public int recordCount { get; set; }
        public string respMessage { get; set; }
        public responseObject responseObject { get; set; }
    }

    public class responseObject
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string dataOnboarded { get; set; }
        public string phoneNumber { get; set; }
        public int numberOfAccounts { get; set; }
    }

}
