using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class TrainClassController : Controller
    {
        // GET: TrainClass
        public ActionResult Index()
        {
            return View();
        }   
        public ActionResult DisplayTrainCategories()
        {
            List<TrainClassDetails> trainClassList = TrainClassBL.GetTrainClass(Convert.ToInt32(TempData["TrainNo"]));
            List<TrainClassDetailsViewModel> trainClassDetailsViewModelList = new List<TrainClassDetailsViewModel>();
            foreach (TrainClassDetails classes in trainClassList)
            {
                TrainClassDetailsViewModel trainClassDetailsViewModel = AutoMapper.Mapper.Map<TrainClassDetails, TrainClassDetailsViewModel>(classes);
                trainClassDetailsViewModelList.Add(trainClassDetailsViewModel);
            }
            return View(trainClassDetailsViewModelList);
        }
        public ActionResult AddTrainClass()
        {
            TrainClassDetailsViewModel trainClassDetailsViewModel = new TrainClassDetailsViewModel();
            trainClassDetailsViewModel.TrainNo= Convert.ToInt32(TempData["TrainNo"]);
            List<TrainClass> trainClassList = TrainClassBL.GetTrainClassList();
            List<SelectListItem> classList = new List<SelectListItem>();
            foreach (TrainClass trainClass in trainClassList)
            {
                classList.Add(new SelectListItem { Text = @trainClass.ClassName, Value = @trainClass.ClassId.ToString() });
            }
            ViewBag.classes = classList;
            return View(trainClassDetailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTrainClass(TrainClassDetailsViewModel trainClassDetailsViewModel)
        {
            List<TrainClass> trainClassList = TrainClassBL.GetTrainClassList();
            List<SelectListItem> classList = new List<SelectListItem>();
            foreach (TrainClass trainClass in trainClassList)
            {
                classList.Add(new SelectListItem { Text = @trainClass.ClassName, Value = @trainClass.ClassId.ToString() });
            }
            ViewBag.classes = classList;
            if (ModelState.IsValid)
            {
                TrainClassDetails trainClassDetails = AutoMapper.Mapper.Map<TrainClassDetailsViewModel, TrainClassDetails>(trainClassDetailsViewModel);
                TrainClassBL.AddTrainClass(trainClassDetails);
                TempData["TrainNo"] = trainClassDetails.TrainNo;
                return RedirectToAction("DisplayTrainCategories");
            }
            return View();
        }
        public ActionResult EditTrainClass(int id)
        {
            TrainClassDetails trainClassDetails = TrainClassBL.GetClass(id);
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
                TrainClassBL.EditTrainClass(trainClassDetails);
                TempData["TrainNo"] = trainClassDetails.TrainNo;
                return RedirectToAction("DisplayTrainCategories");
            }
            return View();
        }
        public ActionResult DeleteTrainClass(int id)
        {
            TrainClassDetails trainClassDetails = TrainClassBL.GetClass(id);
            TrainClassBL.DeleteTrainClass(trainClassDetails);
            return RedirectToAction("DisplayTrainCategories", trainClassDetails.TrainNo);
        }

    }
}