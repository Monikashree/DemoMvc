using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class FindTrainController : Controller
    {
        // GET: FindTrain
        TrainDetailsBL trainDetailsBL;
        TicketBookingBL ticketBookingBL;
        TrainClassDetailsViewModel trainClassDetailsViewModel;
        public FindTrainController()
        {
            trainDetailsBL = new TrainDetailsBL();
            ticketBookingBL = new TicketBookingBL();
        }
        public ActionResult SearchTrain()           //just for search of train on a whole no need now and not in usage
        {
            var data = trainDetailsBL.GetTrainDetails();
            ViewBag.result = data;
            return View();
            //IEnumerable<TrainDetails> trainDetailsList = trainDetailsBL.GetTrainDetails();
            //List<TrainDetailsViewModel> trainDetailsViewModelList = new List<TrainDetailsViewModel>();
            ////IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();       //Displaying Train Details
            //foreach (TrainDetails train in trainDetailsList)
            //{
            //    TrainDetailsViewModel trainDetailsViewModel = AutoMapper.Mapper.Map<TrainDetails, TrainDetailsViewModel>(train);
            //    trainDetailsViewModelList.Add(trainDetailsViewModel);
            //}
            //return View(trainDetailsViewModelList);
        }

        public ActionResult FindTrainByStation()
        {
            return View();
        }


        public ActionResult DisplayTrainDetails(SearchTrainViewModel searchTrainViewModel)
        {
            TempData["JourneyDate"] = searchTrainViewModel.JourneyDate;
            List<TrainDetails> trainDetailsList = trainDetailsBL.SearchTrain(searchTrainViewModel.Source, searchTrainViewModel.Destination);
            List<TrainDetailsViewModel> trainDetailsViewModelList = new List<TrainDetailsViewModel>();
            //IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();       //Displaying Train Details
            foreach (TrainDetails train in trainDetailsList)
            {
                TrainDetailsViewModel trainDetailsViewModel = AutoMapper.Mapper.Map<TrainDetails, TrainDetailsViewModel>(train);
                trainDetailsViewModelList.Add(trainDetailsViewModel);
            }
            return View(trainDetailsViewModelList);
        }

        public ActionResult ViewAvailability(int id)
        {
            List<TicketBooking> ticketBooking = ticketBookingBL.GetBookingDetailsByIdandDOJ(id, (System.DateTime)TempData["JourneyDate"]);

            List<TrainClassDetails> train = trainDetailsBL.GetSeatDetailsById(id);
            List<TrainClassDetailsViewModel> trainClassDetailsViewModelList = new List<TrainClassDetailsViewModel>();
            //IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();       //Displaying Train Details
            if (ticketBooking.Count == 0)
            {
                foreach (TrainClassDetails trains in train)
                {

                    trainClassDetailsViewModel = AutoMapper.Mapper.Map<TrainClassDetails, TrainClassDetailsViewModel>(trains);
                    trainClassDetailsViewModel.AvailableSeats = trains.Seats;

                    trainClassDetailsViewModelList.Add(trainClassDetailsViewModel);
                }
            }
            else
            {

                foreach (TrainClassDetails trains in train)
                {
                    trainClassDetailsViewModel = AutoMapper.Mapper.Map<TrainClassDetails, TrainClassDetailsViewModel>(trains);
                    foreach (TicketBooking details in ticketBooking)
                    {
                        if (details.ClassId == trains.ClassId)
                        {
                            int count = ticketBookingBL.GetPassengerCountByID(details.BookingId);
                            if (count != 0)
                                trainClassDetailsViewModel.AvailableSeats = trains.Seats - count;
                            break;
                        }
                        else
                            trainClassDetailsViewModel.AvailableSeats = trains.Seats;
                        

                    }
                    
                   
                    trainClassDetailsViewModelList.Add(trainClassDetailsViewModel);
                }
            }
            return View(trainClassDetailsViewModelList);
        }

        [HttpPost]
        public ActionResult ViewAvailability(TrainClassDetails trainClassDetails)
        {
            TempData["TrainId"] = trainClassDetails.TrainId;
            return RedirectToAction("BookTrain", "Booking");
        }

    }
}