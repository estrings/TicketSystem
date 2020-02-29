using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Domain.ViewModels
{
    public class UserProfile
    {
        public int responseCode { get; set; }
        public int recordCount { get; set; }
        public ResponseObject responseObject { get; set; }
        public string respMessage { get; set; }
    }

    public class ResponseObject
    {
        public string id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public int accessTypeId { get; set; }
        public string accessType { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string dateCreated { get; set; }
        public string lastLogin { get; set; }
        public string lastPasswordChange { get; set; }
        public string clientId { get; set; }
    }
}
