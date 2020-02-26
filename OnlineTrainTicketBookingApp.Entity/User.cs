using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineTrainTicketBooking
{
    public enum Role
    {
        User, Admin
    }
    public class User
    {

        [Required (ErrorMessage = "FirstName is required")]
        //[RegularExpression("")]
        public string FirstName { get; set; }       //Properties of user
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public short Age { get; set; }
        [Required(ErrorMessage = "Sex is required")]
        public string Sex { get; set; }
        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        public long MobileNum { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public Role Status { get; set; }
        
        //public User(string firstName, string lastName, short age, string sex, string email, long mobileNum, string password, Role role)
        //{
        //    firstName = FirstName;
        //    lastName = LastName;
        //    age = Age;
        //    sex = Sex;
        //    email = Email;
        //    mobileNum = MobileNum;
        //    password = Password;           
        //    role = Status;
            
        //}

        //public override string ToString()       //Overriding to string method for reusability
        //{
        //    return firstName + " " + lastName + " " + age + " " + sex + " " + email + " " + mobileNum + " " + password + " " + role;
        //}
    }
}
