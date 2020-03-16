using System.ComponentModel.DataAnnotations;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "UserName is required")]       
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]        
        public string Password { get; set; }
    }
}