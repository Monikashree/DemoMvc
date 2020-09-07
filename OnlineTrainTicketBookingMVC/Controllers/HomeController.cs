using OnlineTrainTicketBookingApp.BL;
using OnlineTrainTicketBookingMVC.App_Start;
using OnlineTrainTicketBookingMVC.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTrainTicketBookingMVC.Controllers
{
   // [CustomException]
    public class HomeController : Controller
    {
        // GET: Home
        
        IUserBL userBL;
        public HomeController()     //A constructor to create a reference to IUserBL
        {
           userBL = new UserBL();
        }
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
       
        public ActionResult SignUp_Get()
        {
            return View();
        }

        //[AllowAnonymous]
        [HttpPost]
        [ActionName("SignUp")]
        //[OutputCache(Duration = 60)]                                        //Output cache to help user if the signup fails again and again
        public ActionResult SignUp_Post(UserViewModel userViewModel)        // Action method for signup
        {
            //TryUpdateModel(user);
            //if (userViewModel.Age > 17 && userViewModel.Age < 100)
            //{
                if (ModelState.IsValid)
                {
                    //User user = new User
                    //{
                    //    FirstName = userViewModel.FirstName,              //Sign Up Controll
                    //    LastName = userViewModel.LastName,
                    //    Age = userViewModel.Age,
                    //    Sex = userViewModel.Sex,
                    //    Email = userViewModel.Email,
                    //    MobileNumber = userViewModel.MobileNumber,
                    //    Password = userViewModel.Password,
                    //    Role = "User"
                    //};
                    userViewModel.Role = Status.User;
                    userViewModel.IsActive = true;
                    User user = AutoMapper.Mapper.Map<UserViewModel, User>(userViewModel);  //Automapping
                    bool status = userBL.AddUserDetails(user);
                    if (status == false)
                        TempData["Message"] = "Please Try Again";
                    TempData["Message"] = "Registration Successfull..Plz Sign In to Continue";
                    return RedirectToAction("HomePage");
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
        public ActionResult SignIn_Get()    //User sign in
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
                //}                                                                 //Sign In Controll


                User user = userBL.SignIn(signInViewModel.UserName, signInViewModel.Password);
                if (user != null)
                {
                    if (user.IsActive == true)
                    {
                        FormsAuthentication.SetAuthCookie(user.FirstName, false);
                        var authTicket = new FormsAuthenticationTicket(1, user.FirstName, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        HttpContext.Response.Cookies.Add(authCookie);
                        Session["UserId"] = user.UserID.ToString();
                        if (user.Role.Equals("Admin"))                        
                            return RedirectToAction("Index", "TrainDetails");                         
                        //TempData["Message"] = user.UserID;                        
                        return RedirectToAction("ViewProfile", "User");
                    }
                }
                TempData["Message"] = "Incorrect Username or Password";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();             //Sign Out Controll
            Session.Abandon();
            return RedirectToAction("HomePage");
        }
    }
}