using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineTrainTicketBookingApp.DAL
{
    public interface ITrainClassRepository      //Interface to higlight the actions of Train Class Repository
    {
        bool AddClass(TrainClass trainClass);
        List<TrainClass> GetClassDetails();
        List<TrainClassDetails> GetTrainClass(int trainId);
        List<TrainClass> GetTrainClassList();
        void AddTrainClass(TrainClassDetails trainClassDetails);
        void EditTrainClass(TrainClassDetails trainClassDetails);
        TrainClassDetails GetClass(int id);
        void DeleteTrainClass(TrainClassDetails trainClassDetails);
    }
    public class TrainClassRepository : ITrainClassRepository       //Implementing the interface
    {
        public bool AddClass(TrainClass trainClass)
        {
            try
            {
                using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())   //Adding train classes to the db
                {
                    dbContext.TrainClass.Add(trainClass);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<TrainClass> GetClassDetails()           //Method to get class details from db
        {
            TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext();
            return dbContext.TrainClass.ToList();
        }
        public List<TrainClassDetails> GetTrainClass(int trainId)       //Method to get particular class based on id
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.TrainClassDetails.Where(m => m.TrainId == trainId).ToList();
            }
        }

        public List<TrainClass> GetTrainClassList() //Method to get all the class categories
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.TrainClass.ToList();
            }
        }
        public void AddTrainClass(TrainClassDetails trainClassDetails)      //Method to add train class
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                dbContext.TrainClassDetails.Add(trainClassDetails);
                dbContext.SaveChanges();
            }
        }
        public TrainClassDetails GetClass(int id)   //Method to get class based on id
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.TrainClassDetails.Find(id);
            }
        }

        public void EditTrainClass(TrainClassDetails trainClassDetails)     //method to update train class
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                dbContext.Entry(trainClassDetails).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public void DeleteTrainClass(TrainClassDetails trainClassDetails)       //Method to delete train class using stored procedure
        {

            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                SqlParameter ClassId = new SqlParameter("@TrainClassDetailsId", trainClassDetails.TrainClassDetailsId);
                int result = dbContext.Database.ExecuteSqlCommand("sp_DeleteTrainClassDetails @TrainClassDetailsId", ClassId);
            }

        }
    }
}
