using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class Registration
    {
        public string password { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string accessType { get; set; }
        //public string clientId { get; set; }
    }
}
