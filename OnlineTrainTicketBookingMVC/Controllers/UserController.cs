using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingMVC.Models;
using System;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserBL userBL;
        public UserController()
        {
            userBL = new UserBL();
        }
       
        public ActionResult ViewProfile()       //Allow user to view their profile
        {
            //int id = (int)TempData["Message"];            
            User user = userBL.GetUserById(Convert.ToInt32(Session["UserId"]));
            UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
            return View(userViewModel);
        }
        public ActionResult EditProfile()           //Allow users to edit or update their profiles
        {
            User user = userBL.GetUserById(Convert.ToInt32(Session["UserId"]));
            UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
           
            return View(userViewModel);
        }
        [HttpPost]
        public ActionResult EditProfile([Bind(Exclude = "ConfirmPassword")]UserViewModel userViewModel)
        {
            userViewModel.ConfirmPassword = userViewModel.Password;
            //if (ModelState.IsValid)
            {
                User user = AutoMapper.Mapper.Map<UserViewModel, User>(userViewModel);  //Automapper to map details from the view model to entity
                bool result = userBL.UpdateProfile(user);
                if (!result)
                    return View();
                //TempData["Message"] = userViewModel.UserId;
                return RedirectToAction("ViewProfile", "User");
            }
            //TempData["Message"] = userViewModel.UserId;
            //return View();
        }
        public ActionResult ChangePassword()            //allow users to change their password
        {
            User user = userBL.GetUserById(Convert.ToInt32(Session["UserId"]));
            UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
            return View(userViewModel);
        }
        [HttpPost]
        public ActionResult ChangePassword(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = AutoMapper.Mapper.Map<UserViewModel, User>(userViewModel);  //Automapper to map details from the view model to entity
                bool result = userBL.UpdateProfile(user);
                if (!result)
                    return View();
                ViewBag.Msg = "Reset Succeeded!!!";
            }
            return View();
                 
        }
    }
}