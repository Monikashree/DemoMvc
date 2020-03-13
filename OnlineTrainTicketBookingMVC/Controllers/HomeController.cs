using OnlineTrainTicketBookingApp.Entity;
using OnlineTrainTicketBookingMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineTrainTicketBookingMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        UserRepository userRepository = new UserRepository();
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult Index()
        {
            //List<User> user = UserRepository.ShowDetails();
            //List<User> userList = UserRepository.GetUserDetails();
            //List<UserViewModel> userViewList = new List<UserViewModel>();
            //foreach (User userData in userList)
            //{
            //    UserViewModel userView = new UserViewModel
            //    {                    
            //        FirstName = userData.FirstName,
            //        LastName = userData.LastName,
            //        Age = userData.Age,
            //        Sex = userData.Sex,
            //        Email = userData.Email,
            //        MobileNumber = userData.MobileNumber,
            //        Password = userData.Password,                   
            //        Role = userData.Role
            //        //Status = (OnlineTrainTicketBooking.Role)Enum.Parse(typeof(OnlineTrainTicketBooking.Role), "User", true)
            //    };
            //    userViewList.Add(userView);
            //}  
            //return View(userViewList);
            return View();
        }

        [HttpGet]
        [ActionName("SignUp")]
        [OutputCache(Duration = 60)]
        public ActionResult SignUp_Get()
        {
            return View();
        }

        //[AllowAnonymous]
        [HttpPost]
        [ActionName("SignUp")]                                          /*Code for binding*///public ActionResult SignUp_Post([Bind(/*Include*/Exclude  = "FirstName, Age, Sex, Email, MobileNum, Password")]User user)
        public ActionResult SignUp_Post(UserViewModel userViewModel)
        {
            //TryUpdateModel(user);
            //if (userViewModel.Age > 17 && userViewModel.Age < 100)
            //{
                if (ModelState.IsValid)
                {
                    //User user = new User
                    //{
                    //    FirstName = userViewModel.FirstName,
                    //    LastName = userViewModel.LastName,
                    //    Age = userViewModel.Age,
                    //    Sex = userViewModel.Sex,
                    //    Email = userViewModel.Email,
                    //    MobileNumber = userViewModel.MobileNumber,
                    //    Password = userViewModel.Password,
                    //    Role = "User"
                    //};
                    userViewModel.Role = Status.User;
                    User user = AutoMapper.Mapper.Map<UserViewModel, User>(userViewModel);  //Automapping
                    bool status = UserBL.AddUserDetails(user);
                    if (status == false)
                        TempData["Message"] = "Please Try Again";
                    TempData["Message"] = "Registration Successfull";
                    return RedirectToAction("Index");
                }
                return View();
            //}
            //else
            //{
            //    TempData["Message"] = "Age is invalid";
            //    return View();
            //}

        }
        [HttpGet]
        [ActionName("SignIn")]
        public ActionResult SignIn_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("SignIn")]
        public ActionResult SignIn_Post(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                //List<User> userDetails = RailwayBL.GetUserDetails();
                //foreach (var value in userDetails)
                //{
                //    if (value.FirstName.Equals(signInViewModel.UserName) && value.Password.Equals(signInViewModel.Password))
                //    {
                //        if (value.Role.Equals("Admin"))
                //            return RedirectToAction("Index", "TrainDetails");
                //        return RedirectToAction("Index", "User");
                //    }
                //}
                User user = UserBL.SignIn(signInViewModel.UserName, signInViewModel.Password);
                if (user != null)
                {
                    if (user.Role.Equals("Admin"))
                        return RedirectToAction("Index", "TrainDetails");
                    return RedirectToAction("Index", "User");
                }
                TempData["Message"] = "Incorrect Username or Password";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}