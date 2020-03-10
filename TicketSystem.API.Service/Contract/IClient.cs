using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.API.Common.Communication;
using TicketSystem.API.Domain.ViewModels;

namespace TicketSystem.API.Service.Contract
{
    public interface IClient
    {
        /// <summary>
        /// returns list of all clients
        /// </summary>
        /// <returns></returns>
        Task<Clients> GetAllClients();

        /// <summary>
        /// registers a new client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<GenericResponse> RegisterClient(ClientVM model);

        /// <summary>
        /// registers a support team member
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<GenericResponse> RegisterSupport(Support model);

        /// <summary>
        /// update client details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<GenericResponse> UpdateClient(ClientVM model);

        /// <summary>
        /// returns a client profile
        /// </summary>
        /// <param name="clientEmail"></param>
        /// <returns></returns>
        Task<ClientProfile> ClientProfile(string clientEmail);

        /// <summary>
        /// creates a client user profile
        /// </summary>
        /// <param name="model"></param>
        Task<ProfileClientUser> ProfileClientUser(ProfileClientUserVM model);

        /// <summary>
        /// deletes a client
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        bool DeleteClient(int clientID);
    }
}
