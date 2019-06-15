using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBll;
using IOC;
using Model;
using System.Data;
using BLL;
namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IUsersBll pp = IocCreate.CreateBLL<UsersBll>("Usersjiaomama", "Usersmama");
            List<users> list = pp.user();
            return View(list);
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