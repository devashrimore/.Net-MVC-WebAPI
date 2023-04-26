using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment5_MVC.Models;

namespace Assignment5_MVC.Controllers
{
    public class HomeController : Controller
    {
        static List<User> users = new List<User>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetServerTime()

        {

            System.Threading.Thread.Sleep(5000);

            return PartialView();

        }
        public ActionResult GetAllUsers()

        {

            return PartialView(users);

        }
        public ActionResult CreateUser()

        {

            return View();

        }
        [HttpPost]

        public ActionResult CreateUser(User u)

        {

            users.Add(u);

            return RedirectToAction("GetAllUsers");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}