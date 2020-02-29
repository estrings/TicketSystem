using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class TicketDetail
    {
        public int responseCode { get; set; }
        public int recordCount { get; set; }
        public string responseMessage { get; set; }
        public SingleTicket responseObject { get; set; }
    }
    
    public class SingleTicket
    {
        public string id { get; set; }
        public string ticketId { get; set; }
        public string client { get; set; }
        public string description { get; set; }
        public string openDate { get; set; }
        public string closeDate { get; set; }
        public string requestType { get; set; }
        public string ticketStatus { get; set; }
        public string priorityLevel { get; set; }
        public string notes { get; set; }
    }
}
