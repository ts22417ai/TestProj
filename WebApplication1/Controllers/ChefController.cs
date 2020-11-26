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
            if (Session["Member"] == null)
            {
                return View("Create", "_LayoutPage1");
            }
            //會員登入狀態
            return View("Create");
        }

        [HttpGet]
        public ActionResult Create(int fUID)
        {
            fUID = (Session["Member"] as t會員).fUID;
            var c = new t私廚
            {
                fUID = fUID
            };
            return View(c);
        }

        [HttpPost]
        public ActionResult Create(t私廚 c)
        {
            if (ModelState.IsValid)
                {
                    db.t私廚.Add(c);
                    db.SaveChanges();

                int fUId = (Session["Member"] as t會員).fUID;
                var acc = db.t會員.FirstOrDefault(m => m.fUID == fUId);
                if (acc != null)
                    {
                        acc.f權限 = 2; // 不顯示
                        db.SaveChanges();
                    }

                var chef = db.t私廚.Where(m => m.fUID == c.fUID).FirstOrDefault();
                Session["Chef"] = chef;

                return RedirectToAction("Details", "Account"); 
            }
                else { 
                return View();
                }
        }

        public ActionResult Edit()
        {
            int fCId = (Session["Chef"] as t私廚).fCID;
            var chef = db.t私廚.FirstOrDefault(c => c.fCID == fCId);

            return View("Edit", chef);
        }

        [HttpPost]
        public ActionResult Edit(t私廚 modify)
        {
            int fCId = (Session["Chef"] as t私廚).fCID;
            var chef = db.t私廚.FirstOrDefault(c => c.fCID == modify.fCID);

            if (chef != null)
            {
                if (ModelState.IsValid)
                {
                    chef.f私廚簡介 = modify.f私廚簡介;
                    chef.f服務地區 = modify.f服務地區;

                    db.SaveChanges();
                }
                else
                {
                    return View();
                }
            }

            return RedirectToAction("Details", "Account");
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