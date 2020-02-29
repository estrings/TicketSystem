using System.Threading.Tasks;
using TicketSystem.API.Common.Communication;
using TicketSystem.API.Domain.ViewModels;

namespace TicketSystem.API.Service.Contract
{
    public interface IUser
    {
        /// <summary>
        /// returns an object on successfully authentication containing responseCOde:200 and other parameters
        /// </summary>
        Task<LoginRegisteredUser> AuthenticateUser(Authenticate model);

        /// <summary>
        /// return an object on successful registration containing responseCOde:200 and other parameters 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<SaveRegisteredUser> RegisterUser(Registration model);

        /// <summary>
        /// 
        /// </summary>
        void ChangePassword();

        /// <summary>
        /// 
        /// </summary>
        void UpdateProfile();

        /// <summary>
        /// 
        /// </summary>
        void ChangeAccountStatus();

        /// <summary>
        /// returns the user profile
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<UserProfile> GetUserProfile(string username);
    }
}
