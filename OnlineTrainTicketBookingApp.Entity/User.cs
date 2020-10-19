using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTrainTicketBookingApp.Entity
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [MaxLength(200)]
        [Index(IsUnique = true)]
        public string FirstName { get; set; }       //Properties of user with key constraints


        public string LastName { get; set; }

        [Required]
        [Range(18, 100)]
        public short Age { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        [MaxLength(200)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public long MobileNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public bool IsActive { get; set; }
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
        public User()
        {

        }
    }
}
