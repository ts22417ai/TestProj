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
            using (var db = new Database1Entities())
            {
                db.t私廚可預訂時間.Add(t);
                db.SaveChanges();
            }
            return RedirectToAction("List", new { fCid = t.fCID });
        }

        public ActionResult Edit(int id)
        {
            var db = (new Database1Entities());
            var time = db.t私廚可預訂時間.FirstOrDefault(t => t.fTID == id);
            if(time == null)
            {
                return RedirectToAction("List");
            }
            return View(time);
        }
        [HttpPost]
        public ActionResult Edit(t私廚可預訂時間 modify)
        {
            var db = (new Database1Entities());
            var time = db.t私廚可預訂時間.FirstOrDefault(t => t.fTID == modify.fTID);
            if (time != null)
            {
                time.f日期 = modify.f日期;
                time.f晚餐 = modify.f晚餐;
                time.f午餐 = modify.f午餐;

                db.SaveChanges();
            }
            return RedirectToAction("List", new { fCid = time.fCID });
        }

        public ActionResult Delete(int fTid)
        {
            var db = (new Database1Entities());
            var time = db.t私廚可預訂時間.FirstOrDefault(t=> t.fTID == fTid);
            if(time != null)
            {
                db.t私廚可預訂時間.Remove(time);
                db.SaveChanges();
            }
            return RedirectToAction("List",new { fCid=time.fCID});
        }
    }
}