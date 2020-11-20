using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewModels.Account;

namespace WebApplication1.Controllers
{


    public class AccountController : Controller
    {
        // GET: Account

        /*
         List Create Edit Delete
         Edit -> Chef
             */

        private Database1Entities db = new Database1Entities();

        public ActionResult List()
        {
            var table = db.t會員.Select(acc => acc);
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
            db.t會員.Add(acc);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int fUID)
        {
            var acc = db.t會員.FirstOrDefault(a => a.fUID == fUID);

            return View(acc);
        }

        [HttpPost]
        public ActionResult Edit(t會員 modify)
        {
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

            var acc = db.t會員.FirstOrDefault(a => a.fUID == fUID);
            if (acc != null)
            {
                db.t會員.Remove(acc);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }








        public ActionResult login()
        {
            return View(); //登入
        }

        public ActionResult Register()
        {
            return View(); //註冊
        }
        [HttpPost]
        public ActionResult Register(簡易註冊vm vm)
        {
            var acc = db.t會員.FirstOrDefault(m => m.f帳號 == vm.f帳號);
            if (acc != null)
            {
                @ViewBag.Msgaccount = "帳號已存在";

            }
            else
            {
                if (ModelState.IsValid) //判斷前端資料驗證ok後 才能儲存回首頁
                {
                    t會員 member = new t會員();
                    member.f帳號 = vm.f帳號;
                    member.f密碼 = vm.f密碼;
                    member.f電子郵件 = vm.f電子郵件;
                    db.t會員.Add(member);
                    db.SaveChanges();

                    return RedirectToAction("registersuccess", "Account");//註冊成功跳至成功畫面

                }
                return View();//資料驗證失敗 重整並顯示錯誤訊息
            }
            return View();//資料驗證失敗 重整並顯示錯誤訊息
        }


        public ActionResult registersuccess()
        {
            return View();//註冊成功的畫面+回去登入畫面
        }



        public ActionResult Details(int fUID)
        {

            var acc = db.t會員.FirstOrDefault(m => m.fUID == fUID);
            if (acc == null)
                return RedirectToAction("list");

            var chef = db.t私廚.FirstOrDefault(c => c.fUID == fUID);


            return View(new ViewModels.Account.多數模型vm
            {
                chef = chef,
                member = acc
            });
        }
        public ActionResult Details_edit(int fUID)
        {

            var acc = db.t會員.FirstOrDefault(m => m.fUID == fUID);
            if (acc == null)
                return RedirectToAction("list");
            return View(acc);
        }
        [HttpPost]
        public ActionResult Details_edit(基本資料vm vm)
        {
            var acc = db.t會員.FirstOrDefault(m => m.fUID == vm.fUID);

            if (vm.image != null)
            {
                int point = vm.image.FileName.IndexOf(".");
                string extention = vm.image.FileName.Substring(point, vm.image.FileName.Length - point);
                string photoName = Guid.NewGuid().ToString() + extention;
                string oldphoto = acc.f會員照片;
                vm.image.SaveAs(Server.MapPath("~/Content/Memberimage/" + photoName));
                try
                {
                    System.IO.File.Delete(Server.MapPath("~/Content/Memberimage/" + oldphoto));
                }
                catch
                {
                }
                vm.f會員照片 = "../Memberimage/" + photoName;
                acc.f會員照片 = vm.f會員照片;
            }
            if (acc != null)
            {


                if (ModelState.IsValid) //判斷前端資料驗證ok後 才能儲存回首頁
                {
                    acc.f姓名 = vm.f姓名;
                    acc.f暱稱 = vm.f暱稱;
                    acc.f電話 = vm.f電話;
                    acc.f生日 = vm.f生日;
                    acc.f居住縣市 = vm.f居住縣市;
                    acc.f詳細地址 = vm.f詳細地址;
                    acc.f電子郵件 = vm.f電子郵件;

                    db.SaveChanges();
                    return RedirectToAction("Details", "Account", new { fUID = vm.fUID });
                }
                return View();
            }
            return RedirectToAction("Details", "Account", new { fUID = vm.fUID });
        }





















    }
}