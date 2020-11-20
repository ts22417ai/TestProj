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
            ScheduleVM.fCid = fCid;
            ScheduleVM.ArrEnable = listenable;
            ScheduleVM.ArrUnable = listunable;

            return View(ScheduleVM);
        }

        [HttpPost]
        public ActionResult List(CScheduleViewModel VM)
        {
            //新增可預訂時間
            string sCreate = VM.ArrGetNewTime;
            if (!string.IsNullOrEmpty(sCreate))
            {
                string[] ArrSplit = sCreate.Split(',');
                Database1Entities dbCreate = new Database1Entities();

                foreach (string s1 in ArrSplit)
                {
                    if (!string.IsNullOrEmpty(s1))
                    {
                        string[] Arr = s1.Split('-');
                        t私廚可預訂時間 t = new t私廚可預訂時間();
                        t.fCID = VM.fCid;
                        t.f日期 = Convert.ToDateTime(Arr[0]);
                        t.f時段 = Convert.ToInt32(Arr[1]);
                        t.f狀態 = 1;
                        dbCreate.t私廚可預訂時間.Add(t);
                    }
                }

                dbCreate.SaveChanges();

            }

            //刪除不可預定時間
            string sDelete = VM.ArrGetDeletedTime;
            
            if (!string.IsNullOrEmpty(sDelete))
            {
                string[] ArrSplitDelete = sDelete.Split(',');
                Database1Entities dbDelete = new Database1Entities();
                foreach (string s in ArrSplitDelete)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        string[] Arr = s.Split('-');
                        DateTime time = Convert.ToDateTime(Arr[0]);
                        int status = Convert.ToInt32(Arr[1]);
                        var deleteTime = dbDelete.t私廚可預訂時間.FirstOrDefault(t => t.f日期 == time && t.f時段 == status);
                        if (deleteTime != null)
                        {
                            dbDelete.t私廚可預訂時間.Remove(deleteTime);

                        }
                    }
                }
                dbDelete.SaveChanges();

            }
            return RedirectToAction("List", new { fCid = VM.fCid });
        }
    }
}