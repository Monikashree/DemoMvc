using System;
using System.Data;
using System.Data.SqlClient;
using OnlineTrainTicketBookingApp.DAL;
using System.Collections.Generic;


namespace OnlineTrainTicketBooking
{ 
    public class UserRepository
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


        static List<User> userDetails = new List<User>();
        static UserRepository()
        {
            userDetails.Add(new User { FirstName = "Monika", LastName = "Kamaraj", Age = 21, Sex = "Female", Email = "monika@gmail.com", MobileNum = 8807697440, Password = "monika@@123", Status = (Role) Enum.Parse(typeof(Role), "Admin", true)});
        }
        public void AddUserDetails(User user)
        {
            userDetails.Add(user);
        }
        public static IEnumerable<User> ShowDetails()
        {
            return userDetails;
        }

    }
}
 