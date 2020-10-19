using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineTrainTicketBookingApp.DAL
{
    public interface ITrainDetailsRepository        //A dal interface to communicate with database
    {
        IEnumerable<TrainDetails> GetTrainDetails();
        bool AddTrainDetails(TrainDetails trainDetails);
        TrainDetails GetTrainByNo(int trainId);
        void UpdateTrainDetails(TrainDetails trainDetails);
        void DeleteTrainDetails(int trainNo);
        List<TrainDetails> SearchTrain(string source, string destination);
        List<TrainClassDetails> GetSeatDetailsById(int trainId);
    }
    public class TrainDetailsRepository : ITrainDetailsRepository
    {
        public bool AddTrainDetails(TrainDetails trainDetails)      //Method to add train details to Database
        {
            try
            {
                using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
                {
                    dbContext.TrainDetails.Add(trainDetails);
                    //dbContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[TrainDetails] ON");
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<TrainDetails> GetTrainDetails()      //Meethod to fetch train details from db
        {
            List<TrainDetails> trainList = new List<TrainDetails>();
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                trainList = dbContext.TrainDetails.ToList();
            }
            return trainList;
        }

        public TrainDetails GetTrainByNo(int trainId)           //Method to get train details based on id
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.TrainDetails.Find(trainId);
            }
        }
        public void UpdateTrainDetails(TrainDetails trainDetails)   //Method to update train details
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                TrainDetails details = GetTrainByNo(trainDetails.TrainId);
                dbContext.Entry(trainDetails).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
        public void DeleteTrainDetails(int trainNo)         //Method to delete train details by trainId
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                SqlParameter TrainId = new SqlParameter("@TrainId", trainNo);
                int result = dbContext.Database.ExecuteSqlCommand("sp_DeleteTrainDetails @TrainId", TrainId);
            }
        }

        public List<TrainDetails> SearchTrain(string source, string destination)    //Method to search train based on source and destination
        {
            List<TrainDetails> trainList = new List<TrainDetails>();
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                trainList = dbContext.TrainDetails.Where(m => m.SourceStation == source && m.DestinationStation == destination).ToList();
            }
            return trainList;
        }

        public List<TrainClassDetails> GetSeatDetailsById(int trainId)       //method to get seat details based on train id
        {
            //object value;
            List<TrainClassDetails> trainClassDetails;
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                //var data = (from td in dbContext.TrainDetails
                //            join tcd in dbContext.TrainClassDetails on td.TrainId equals tcd.TrainId where td.TrainId == id
                //            join tc in dbContext.TrainClass on tcd.ClassId equals tc.ClassId                            
                //            select new
                //            {
                //                td.TrainNo,
                //                td.TrainName,
                //                tc.ClassName,
                //                tcd.Seats,
                //                tcd.Cost
                //            }).ToList();
                //value = data;     
                trainClassDetails = dbContext.TrainClassDetails.Include("TrainClasses").Include("TrainDetails").Where(td => td.TrainId == trainId).ToList();


            }
            return trainClassDetails;
        }
    }
}
