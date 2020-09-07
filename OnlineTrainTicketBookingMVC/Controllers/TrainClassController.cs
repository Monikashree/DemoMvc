using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class TrainClassController : Controller
    {
        // GET: TrainClass
        ITrainClassBL trainClassBL;
        public TrainClassController()       //Constructor to invoke train class BL
        {
            trainClassBL = new TrainClassBL();
        }
        public ActionResult Index()
        {
            return View();
        }   
        public ActionResult AddClass()  //Adding classes
        {
            return View();
        }
        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult AddClass([Bind(Exclude = "TrainClassDetails,ClassId")]TrainClassViewModel trainClassViewModel)
        {
            if(ModelState.IsValid)
            {
                TrainClass trainClass = AutoMapper.Mapper.Map<TrainClassViewModel, TrainClass>(trainClassViewModel);
                bool result = trainClassBL.AddClass(trainClass);
                if(!result)
                {
                    TempData["Message"] = "Please Try Again";
                    return View();
                }
                TempData["Message"] = "Added Successfully!!!";
                return RedirectToAction("DisplayClass");
            }
            return View();
        }
        public ActionResult DisplayClass()
        {
            IEnumerable<TrainClass> trainClassList = trainClassBL.GetTrainClassList();
            List<TrainClassViewModel> trainClassViewModelList = new List<TrainClassViewModel>();
            //IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();       //Displaying Train Details
            foreach (TrainClass classes in trainClassList)
            {
                TrainClassViewModel trainClassViewModel = AutoMapper.Mapper.Map<TrainClass, TrainClassViewModel>(classes);
                trainClassViewModelList.Add(trainClassViewModel);
            }
            return View(trainClassViewModelList);          
        }
        public ActionResult DisplayTrainCategories()
        {
            List<TrainClassDetails> trainClassList = trainClassBL.GetTrainClass(Convert.ToInt32(TempData["TrainId"]));  
            List<TrainClassDetailsViewModel> trainClassDetailsViewModelList = new List<TrainClassDetailsViewModel>();
            foreach (TrainClassDetails classes in trainClassList)
            {                                                                           //Display Train Class Details
                TrainClassDetailsViewModel trainClassDetailsViewModel = AutoMapper.Mapper.Map<TrainClassDetails, TrainClassDetailsViewModel>(classes);
                trainClassDetailsViewModelList.Add(trainClassDetailsViewModel);
            }
            return View(trainClassDetailsViewModelList);
        }
        public ActionResult AddTrainClass()
        {
            TrainClassDetailsViewModel trainClassDetailsViewModel = new TrainClassDetailsViewModel();
            trainClassDetailsViewModel.TrainId= Convert.ToInt32(TempData["TrainId"]);
            List<TrainClass> trainClassList = trainClassBL.GetTrainClassList();
            List<SelectListItem> classList = new List<SelectListItem>();
            foreach (TrainClass trainClass in trainClassList)
            {                                                                           //Adding Train Details
                classList.Add(new SelectListItem { Text = @trainClass.ClassName, Value = @trainClass.ClassId.ToString() });
            }
            ViewBag.classes = classList;
            return View(trainClassDetailsViewModel);
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]                                          //Antiforgery key token to prevent CSRF attack
        public ActionResult AddTrainClass(TrainClassDetailsViewModel trainClassDetailsViewModel)
        {
            List<TrainClass> trainClassList = trainClassBL.GetTrainClassList();
            List<SelectListItem> classList = new List<SelectListItem>();
            foreach (TrainClass trainClass in trainClassList)       //Using view bag to get train class
            {
                classList.Add(new SelectListItem { Text = @trainClass.ClassName, Value = @trainClass.ClassId.ToString() });
            }
            ViewBag.classes = classList;
            if (ModelState.IsValid)
            {
                TrainClassDetails trainClassDetails = AutoMapper.Mapper.Map<TrainClassDetailsViewModel, TrainClassDetails>(trainClassDetailsViewModel);
                trainClassBL.AddTrainClass(trainClassDetails);
                TempData["TrainId"] = trainClassDetails.TrainId;
                return RedirectToAction("DisplayTrainCategories");
            }
            return View();
        }
        public ActionResult EditTrainClass(int id)
        {                                                                                       
            TrainClassDetails trainClassDetails = trainClassBL.GetClass(id);        //Editing Train Class Detail
            TrainClassDetailsViewModel trainClassDetailsViewModel = AutoMapper.Mapper.Map<TrainClassDetails, TrainClassDetailsViewModel>(trainClassDetails);
            return View(trainClassDetailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTrainClass(TrainClassDetailsViewModel trainClassdetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                TrainClassDetails trainClassDetails = AutoMapper.Mapper.Map<TrainClassDetailsViewModel, TrainClassDetails>(trainClassdetailsViewModel);
                trainClassBL.EditTrainClass(trainClassDetails);
                TempData["TrainId"] = trainClassDetails.TrainId;
                return RedirectToAction("DisplayTrainCategories");
            }
            return View();
        }
        public ActionResult DeleteTrainClass(int id)
        {                                                                           //Delete Train Detail
            TrainClassDetails trainClassDetails = trainClassBL.GetClass(id);
            trainClassBL.DeleteTrainClass(trainClassDetails);
            return RedirectToAction("DisplayTrainCategories", trainClassDetails.TrainId);
        }

    }
}   