using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class ClientVM
    {
        public string email { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }
}
