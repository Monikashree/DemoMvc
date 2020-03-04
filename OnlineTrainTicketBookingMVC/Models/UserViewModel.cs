using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineTrainTicketBookingMVC.Models
{
    
    public class UserViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [RegularExpression("^[A-Z][a-z]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]
        public string FirstName { get; set; }       //Properties of user

        [RegularExpression("^[A-Z][a-z]*", ErrorMessage = "Valid Charactors include (A-Z) (a-z)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        //[RegularExpression("^ 0 ? ([1 - 9][0 - 9])$", ErrorMessage = "Enter Valid Age")]
        public short Age { get; set; }

        [Required(ErrorMessage = "Sex is required")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Email is required")]
        //[Index(IsUnique = true)]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]       
        public string Email { get; set; }

        [Required(ErrorMessage = "MobileNumber is required")]
        //[Index(IsUnique = true)]
        [RegularExpression("(0/91)?[6-9][0-9]{9}", ErrorMessage = "Please enter valid mobile number")]
        public long MobileNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]       
        [RegularExpression("^[A-Z][a-z]+@[0-9]+", ErrorMessage = "Please set Password as A-Za-z@0-9")]
        public string Password { get; set; }

        [Required]
        [NotMapped]     
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }

       
        public string Role { get; set; }

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