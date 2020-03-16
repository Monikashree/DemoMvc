using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        public ActionResult DisplayUser()
        {
            IEnumerable<User> userDetailsList = UserBL.GetUserDetails();
            List<UserViewModel> userViewModelList = new List<UserViewModel>();
            //IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();
            foreach (User user in userDetailsList)
            {
                UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
                userViewModelList.Add(userViewModel);
            }
            return View(userViewModelList);
            
        }
        public ActionResult Edit(int id)
        {
            User user = UserBL.GetUserById(id);
            UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = AutoMapper.Mapper.Map<UserViewModel, User>(userViewModel);
                UserBL.BlockUser(user);
                
                return RedirectToAction("DisplayUser", "Manageuser");
            }
            return View(userViewModel);
        }
    }
}