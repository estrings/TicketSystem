using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.API.Common.Communication
{
    public class GenericResponse: BaseResponse
    {
        public object responseObject { get; set; }
    }
}
