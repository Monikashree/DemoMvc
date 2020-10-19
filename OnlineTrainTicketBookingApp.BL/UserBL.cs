using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC;
using System.Collections.Generic;

namespace OnlineTrainTicketBookingApp.BL
{
    public interface IUserBL                    //An interface to highlight the User Bl methods
    {
        bool AddUserDetails(User user);
        List<User> GetUserDetails();
        User SignIn(string name, string password);
        User GetUserById(int id);
        void BlockUser(User user);
        //User GetUserByName(string name);
        bool UpdateProfile(User user);
        List<User> GetBlockedUserDetails();
    }

    public class UserBL : IUserBL
    {
        IUserRepository userRepository;
        public UserBL()
        {
            userRepository = new UserRepository();      //A reference to communicate with repository
        }

        public bool AddUserDetails(User user)
        {
            //UserRepository userRepository = new UserRepository();
            bool status = userRepository.AddUserDetails(user);  //Adding user deatils to Db
            return status;
        }
        public List<User> GetUserDetails()
        {
            return userRepository.GetUserDetails();
        }
        public User SignIn(string name, string password)    //Verifying the signin details of user with db
        {
            return userRepository.CheckLoginDetails(name, password);
        }
        public User GetUserById(int id)                     //Method to get particular details of user based on id
        {
            return userRepository.GetUserById(id);
        }
        public void BlockUser(User user)                    //Method to block user
        {
            userRepository.BlockUser(user);
        }
        //public User GetUserByName(string name)           //Method to get particular details of user based on name
        //{
        //    return userRepository.GetUserByName(name);
        //}
        public bool UpdateProfile(User user)                //Method to make user to update their profile
        {
            return userRepository.UpdateProfile(user);
        }
        public List<User> GetBlockedUserDetails()           //Method to get list of all blocked users
        {
            return userRepository.GetBlockedUserDetails();
        }
    }
}
