using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBANHANG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ĐÂY LÀ ĐOẠN CHUNG CHO HOME VÀ ABOUT ";
            ViewData["abc"] = "Xin chao tu controller";
            ViewData["Question"] = "Ban da biet cach lam chua";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}