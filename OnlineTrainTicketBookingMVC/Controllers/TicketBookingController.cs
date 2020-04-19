using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;
using System;
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

        public ActionResult BookTicket(int id,int no, int c_id, string name)
        {
            TempData["id"] = id;
            TempData["no"] = no;
            TempData["c_id"] = c_id;
            TempData["name"] = name;
            return View();
        }

        [HttpPost]
        public ActionResult BookTicket(TicketBookingViewModel ticketBookingViewModel)
        {
            if(ModelState.IsValid)
            {
                ticketBookingViewModel.TrainId = (int)TempData["id"];
                ticketBookingViewModel.UserId = (int)Session["UserId"];
                ticketBookingViewModel.BookingTime = DateTime.Now;
                TicketBooking ticketBooking = AutoMapper.Mapper.Map<TicketBookingViewModel, TicketBooking>(ticketBookingViewModel);                
                if(!ticketBookingBL.AddBookingDetails(ticketBooking))
                {
                    return RedirectToAction("BookTicket");
                }
                TempData["BookingId"] = ticketBooking.BookingId;
                return RedirectToAction("AddPassenger", "TicketBooking");
            }
            return RedirectToAction("BookTicket");
        }
    }
}