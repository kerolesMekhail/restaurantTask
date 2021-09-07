using Restaurant.Abstract.IUser;
using Restaurant.Business;
using Restaurant.Business.User;
using Restaurant.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController()
        {
            _user =new UserService();
        }
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(userVM userVM)
        {
            ViewBag.NameFound = null;
            var Result = _user.CreateUser(userVM);
            if(Result !=null )
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.MassageName = "error";
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.NameFound = "error";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userNameOrEmail, string password)
        {
            try
            {
                ViewBag.NameFound = null;
                var res = _user.Login(userNameOrEmail, password);
                if(res != null)
                {
                    Session["customerId"] = res.id;
                    if(res.typeOfUser=="Employee")
                    {
                        return RedirectToAction("Orders", "Employee");
                    }
                    return RedirectToAction("GetProducts", "Product");
                }
                ViewBag.NameFound = "error";
                return View();

            }
            catch
            {
                ViewBag.NameFound = "error";
                return View();
            }
        }
    }
}