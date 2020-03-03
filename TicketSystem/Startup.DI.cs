using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.API.Common.Helpers;
using TicketSystem.API.Service.Contract;
using TicketSystem.API.Service.Implementation;

namespace TicketSystem
{
    public partial class Startup
    {
        public IServiceCollection ConfigureDIServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Http Client
            services.AddTransient<IApiHelper,ApiHelper>();
            //user service
            services.AddTransient<IUser,User>();
            //Client service
            services.AddTransient<IClient,Client>();
            //Ticket Service
            services.AddTransient<ITicket,Ticket>();
            //Admin Service
            services.AddTransient<IAdmin,Admin>();
            //password encrypt service
            services.AddTransient<IBase64Helper,Base64Helper>();
            return services;
        }
    }
}
