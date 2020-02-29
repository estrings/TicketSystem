using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.API.Common.Communication;
using TicketSystem.API.Domain.ViewModels;

namespace TicketSystem.API.Service.Contract
{
    public interface ITicket
    {
        /// <summary>
        /// returns all logged in ticket
        /// </summary>
        /// <returns></returns>
        Task<Tickets> GetAllTicket();
        /// <summary>
        /// creates a new ticket
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<GenericResponse> RaiseTicket(TicketVM model);

        /// <summary>
        /// returns a single ticket detail
        /// </summary>
        /// <param name="ticketID"></param>
        /// <returns></returns>
        Task<TicketDetail> GetTicket(string ticketID);

        /// <summary>
        /// returns all ticket assigned to a given client
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        Task<Tickets> GetTicketByClientId(string clientID);

        /// <summary>
        /// updates client ticket
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<GenericResponse> UpdateTicket(TicketUpdateVM model);
    }
}
