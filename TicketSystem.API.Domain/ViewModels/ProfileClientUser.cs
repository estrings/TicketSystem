using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class ProfileClientUser
    {
        public string password { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string clientId { get; set; }

    }
}
