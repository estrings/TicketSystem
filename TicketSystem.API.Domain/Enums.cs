namespace TicketSystem.API.Domain
{
    public class Enums
    {
        public enum AccessType
        {
            Administrator = 1,
            Support = 2,
            Client = 3
        }

        public enum AccountStatus
        {
            InActive = 0,
            Active = 1
        }

        public enum AlertType
        {
            Client = 1,
            Support = 2
        }

        public enum TicketStatus
        {
            UnAssigned = 1,
            InProgress = 2,
            Closed = 3
        }

        public enum RequestType
        {
            Bug = 1,
            ChangeRequest = 2
        }

        public enum PriorityLevel
        {
            Low = 1,
            Medium = 2,
            High = 3
        }
    }
}
