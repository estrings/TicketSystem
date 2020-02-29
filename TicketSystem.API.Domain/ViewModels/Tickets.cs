using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class Tickets
    {
        public int responseCode { get; set; }
        public int recordCount { get; set; }
        public string responseMessage { get; set; }
        public IEnumerable<TicketDetails> responseObject { get; set; }
    }

    public class TicketDetails
    {
        public string id { get; set; }
        public string ticketId { get; set; }
        public string clientId { get; set; }
        public string description { get; set; }
        public string openDate { get; set; }
        public string closeDate { get; set; }
        public string requestType { get; set; }
        public string ticketStatus { get; set; }
        public string priorityLevel { get; set; }
        public string notes { get; set; }
    }
}
