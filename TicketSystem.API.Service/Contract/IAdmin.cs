using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.API.Common.Communication;

namespace TicketSystem.API.Service.Contract
{
    public interface IAdmin
    {
        Task<int?> GetTicketCount();
        Task<int?> GetOpenTicketCount();
        Task<int?> GetClosedTicketCount();
        Task<int?> GetTicketInProgressCount();
        Task<int?> GetClientCount();
        //Task<> GetAllRegisteredClients();
    }
}
