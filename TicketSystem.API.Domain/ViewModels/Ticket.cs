using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public partial class Ticket
    {
        [Required]
        public string client { get; set; }
        [Required]
        public string description { get; set; }
        public string requestType { get; set; }
        public string priorityLevel { get; set; }
        [Required]
        public string notes { get; set; }
    }
}
