using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.SearchResult;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {           
            CSearchResult R = new CSearchResult();
            R.f價格 = 12;
            R.f服務種類 = "私廚到家";
            R.f私廚姓名 = "林子捷";
            return Json(R, JsonRequestBehavior.AllowGet);
        }

    }
}