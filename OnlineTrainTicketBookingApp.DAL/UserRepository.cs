using System;
using OnlineTrainTicketBookingApp.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OnlineTrainTicketBookingApp.Entity;

namespace OnlineTrainTicketBookingMVC
{
    public interface IUserRepository        // Interface for Repository
    {
        bool AddUserDetails(User user);
        User CheckLoginDetails(string name, string password);
        User GetUserById(int id);
        void BlockUser(User user);
        List<User> GetUserDetails();
        // User GetUserByName(string name);
        bool UpdateProfile(User user);
        List<User> GetBlockedUserDetails();
    }
    public class UserRepository : IUserRepository           //Implementatiion of interface
    {

        //protected static List<User> userList = new List<User>();        //A static user list to store user details 
        //SqlConnection sqlConnection = DBUtils.GetDBConnection();
        //SqlConnection sqlConnection = Connectivity.EstablishConnection();
        //public int RegisterDetail(User user)            //Method to make user to register with the account
        //{
        //    using (SqlCommand sqlCommand = new SqlCommand("USER_ADMIN_Registration", sqlConnection))
        //    {
        //        sqlCommand.CommandType = CommandType.StoredProcedure;
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.Add(new SqlParameter("@firstname", user.FirstName));
        //        sqlCommand.Parameters.Add(new SqlParameter("@lastname", user.LastName));
        //        sqlCommand.Parameters.Add(new SqlParameter("@age", user.Age));
        //        sqlCommand.Parameters.Add(new SqlParameter("@sex", user.Sex));
        //        sqlCommand.Parameters.Add(new SqlParameter("@email", user.Email));
        //        sqlCommand.Parameters.Add(new SqlParameter("@mobileno", user.MobileNum));
        //        sqlCommand.Parameters.Add(new SqlParameter("@password", user.Password));
        //        sqlCommand.Parameters.Add(new SqlParameter("@role", user.Status));
        //        int retRows = sqlCommand.ExecuteNonQuery();
        //        sqlCommand.Dispose();
        //        sqlConnection.Close();
        //        return retRows;
        //    }            

        //}

        //public short VerifyWithDB(string userName, string passWord)
        //{

        //    using (SqlCommand sqlCommand = new SqlCommand("spCHECKDB", sqlConnection))
        //    {
        //        SqlParameter sqlParameter = new SqlParameter();
        //        sqlCommand.CommandType = CommandType.StoredProcedure;
        //        sqlCommand.Parameters.AddWithValue("@firstname", userName);
        //        sqlCommand.Parameters.AddWithValue("@password", passWord);
        //        sqlCommand.Parameters.Add("@id", SqlDbType.Int, 3);
        //        sqlCommand.Parameters["@id"].Direction = ParameterDirection.Output;
        //        sqlConnection.Open();
        //        sqlCommand.ExecuteNonQuery();
        //        short ID = Convert.ToInt16(sqlCommand.Parameters["@id"].Value);
        //        sqlConnection.Close();
        //        return ID;
        //    }
        //}

        //public string FetchRole(int ID)
        //{
        //    using (SqlCommand sqlCommand = new SqlCommand("spFETCHROLE", sqlConnection))
        //    {
        //        SqlParameter sqlParameter = new SqlParameter();
        //        sqlCommand.CommandType = CommandType.StoredProcedure;
        //        sqlCommand.Parameters.AddWithValue("@id", ID);
        //        sqlCommand.Parameters.Add("@role", SqlDbType.VarChar, 6);
        //        sqlCommand.Parameters["@role"].Direction = ParameterDirection.Output;
        //        sqlConnection.Open();
        //        sqlCommand.ExecuteNonQuery();
        //        string role = Convert.ToString(sqlCommand.Parameters["@role"].Value);
        //        sqlConnection.Close();
        //        return role;
        //    }
        //}


        //static List<User> userDetails = new List<User>();
        //static UserRepository()
        //{
        //    userDetails.Add(new User { FirstName = "Monika", LastName = "Kamaraj", Age = 21, Sex = "Female", Email = "monika@gmail.com", MobileNum = 8807697440, Password = "monika@@123", Status = (Role) Enum.Parse(typeof(Role), "Admin", true)});
        //}



        public bool AddUserDetails(User user)           //Adding user details
        {
            try
            {
                using (TrainTicketBookingDbContext userDataBase = new TrainTicketBookingDbContext())
                {
                    userDataBase.User.Add(user);
                    userDataBase.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        public User CheckLoginDetails(string name, string password)     //Method to check signin details
        {
            using (TrainTicketBookingDbContext userDataBase = new TrainTicketBookingDbContext())
            {
                User user = userDataBase.User.Where(m => m.FirstName == name && m.Password == password).FirstOrDefault();
                return user;
            }
        }

        public List<User> GetUserDetails()
        {
            List<User> user = new List<User>();
            using (TrainTicketBookingDbContext userDataBase = new TrainTicketBookingDbContext())
            {
                user = userDataBase.User.ToList();
            }
            return user;
        }

        public User GetUserById(int id)                     //Method to get details by id
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.User.Find(id);
            }
        }
        public void BlockUser(User user)                    // Method to block user
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        //public User GetUserByName(string name)                     //Method to get details by id
        //{
        //    using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
        //    {
        //        return dbContext.User.Find(name);
        //    }
        //}
        public bool UpdateProfile(User user)                    // Method to Update user
        {
            try
            {
                using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
                {
                    dbContext.Entry(user).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<User> GetBlockedUserDetails()               //Method to get blocked user list
        {
            List<User> user = new List<User>();
            using (TrainTicketBookingDbContext userDataBase = new TrainTicketBookingDbContext())
            {
                user = userDataBase.User.Where(m => m.IsActive == false).ToList();
            }
            return user;
        }
    }
}
