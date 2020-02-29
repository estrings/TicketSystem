using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class TicketUpdateVM
    {
        public TicketDetail ticketDetail { get; set; }
        public Clients clients { get; set; }
    }
}
