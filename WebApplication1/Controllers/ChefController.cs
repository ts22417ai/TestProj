using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels.Account;

namespace WebApplication1.Controllers
{
    public class ChefController : Controller
    {
        // GET: Chef
        Database1Entities db = new Database1Entities();
        public ActionResult List()
        {
            var table = (new Database1Entities()).t私廚.Select(c => c);
            var list = table.ToList();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int fUID)
        {
            var c = new t私廚
            {
                fUID = fUID
            };
            return View(c);
        }

        [HttpPost]
        public ActionResult Create(t私廚 c)
        {
            using (var db = new Database1Entities())
            {
                db.t私廚.Add(c);
                db.SaveChanges();
            }

            var acc = db.t會員.FirstOrDefault(a => a.fUID == c.fUID);
            if (acc != null)
            {
                acc.f權限 = 2; // 不顯示
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Account", new { fUID =c.fUID});
        }

        public ActionResult Edit(int fCID)
        {
            var db = new Database1Entities();
            var chef = db.t私廚.FirstOrDefault(c => c.fCID == fCID);

            return View(chef);
        }

        [HttpPost]
        public ActionResult Edit(t私廚 modify)
        {
            var db = new Database1Entities();
            var chef = db.t私廚.FirstOrDefault(c => c.fCID == modify.fCID);

            if (chef != null)
            {
                chef.fCID = modify.fCID; // 
                chef.fUID = modify.fUID; //
                chef.f私廚簡介 = modify.f私廚簡介;
                chef.f服務地區 = modify.f服務地區;

                db.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(t私廚 cc)
        {
            
            var acc = db.t會員.FirstOrDefault(a => a.fUID == cc.fUID);
            if (acc != null)
            {
                acc.f權限 = 0; // 不顯示
                db.SaveChanges();
            }


            var chef = db.t私廚.FirstOrDefault(c => c.fCID == cc.fCID);
            if (chef != null)
            {
                db.t私廚.Remove(chef);
                db.SaveChanges();
            }



            return RedirectToAction("List");
        }
    }
}