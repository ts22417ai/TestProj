using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private Database1Entities db = new Database1Entities();

        public ActionResult buyPoint()
        {
            return View();
        }


        public ActionResult buyPointSuccess()
        {
            return View();
        }

        public ActionResult chefInfo()
        {
            return View();
        }

        public ActionResult clientInfo()
        {
            return View();
        }




        public ActionResult List()
        {
            var table = db.t訂單.Select(o => o);
            var list = table.ToList();

            return View(list);
        }

        public ActionResult Create()
        {

            var selectList = db.t訂單.Select(t => t).ToList();
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(t訂單 o)
        {
            
            db.t訂單.Add(o);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Edit(int fOID)
        {
            var order = db.t訂單.FirstOrDefault(o => o.fOID == fOID);

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(t訂單 modify)
        {
            var order = db.t訂單.FirstOrDefault(o => o.fOID == modify.fOID);

            if (order != null)
            {
                order.fPID = modify.fPID;
                order.fUID = modify.fUID;
                order.f評價日期 = modify.f評價日期;
                order.f數量 = modify.f數量;
                order.f狀態 = modify.f狀態;
                order.f總價 = modify.f總價;
                order.f訂購日期 = modify.f訂購日期;
                order.f評價內容 = modify.f評價內容;
                order.f評級 = modify.f評級;
                order.f預定日期 = modify.f預定日期;

                db.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int fOID)
        {
            var order = db.t訂單.FirstOrDefault(o => o.fOID == fOID);
            if (order != null)
            {
                db.t訂單.Remove(order);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}