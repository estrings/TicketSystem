namespace TicketSystem.API.Common.Communication
{
    public abstract class BaseResponse
    {
        public int responseCode { get; set; }
        public int recordCount { get; set; }
        public string responseMessage { get; set; }
    }
}
