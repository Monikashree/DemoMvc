using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class TicketBookingController : Controller
    {

        // GET: TicketBooking
        ITicketBookingBL ticketBookingBL;
        public TicketBookingController()
        {
            ticketBookingBL = new TicketBookingBL();

        }

        public ActionResult BookTicket(int t_Id,int t_No, int c_id, string c_Name, int seat, int cost)
        {
            TempData["T_Id"] = t_Id;
            TempData["T_No"] = t_No;
            TempData["C_Id"] = c_id;
            TempData["C_Name"] = c_Name;
            TempData["Seat"] = seat;
            TempData["Cost"] = cost;
            return View();
        }

        [HttpPost]
        public ActionResult BookTicket(TicketBookingViewModel ticketBookingViewModel)
        {
            ticketBookingViewModel.TrainId = (int)TempData["T_Id"];
            ticketBookingViewModel.UserId = Convert.ToInt32(Session["UserId"]);
            ticketBookingViewModel.ClassId = (int)TempData["C_Id"];
            ticketBookingViewModel.BookingTime = DateTime.Now;
            int trainNo = (int)TempData["T_No"];
            string className = TempData["C_Name"].ToString();
            if (ModelState.IsValid)
            {   
                TicketBooking ticketBooking = AutoMapper.Mapper.Map<TicketBookingViewModel, TicketBooking>(ticketBookingViewModel);                
                if(!ticketBookingBL.AddBookingDetails(ticketBooking))
                {
                    return RedirectToAction("BookTicket");
                }                
                TempData["BookingId"] = ticketBooking.BookingId;
                TempData["Doj"] = ticketBooking.JourneyDate;
                TempData["NoOfSeats"] = (int)TempData["Seat"];
                //int seat = (int)TempData["Seat"];
                TempData["TrainNo"] = trainNo;
                TempData["ClassName"] = className;
                //return RedirectToAction("AddPassenger", "TicketBooking", new { @trainNo = trainNo, @className = className});
                return RedirectToAction("AddPassenger", "TicketBooking");
            }
            //TempData["TrainId"] = (int)TempData["T_Id"];
            //TempData["ClassId"] = (int)TempData["C_Id"];
            return RedirectToAction("BookTicket");
        }

       
        public ActionResult AddPassenger()
        {
            //TempData["TrainNo"] = trainNo;
            //TempData["ClassName"] = className;
            //TempData["Seats"] = seat;
            List<TicketBooking> ticketBookingList = ticketBookingBL.GetBookingId((int)TempData["T_Id"], (int)TempData["C_Id"]);
            List<PassengerDetailsViewModel> passengerDetailsViewModelList = new List<PassengerDetailsViewModel>();
            foreach(TicketBooking booking in ticketBookingList)
            {
                List<PassengerDetails> passengerDetailsList = ticketBookingBL.GetPassengerDetails(booking.BookingId);
                foreach(PassengerDetails passengerDetails in passengerDetailsList)
                {
                    PassengerDetailsViewModel passengerDetailsViewModel = AutoMapper.Mapper.Map<PassengerDetails, PassengerDetailsViewModel>(passengerDetails);
                    passengerDetailsViewModelList.Add(passengerDetailsViewModel);
                } 
            }
            ViewBag.Seats = passengerDetailsViewModelList;
            return View();
            //return View(Tuple.Create<PassengerDetailsViewModel, IEnumerable<PassengerDetailsViewModel>>(new PassengerDetailsViewModel(), passengerDetailsViewModelList));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPassenger(PassengerDetailsViewModel passengerDetailsViewModel)
        {
            passengerDetailsViewModel.BookingId = (int)TempData["BookingId"];
            passengerDetailsViewModel.Cost = ticketBookingBL.CalculateCost(passengerDetailsViewModel.Age, (int)TempData["Cost"]);
            if(ModelState.IsValid)
            {
                PassengerDetails passengerDetails = AutoMapper.Mapper.Map<PassengerDetailsViewModel, PassengerDetails>(passengerDetailsViewModel);
                if(ticketBookingBL.AddPassengerDetails(passengerDetails))
                {
                    return RedirectToAction("DisplayPassengerDetails", "TicketBooking");
                }
            }
            return View(passengerDetailsViewModel);
        }
        public ActionResult DisplayPassengerDetails()
        {
            TicketBooking ticketBooking = ticketBookingBL.GetNoOfPassengers(Convert.ToInt32(TempData["BookingId"]));
            TempData["NOP"] = ticketBooking.NoOfPassengers;
            TempData["Count"] = ticketBookingBL.GetPassengerCountByID(Convert.ToInt32(TempData["BookingId"]));
            List<PassengerDetails> passengerList = ticketBookingBL.GetPassengerDetails(Convert.ToInt32(TempData["BookingId"]));
            List<PassengerDetailsViewModel> passengerViewModelList = new List<PassengerDetailsViewModel>();
            foreach (PassengerDetails details in passengerList)
            {                                                                           //Display passenger Details
                PassengerDetailsViewModel passengerDetailsViewModel = AutoMapper.Mapper.Map<PassengerDetails, PassengerDetailsViewModel>(details);
                passengerViewModelList.Add(passengerDetailsViewModel);
            }
            return View(passengerViewModelList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DisplayPassengerDetails(PassengerDetails passengerDetails)
        {
            return View();
        }

        public ActionResult ClearSeats(int id)
        {
            bool status = ticketBookingBL.ClearSeats(id);
            return RedirectToAction("HomePage", "Home");
        }
    }
}