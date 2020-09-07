using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        IUserBL userBL;
        public ManageUserController()   //Invoke user BL
        {
            userBL = new UserBL();
        }
        public ActionResult BlockedUser()   //Allow admin to block user
        {
            IEnumerable<User> blockedUserList = userBL.GetBlockedUserDetails();
            List<UserViewModel> userViewModelList = new List<UserViewModel>();
            //IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();
            foreach (User user in blockedUserList)                                  //Displaying User Details
            {
                UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
                userViewModelList.Add(userViewModel);
            }
            return View("DisplayUser",userViewModelList);
        }
        public ActionResult DisplayUser()   //Display User
        {
            IEnumerable<User> userDetailsList = userBL.GetUserDetails();
            List<UserViewModel> userViewModelList = new List<UserViewModel>();
            //IEnumerable<TrainDetails> trainList = TrainDetailsBL.GetTrainDetails();
            foreach (User user in userDetailsList)                                  //Displaying User Details
            {
                UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
                userViewModelList.Add(userViewModel);
            }
            return View(userViewModelList);
            
        }
        public ActionResult Edit(int id)
        {
            User user = userBL.GetUserById(id);                                     //Editing User Details
            UserViewModel userViewModel = AutoMapper.Mapper.Map<User, UserViewModel>(user);
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            //if (ModelState.IsValid)
            {                                                                        
                User user = AutoMapper.Mapper.Map<UserViewModel, User>(userViewModel);  //Automapper to map details from the view model to entity
                userBL.BlockUser(user);
                
                return RedirectToAction("DisplayUser", "Manageuser");
            }
            //return View(userViewModel);
        }
    }
}