

namespace TicketSystem.API.Domain.ViewModels
{
    public class AdminVM
    {
        public Clients clients { get; set; }
        public int getTicketCount { get; set; }
        public int getOpenTicketCount { get; set; }
        public int getClosedTicketCount { get; set; }
        public int getTicketInProgressCount { get; set; }
        public int getClientCount { get; set; }
    }
}
