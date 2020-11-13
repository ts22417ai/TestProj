using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult List(int fCid)
        {

            var table = from t in (new Database1Entities()).t私廚可預訂時間
                        where t.fCID == fCid
                        select t;
                        
            List<t私廚可預訂時間> list = new List<t私廚可預訂時間>();
            foreach (t私廚可預訂時間 t in table)
            {
                list.Add(t);
            }
            return View(list);
        }
        
        public ActionResult Create(int fCid)
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(t私廚可預訂時間 t)
        {

            return View();
        }

    }
}