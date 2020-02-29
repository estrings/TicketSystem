using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.API.Common.Helpers
{
    public interface IBase64Helper
    {
        /// <summary>
        /// accepts the password and converts it to base 64
        /// </summary>
        /// <param name="actualValue"></param>
        /// <returns></returns>
        string convertToBase64(string actualValue);

        /// <summary>
        /// decodes a base 64 string value
        /// </summary>
        /// <param name="base64Value"></param>
        /// <returns></returns>
        string decodeBase64(string base64Value);
    }
}
