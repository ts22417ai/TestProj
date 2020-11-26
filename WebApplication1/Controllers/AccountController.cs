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
                acc.f居住縣市 = modify.f居住縣市; 
                acc.f電話 = modify.f電話;
                acc.f會員照片 = modify.f會員照片;

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



        public ActionResult index()
        {
            if (Session["Member"] == null)
            {
                //指定Index.cshtml套用_Layout.cshtml，View使用products模型
                return View("Index", "_LayoutPage1");
            }
            //會員登入狀態
            //指定Index.cshtml套用_LayoutMember.cshtml，View使用products模型
            return View("Index", "_LayoutPage1 - 複製");
        }





        [AllowAnonymous]
        public ActionResult login()
        {
            if (Session["Member"] == null)
            {
                return View("login", "_LayoutPage1");
            }
            //會員登入狀態
            return View("login", "_LayoutPage1 - 複製");
        }
        [HttpPost]
        public ActionResult login(string account,string password)
        {   // 依帳密取得會員並指定給member
            var member = db.t會員
              .Where(m => m.f帳號 == account && m.f密碼 == password )
              .FirstOrDefault();
            if (member == null)
            {
                ViewBag.Message = "帳密錯誤，登入失敗";
                return View("login", "_LayoutPage1");
            }
            var chef = db.t私廚.Where(m => m.fUID == member.fUID).FirstOrDefault();

            Session["WelCome"] = member.f姓名 + "歡迎光臨";
            //使用Session變數記錄登入的會員物件
            Session["Member"] = member;
            Session["Chef"] = chef;
            //執行Home控制器的Index動作方法
            return RedirectToAction("Details");


        }

        public ActionResult Logout()
        {
            Session.Clear();  //清除Session變數資料
            return RedirectToAction("index");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            if (Session["Member"] == null)
            {
                return View("Register", "_LayoutPage1");
            }
            //會員登入狀態
            return View("Register", "_LayoutPage1 - 複製");
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
                    member.f權限 = 0;
                    member.f點數 = 0;
                    db.t會員.Add(member);
                    db.SaveChanges();

                    return RedirectToAction("registersuccess", "Account");//註冊成功跳至成功畫面

                }
                return View("Register", "_LayoutPage1 - 複製");//資料驗證失敗 重整並顯示錯誤訊息
            }
            return View("Register", "_LayoutPage1 - 複製");//資料驗證失敗 重整並顯示錯誤訊息
        }


        public ActionResult registersuccess()
        {
            return View();//註冊成功的畫面+回去登入畫面
        }
        public ActionResult Details()
        {
            //找出會員帳號並指定給fUId cUID
            //將查詢結果指定給會員 私廚
            int fUId = (Session["Member"] as t會員).fUID;
            var 會員 = db.t會員.FirstOrDefault(m => m.fUID == fUId);

            if (會員.f權限 > 0) 
            { 
                int cUId = (Session["Chef"] as t私廚).fUID;
                var 私廚 = db.t私廚.FirstOrDefault(m => m.fUID == cUId);

                return View("Details", "_LayoutPage1 - 複製", new ViewModels.Account.多數模型vm
                {
                    chef = 私廚,
                    member = 會員
                });
            }
            return View("Details", "_LayoutPage1 - 複製", new ViewModels.Account.多數模型vm
            {
                member = 會員
            });

        }


        public ActionResult Details_edit()
        {
            int fUId = (Session["Member"] as t會員).fUID;
            var 會員 = db.t會員.FirstOrDefault(m => m.fUID == fUId);

            return View("Details_edit", "_LayoutPage1 - 複製", 會員);
        }
        [HttpPost]
        public ActionResult Details_edit(基本資料vm vm)
        {
            int fUId = (Session["Member"] as t會員).fUID;
            var acc = db.t會員.FirstOrDefault(m => m.fUID == fUId);

            if (acc != null)
            {
                if (ModelState.IsValid) //判斷前端資料驗證ok後 才能儲存回首頁
                {

                    if (vm.image != null)
                    {
                        int point = vm.image.FileName.IndexOf(".");
                        string extention = vm.image.FileName.Substring(point, vm.image.FileName.Length - point);
                        string photoName = Guid.NewGuid().ToString() + extention;
                        string oldphoto = acc.f會員照片;
                        try
                        {
                            vm.image.SaveAs(Server.MapPath("~/Content/Memberimage/" + photoName));
                            System.IO.File.Delete(Server.MapPath("~/Content/Memberimage/" + oldphoto));
                        }
                        catch
                        {
                        }
                        vm.f會員照片 = "../Memberimage/" + photoName;
                        acc.f會員照片 = vm.f會員照片;

                    }
                    acc.f姓名 = vm.f姓名;
                    acc.f暱稱 = vm.f暱稱;
                    acc.f電話 = vm.f電話;
                    acc.f生日 = vm.f生日;
                    acc.f居住縣市 = vm.f居住縣市;
                    acc.f詳細地址 = vm.f詳細地址;
                    acc.f電子郵件 = vm.f電子郵件;
                
                    db.SaveChanges();
                    return RedirectToAction("Details", "Account");
                }
                //return RedirectToAction("Details_edit", "Account", new { fUID = vm.fUID });//避免資料驗證失敗id跑掉 導致沒預覽圖片 //但錯誤訊息出不來
                return View("Details_edit", "_LayoutPage1 - 複製");
            }
            return RedirectToAction("Details", "Account");
        }





















    }
}