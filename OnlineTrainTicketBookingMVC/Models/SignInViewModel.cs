using System.ComponentModel.DataAnnotations;

namespace OnlineTrainTicketBookingMVC.Models
{
    public class SignInViewModel            //An entity with Signin attributes 
    {
        [Required(ErrorMessage = "UserName is required")]       
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]        
        public string Password { get; set; }
    }
}