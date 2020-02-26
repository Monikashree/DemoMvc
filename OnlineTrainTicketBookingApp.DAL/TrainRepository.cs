using System.Data.SqlClient;
using OnlineTrainTicketBooking;
using System.Data;
namespace OnlineTrainTicketBookingApp.DAL
{
    public class TrainRepository
    {
        SqlConnection sqlConnection = Connectivity.EstablishConnection();
        public int AddTrainDetails(Train train)
        {
            using (SqlCommand sqlCommand = new SqlCommand("spInsertTrainDetails", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@trainNo", train.trainNo));
                sqlCommand.Parameters.Add(new SqlParameter("@trainName", train.trainName));
                sqlCommand.Parameters.Add(new SqlParameter("@sourceStation", train.sourceStation));
                sqlCommand.Parameters.Add(new SqlParameter("@destinationStation", train.destinationStation));
                sqlCommand.Parameters.Add(new SqlParameter("@departureTime", train.departTime));
                sqlCommand.Parameters.Add(new SqlParameter("@arrivalTime", train.arrivalTime));
                sqlCommand.Parameters.Add(new SqlParameter("@trainKM", train.trainKM));
                sqlCommand.Parameters.Add(new SqlParameter("@totalSeats", train.totalSeats));
                sqlCommand.Parameters.Add(new SqlParameter("@perTicketCost", train.fare));
                int retRows = sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                sqlConnection.Close();
                return retRows;
            }
        }
        public int UpdateTrainDetails(Train train)
        {
            using (SqlCommand sqlCommand = new SqlCommand("spUpdateTrainDetails", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@trainNo", train.trainNo));
                sqlCommand.Parameters.Add(new SqlParameter("@trainName", train.trainName));
                sqlCommand.Parameters.Add(new SqlParameter("@sourceStation", train.sourceStation));
                sqlCommand.Parameters.Add(new SqlParameter("@destinationStation", train.destinationStation));
                sqlCommand.Parameters.Add(new SqlParameter("@departureTime", train.departTime));
                sqlCommand.Parameters.Add(new SqlParameter("@arrivalTime", train.arrivalTime));
                sqlCommand.Parameters.Add(new SqlParameter("@trainKM", train.trainKM));
                sqlCommand.Parameters.Add(new SqlParameter("@totalSeats", train.totalSeats));
                sqlCommand.Parameters.Add(new SqlParameter("@perTicketCost", train.fare));
                int retRows = sqlCommand.ExecuteNonQuery();                
                sqlCommand.Dispose();
                sqlConnection.Close();
                return retRows;
            }
        }
        public DataTable ViewDetails()
        {
            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From TrainDetails", sqlConnection))
            {
                sqlDataAdapter.Fill(dataTable);
            }
            return dataTable;
        }
        public int DeleteTrainDetails(int trainNo)
        {
            using (SqlCommand sqlCommand = new SqlCommand("spDeleteTrainDetails", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();                
                sqlCommand.Parameters.Add(new SqlParameter("@trainNo", trainNo));
                int retRows = sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                sqlConnection.Close();
                return retRows;
            }
        }
    }
}
