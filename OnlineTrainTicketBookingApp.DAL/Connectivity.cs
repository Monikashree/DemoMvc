using System.Data.SqlClient;
using System.Configuration;

namespace OnlineTrainTicketBookingApp.DAL
{
    public static class Connectivity
    {
        public static SqlConnection EstablishConnection()
        {
            string connection = ConfigurationManager.ConnectionStrings["Sqlconnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connection);
            return sqlConnection;
        }
    }
}
