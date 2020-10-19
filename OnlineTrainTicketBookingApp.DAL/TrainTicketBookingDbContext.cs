using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC;
using System.Data.Entity;

namespace OnlineTrainTicketBookingApp.DAL
{
    public class TrainTicketBookingDbContext : DbContext
    {
        public TrainTicketBookingDbContext() : base("DBConnectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainDetails>()                 // Stored procedure for TrainDetails
                 .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertTrainDetails"))
                 .Update(sp => sp.HasName("sp_UpdateTrainDetails"))
                 .Delete(sp => sp.HasName("sp_DeleteTrainDetails"))
                 );
            modelBuilder.Entity<TrainClassDetails>()            // Stored Procedure for TrainClassDetails
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertTrainClassDetails"))
                .Update(sp => sp.HasName("sp_UpdateTrainClassDetails"))
                .Delete(sp => sp.HasName("sp_DeleteTrainClassDetails"))
                );
        }
        public DbSet<User> User { get; set; }
        public DbSet<TrainDetails> TrainDetails { get; set; }
        public DbSet<TrainClass> TrainClass { get; set; }
        public DbSet<TrainClassDetails> TrainClassDetails { get; set; }
        public DbSet<TicketBooking> TicketBooking { get; set; }
        public DbSet<PassengerDetails> PassengerDetails { get; set; }
    }
}
