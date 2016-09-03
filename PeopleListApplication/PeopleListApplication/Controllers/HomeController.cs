using PeopleListApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleListApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CustomerBAL cust = new CustomerBAL();
            ViewBag.Customers = cust.Customers;
            return View();
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