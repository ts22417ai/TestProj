using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels.Schedule;

namespace WebApplication1.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule

        public ActionResult List(int fCid)
        {

            var table = (from t in (new Database1Entities()).t私廚可預訂時間
                         where t.fCID == fCid
                         select t).ToList();

            var listunable = new List<string>();
            var listenable = new List<string>();

            listunable.AddRange(table.Where(t => t.f狀態 == 2)
                .Select(x => x.f日期.ToString("d") + "-" + x.f時段.ToString()).ToList()
                );

            listenable.AddRange(table.Where(t => t.f狀態 == 1)
                .Select(x => x.f日期.ToString("d") + "-" + x.f時段.ToString()).ToList()
                );


            CScheduleViewModel ScheduleVM = new CScheduleViewModel();
            ScheduleVM.ArrEnable = listenable;
            ScheduleVM.ArrUnable = listunable;

            return View(ScheduleVM);
        }



        public ActionResult Create(int fCid)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int FCID, CScheduleViewModel VM)
        {
            foreach (string s in VM.ArrGetNewTime)
            {
                string[] Arr = s.Split('-');
                t私廚可預訂時間 t = new t私廚可預訂時間();
                t.fCID = FCID;
                t.f日期 = Convert.ToDateTime(Arr[0]);
                t.f時段 = Convert.ToInt32(Arr[1]);
                t.f狀態 = 1;

                Database1Entities db = new Database1Entities();
                db.t私廚可預訂時間.Add(t);
                db.SaveChanges();
            }

            return RedirectToAction("List", new { fCid = FCID });
        }



        public ActionResult Delete(int FCID, CScheduleViewModel VM)
        {
            foreach (string s in VM.ArrGetDeletedTime)
            {
                string[] Arr = s.Split('-');

                Database1Entities db = new Database1Entities();
                var deleteTime = db.t私廚可預訂時間.FirstOrDefault(t => t.f日期 == Convert.ToDateTime(Arr[0]) && t.f時段 == Convert.ToInt32(Arr[0]));
                if (deleteTime != null)
                {
                    db.t私廚可預訂時間.Remove(deleteTime);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List", new { fCid = FCID });
        }
    }
}