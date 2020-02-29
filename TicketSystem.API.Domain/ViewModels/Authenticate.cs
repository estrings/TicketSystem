using System.ComponentModel.DataAnnotations;

namespace TicketSystem.API.Domain.ViewModels
{
    public class Authenticate
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
