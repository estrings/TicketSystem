using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Common.Communication
{
    public class LoginRegisteredUser : BaseResponse
    {
        public LoginParameters responseObject { get; set; }

    }
    
    public class LoginParameters
    {
        public string authToken { get; set; }
        public UserObject userObject { get; set; } 
    }

    public class UserObject
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
        public int? client { get; set; }
    }

}
