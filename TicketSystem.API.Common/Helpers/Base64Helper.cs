using System;

namespace TicketSystem.API.Common.Helpers
{
    public class Base64Helper : IBase64Helper
    {
        public string convertToBase64(string password)
        {
            string _password = password.Trim();
            byte[] encodedBytes = System.Text.Encoding.Unicode.GetBytes(_password);
            string encodedPassword = Convert.ToBase64String(encodedBytes);
            return encodedPassword;
        }

        public string decodeBase64(string base64Value)
        {
            string _base64Value = base64Value.Trim();
            string actualValue;
            byte[] data = Convert.FromBase64String(base64Value);
            actualValue = System.Text.ASCIIEncoding.ASCII.GetString(data);
            return actualValue;
        }
    }
}
