using OnlineTrainTicketBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTrainTicketBookingApp.DAL
{
    public interface ITicketBookingRepository               //Interface to highlight Ticket booking methods
    {
        bool AddBookingDetails(TicketBooking ticketBooking);
        bool AddPassengerDetails(PassengerDetails passengerDetails);
        List<PassengerDetails> GetPassengerDetails(int bookingId);
        TicketBooking GetNoOfPassengers(int bookingId);
        int GetPassengerCountByID(int bookingId);
        List<TicketBooking> GetBookingId(int trainId, int classId, DateTime DOJ);
        bool ClearSeats(int bookingId);
        List<TicketBooking> GetBookingDetailsByIdandDOJ(int trainId, DateTime DOJ);
        int GetTotalCost(int bookingId);
    }
    public class TicketBookingRepository : ITicketBookingRepository      //Class to implement an interface Ticket booking repository
    {
        public bool AddBookingDetails(TicketBooking ticketBooking)      // Method to add booking details to db
        {
            try
            {
                using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
                {
                    dbContext.TicketBooking.Add(ticketBooking);
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

        public bool AddPassengerDetails(PassengerDetails passengerDetails)              //Method to add passenger details to db
        {
            try
            {
                using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
                {
                    dbContext.PassengerDetails.Add(passengerDetails);
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

        public List<PassengerDetails> GetPassengerDetails(int bookingId)       //Method to get passenger details based on booking id
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.PassengerDetails.Where(m => m.BookingId == bookingId).ToList();
            }
        }
        public TicketBooking GetNoOfPassengers(int bookingId)               //method to get number of passengers based on booking id
        {
            //TicketBooking ticketBooking;
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                //var data = from tb in dbContext.TicketBooking where tb.BookingId == bookingId select tb.NoOfPassengers;
                return dbContext.TicketBooking.Where(m => m.BookingId == bookingId).FirstOrDefault();
            }
            //return passenger;
        }
        public int GetPassengerCountByID(int bookingId)         //Method to get passenger count in passenger details based on current booking id
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return (from x in dbContext.PassengerDetails where x.BookingId == bookingId && x.SeatNo != 0 select x).Count();
            }
        }
        public List<TicketBooking> GetBookingId(int trainId, int classId, DateTime DOJ)   //method to get booking id based on train id and class id
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.TicketBooking.Where(m => m.TrainId == trainId && m.ClassId == classId && m.JourneyDate == DOJ).ToList();
            }
        }
        public bool ClearSeats(int bookingId)       //method to make the seat no to 0 if the user cancel the booking
        {
            try
            {
                using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
                {
                    var seats = dbContext.PassengerDetails.Where(m => m.BookingId == bookingId);
                    foreach (var item in seats)
                    {
                        item.SeatNo = 0;
                    }
                    // dbContext.TicketBooking.Where(m=> m.BookingId == bookingId).
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<TicketBooking> GetBookingDetailsByIdandDOJ(int trainId, DateTime DOJ)   //Method to get booking details based on traind id and Date of journey
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.TicketBooking.Where(m => m.TrainId == trainId && m.JourneyDate == DOJ).ToList();
            }
        }

        public int GetTotalCost(int bookingId)          //Method to get total money
        {
            using (TrainTicketBookingDbContext dbContext = new TrainTicketBookingDbContext())
            {
                return dbContext.PassengerDetails.Where(m => m.BookingId == bookingId).Sum(m => m.Cost);
            }
        }
    }
}
