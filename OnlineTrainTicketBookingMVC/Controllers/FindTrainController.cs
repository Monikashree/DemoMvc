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
        public  FindTrainController()
        {
            trainDetailsBL = new TrainDetailsBL();
        }
        public ActionResult SearchTrain()
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
            List<TrainClassDetails> train = trainDetailsBL.GetSeatDetailsById(id);
            List<TrainClassDetailsViewModel> trainClassDetailsViewModelList = new List<TrainClassDetailsViewModel>();
            //IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();       //Displaying Train Details
            foreach (TrainClassDetails trains in train)
            {
                TrainClassDetailsViewModel trainClassDetailsViewModel = AutoMapper.Mapper.Map<TrainClassDetails, TrainClassDetailsViewModel>(trains);
                trainClassDetailsViewModelList.Add(trainClassDetailsViewModel);
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