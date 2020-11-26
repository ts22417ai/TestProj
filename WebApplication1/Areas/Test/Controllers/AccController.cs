using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Test.Controllers
{
    public class AccController : Controller
    {
        // GET: Test/Home


        private Database1Entities db = new Database1Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult 登入()
        {
            return View();
        }

        public ActionResult logout()
        {
            Session.Clear();  //清除Session變數資料
            return RedirectToAction("Index");
        }

        public ActionResult register()
        {
            return View();
        }

        public ActionResult registersuccess()
        {
            return View();
        }
        

    }
}