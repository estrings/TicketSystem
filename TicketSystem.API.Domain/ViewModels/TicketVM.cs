using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class TicketVM
    {
        public Ticket ticket { get; set; }
        public Clients clients { get; set; }
        public string requestType { get; set; }
        public string priorityLevel { get; set; }
    }
}
