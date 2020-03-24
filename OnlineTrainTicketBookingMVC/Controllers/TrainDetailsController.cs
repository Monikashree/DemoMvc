using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class TrainDetailsController : Controller
    {
        // GET: Admin
        // private TrainTicketBookingDbContext db = new TrainTicketBookingDbContext();
        //TrainDetailsRepository trainDetailsRepository = new TrainDetailsRepository();
        ITrainDetailsBL trainDetailsBL;
        public TrainDetailsController()
        {
            trainDetailsBL = new TrainDetailsBL();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayTrainDetails()
        {
            IEnumerable<TrainDetails> trainDetailsList = trainDetailsBL.GetTrainDetails();
            List<TrainDetailsViewModel> trainDetailsViewModelList = new List<TrainDetailsViewModel>();
            //IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();       //Displaying Train Details
            foreach(TrainDetails train in trainDetailsList)
            {
                TrainDetailsViewModel trainDetailsViewModel = AutoMapper.Mapper.Map<TrainDetails, TrainDetailsViewModel>(train);
                trainDetailsViewModelList.Add(trainDetailsViewModel);
            }
            return View(trainDetailsViewModelList);
        }
        public ActionResult Create()
        {
            //ViewBag.TrainClass = new SelectList(TrainClassRepository.GetClassDetails(), "ClassId", "ClassName");
            return View();           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrainDetailsViewModel trainDetailsViewModel)
        {
            if(ModelState.IsValid)
            {
                TrainDetails trainDetails = AutoMapper.Mapper.Map<TrainDetailsViewModel, TrainDetails>(trainDetailsViewModel);
                //trainDetails.TrainClassDetails = new List<TrainClassDetails>();
                //foreach(int detail in trainDetailsViewModel.TrainClass)
                //{
                //    TrainClassDetails trainClassDetails = new TrainClassDetails();
                //    trainClassDetails.ClassId = detail;
                //    trainDetails.TrainClassDetails.Add(trainClassDetails);
                //}
                trainDetailsBL.AddTrainDetails(trainDetails);                       //Creating Train Details
                TempData["TrainId"] = trainDetails.TrainId;
                return RedirectToAction("AddTrainClass", "TrainClass");
                //TempData["Message"] = "Added Successfully!!!";
                //return RedirectToAction("Index");
            }
            //ViewBag.TrainClass = new SelectList(TrainClassRepository.GetClassDetails(), "ClassId", "ClassName");
            return View(trainDetailsViewModel);
        }


        public ActionResult EditTrainDetails(int trainId)       //Editing Train details
        {
            TrainDetails trainDetails = trainDetailsBL.GetTrainByNo(trainId);
            TrainDetailsViewModel trainDetailsViewModel = AutoMapper.Mapper.Map<TrainDetails, TrainDetailsViewModel>(trainDetails);
            return View(trainDetailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTrainDetails( TrainDetailsViewModel trainDetailsViewModel)  //Post method for editing train details
        {
            if (ModelState.IsValid)
            {
                TrainDetails trainDetails = AutoMapper.Mapper.Map<TrainDetailsViewModel, TrainDetails>(trainDetailsViewModel);
                trainDetailsBL.UpdateTrainDetails(trainDetails);
                TempData["TrainId"] = trainDetails.TrainId;
                return RedirectToAction("DisplayTrainCategories", "TrainClass");
            }
            return View(trainDetailsViewModel);
        }
        public ActionResult DeleteTrainDetails(int TrainId)         //Deleting train details by Id
        {
            trainDetailsBL.DeleteTrainDetails(TrainId);
            return RedirectToAction("DisplayTrainDetails", "TrainDetails");
        }
    }
}