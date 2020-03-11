using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingApp.DAL;
using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class TrainDetailsController : Controller
    {
        // GET: Admin
        private TrainTicketBookingDbContext db = new TrainTicketBookingDbContext();
        TrainDetailsRepository trainDetailsRepository = new TrainDetailsRepository();
        public ActionResult DisplayTrainDetails()
        {
            IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.TrainClass = new SelectList(TrainClassRepository.GetClassDetails(), "ClassId", "ClassName");
            return View();           
        }
        [HttpPost]
        public ActionResult Create(TrainDetailsViewModel trainDetailsViewModel)
        {
            if(ModelState.IsValid)
            {
                TrainDetails trainDetails = AutoMapper.Mapper.Map<TrainDetailsViewModel, TrainDetails>(trainDetailsViewModel);
                trainDetails.TrainClassDetails = new List<TrainClassDetails>();
                foreach(int detail in trainDetailsViewModel.TrainClass)
                {
                    TrainClassDetails trainClassDetails = new TrainClassDetails();
                    trainClassDetails.ClassId = detail;
                    trainDetails.TrainClassDetails.Add(trainClassDetails);
                }
                trainDetailsRepository.AddTrainDetails(trainDetails);
                TempData["Message"] = "Added Successfully!!!";
                return RedirectToAction("Index");
            }
            ViewBag.TrainClass = new SelectList(TrainClassRepository.GetClassDetails(), "ClassId", "ClassName");
            return View(trainDetailsViewModel);
        }
    }
}