using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class AdminTicketVM
    {
        public Tickets tickets { get; set; }
        public int getTicketCount { get; set; }
        public int getOpenTicketCount { get; set; }
        public int getClosedTicketCount { get; set; }
        public int getTicketInProgressCount { get; set; }
        public int getClientCount { get; set; }
    }
}
