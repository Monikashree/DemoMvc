using OnlineTrainTicketBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        UserRepository userRepository = new UserRepository() ;
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult Index()
        {
            IEnumerable<User> user = UserRepository.ShowDetails();
            ViewBag.details = user;
            ViewData["details"] = user;
            TempData["details"] = user;
            return View();
        }
        [HttpGet]
        [ActionName("SignUp")]
        public ActionResult SignUp_Get()
        {            
            return View();
        }
        [HttpPost]
        [ActionName("SignUp")]  /*Code for binding*/
                                //public ActionResult SignUp_Post([Bind(/*Include*/Exclude  = "FirstName, Age, Sex, Email, MobileNum, Password")]User user)
        public ActionResult SignUp_Post()
        {
            User user = new User();
            TryUpdateModel(user);
            IEnumerable<User> userList = UserRepository.Database();
            if (ModelState.IsValid)
            {
                userRepository.AddUserDetails(user);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
    }
}