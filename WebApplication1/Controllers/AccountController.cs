using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{


    public class AccountController : Controller
    {
        // GET: Account

        public ActionResult List()
        {
            var table = (new Database1Entities()).t會員.Select(acc => acc);
            var list = table.ToList();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(t會員 acc)
        {
            using (var db = new Database1Entities())
            {
                db.t會員.Add(acc);
                db.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int fUID)
        {
            var db = new Database1Entities();
            var acc = db.t會員.FirstOrDefault(a => a.fUID == fUID);
            
            return View(acc);
        }

        [HttpPost]
        public ActionResult Edit(t會員 modify)
        {
            var db = new Database1Entities();
            var acc = db.t會員.FirstOrDefault(a => a.fUID == modify.fUID);

            if (acc != null)
            {
                acc.f姓名 = modify.f姓名;
                acc.f暱稱 = modify.f暱稱;
                acc.f電話 = modify.f電話;
                acc.f生日 = modify.f生日;

                acc.f詳細地址 = modify.f詳細地址;
                acc.f居住縣市 = modify.f居住縣市; // 暫無
                acc.f電話 = modify.f電話;
                acc.f會員照片 = modify.f會員照片;
                acc.f點數 = modify.f點數; // 不顯示
                acc.f權限 = modify.f權限; // 不顯示
                db.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int fUID)
        {
            
            var db = new Database1Entities();
            var acc = db.t會員.FirstOrDefault(a => a.fUID == fUID);
            if (acc != null)
            {
                db.t會員.Remove(acc);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}