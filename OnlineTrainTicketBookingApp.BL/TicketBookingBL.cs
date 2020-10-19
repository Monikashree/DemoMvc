using OnlineTrainTicketBookingApp.DAL;
using OnlineTrainTicketBookingApp.Entity;
using System.Collections.Generic;

namespace OnlineTrainTicketBookingApp.BL
{
    public interface ITicketBookingBL                   //Interface for TicketBooking BL 
    {
        bool AddBookingDetails(TicketBooking ticketBooking);
        int CalculateCost(int age, int cost);
        bool AddPassengerDetails(PassengerDetails passengerDetails);
        List<PassengerDetails> GetPassengerDetails(int bookingId);
        TicketBooking GetNoOfPassengers(int bookingId);
        int GetPassengerCountByID(int bookingId);
        List<TicketBooking> GetBookingId(int trainId, int classId, System.DateTime DOJ);
        bool ClearSeats(int bookingId);
        List<TicketBooking> GetBookingDetailsByIdandDOJ(int trainId, System.DateTime DOJ);
        int GetTotalCost(int bookingId);
    }
    public class TicketBookingBL : ITicketBookingBL         //Class implementing an interface of TicketBooking BL
    {
        ITicketBookingRepository ticketBookingRepository;
        public TicketBookingBL()                            //Constructor to create an object
        {
            ticketBookingRepository = new TicketBookingRepository();
        }
        public bool AddBookingDetails(TicketBooking ticketBooking)  // Method for Adding booking details
        {
            return ticketBookingRepository.AddBookingDetails(ticketBooking);
        }
        public int CalculateCost(int age, int cost)        //Method to calculate cost based on age
        {
            if (age < 18 || age >= 60)
            {
                cost = cost / 2;
            }
            return cost;
        }
        public bool AddPassengerDetails(PassengerDetails passengerDetails)  //Method to add passenger details
        {
            return ticketBookingRepository.AddPassengerDetails(passengerDetails);
        }
        public List<PassengerDetails> GetPassengerDetails(int bookingId)        //Method to get passenger details based on booking id
        {
            return ticketBookingRepository.GetPassengerDetails(bookingId);
        }
        public TicketBooking GetNoOfPassengers(int bookingId)               //Method to get number of passengers based on booking id
        {
            return ticketBookingRepository.GetNoOfPassengers(bookingId);
        }
        public int GetPassengerCountByID(int bookingId)                     //Method to get passenger counts based on current booking ID
        {
            return ticketBookingRepository.GetPassengerCountByID(bookingId);
        }
        public List<TicketBooking> GetBookingId(int trainId, int classId, System.DateTime DOJ)   //Method to get booking id using train id and class id
        {
            return ticketBookingRepository.GetBookingId(trainId, classId, DOJ);
        }
        public bool ClearSeats(int bookingId)                                      //Method to make seat number to 0 if the user cancel the ticket
        {
            return ticketBookingRepository.ClearSeats(bookingId);
        }
        public List<TicketBooking> GetBookingDetailsByIdandDOJ(int trainId, System.DateTime DOJ) //Method to get booking details based on train id and date of journey
        {
            return ticketBookingRepository.GetBookingDetailsByIdandDOJ(trainId, DOJ);
        }
        public int GetTotalCost(int bookingId)      //Method to get total money
        {
            return ticketBookingRepository.GetTotalCost(bookingId);
        }
    }
}
