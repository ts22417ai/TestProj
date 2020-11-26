using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Common;
using WebApplication1.ViewModels.Order;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private Database1Entities db = new Database1Entities();




        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(v登入VM 登入VM)
        {
            // 模型驗證
            if (ModelState.IsValid)
            {
                var user = db.t會員.FirstOrDefault(u =>
                    u.f帳號 == 登入VM.帳號 && u.f密碼 == 登入VM.密碼
                );
                // 帳密驗證
                if (user != null)
                {
                    Session.Clear();
                    Session[CDictionary.SK_LOGINED_USER_ID] = user;
                    // 私廚ID
                    //if ((int)user.f權限 == e會員_權限.私廚.GetHashCode())
                    //{
                    //    var chef = db.t私廚.FirstOrDefault(c => c.fUID == user.fUID);
                    //    Session[CDictionary.SK_CHEF_ID] = chef.fCID;
                    //}
                    return RedirectToAction("center");
                }

            }
            return View();
        }

        public ActionResult center()
        {
            if (Session[CDictionary.SK_LOGINED_USER_ID] == null)
            {
                return RedirectToAction("login");
            }

            var user = Session[CDictionary.SK_LOGINED_USER_ID] as t會員;

            var linq = from u in db.t會員
                       join c in db.t私廚
                            on u.fUID equals c.fUID into mixin
                       from x in mixin.DefaultIfEmpty()
                       where u.fUID == user.fUID
                       select new v會員中心VM
                       {
                           姓名 = u.f姓名,
                           暱稱 = u.f暱稱,
                           會員照片 = u.f會員照片,
                           地址 = u.f居住縣市,
                           生日 = u.f生日,
                           電話 = u.f電話,
                           電子郵件 = u.f電子郵件,
                           點數 = u.f點數 ?? 0,
                           fCID = x.fCID,
                           服務地區 = x.f服務地區,
                           私廚簡介 = x.f私廚簡介,
                           服務項目 = x.f服務種類,
                           餐飲風格 = x.f風格
                       };

            return View(linq.FirstOrDefault());
        }

        public ActionResult register()
        {
            if (Session[CDictionary.SK_LOGINED_USER_ID] == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }

        //==========================================================

        public ActionResult buyPoint()
        {
            if (Session[CDictionary.SK_LOGINED_USER_ID] == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult buyPoint(v儲值點數VM buyPointVM)
        {
            if (ModelState.IsValid)
            {
                if (Session[Models.Common.CDictionary.SK_LOGINED_USER_ID] != null)
                {
                    var user = Session[Models.Common.CDictionary.SK_LOGINED_USER_ID] as t會員;
                    var newPoint = new t儲值點數
                    {
                        fUID = user.fUID,
                        f點數 = buyPointVM.f點數
                    };
                    db.t儲值點數.Add(newPoint);
                    db.SaveChanges();
                    RedirectToAction("buyPointSuccess");
                }
            }
            return RedirectToAction("", "");
        }

        public ActionResult buyPointSuccess()
        {
            return View();
        }

        public ActionResult transaction()
        {
            if (Session[CDictionary.SK_LOGINED_USER_ID] == null)
            {
                return RedirectToAction("login");
            }

            var user = Session[CDictionary.SK_LOGINED_USER_ID] as t會員;
            //var user = db.t會員.FirstOrDefault(u => u.fUID == fUID);

            var linq = db.sp_交易紀錄(user.fUID);

            var 交易紀錄 = new v交易紀錄VM
            {
                點數餘額 = user.f點數 ?? 0,
                交易紀錄 = linq.ToList()
            };

            return View(交易紀錄);
        }

        public ActionResult chefInfo(int fCID)
        {
            // 1.私廚資訊 2.私廚販售項目清單

            // 私廚販售項目清單
            var chefProp = from p in db.t販售項目
                           join s in db.t風格 on p.fSID equals s.fSID
                           join k in db.t服務種類 on p.fKID equals k.fKID
                           where p.fCID == fCID && p.f上架 == true
                           select new ChefProduct
                           {
                               項目名稱 = p.f項目名稱,
                               價格 = p.f價格,
                               風格 = s.f風格,
                               服務種類 = k.f服務種類,
                               項目照片 = p.f項目照片
                           };

            // 私廚資訊
            var linq = from c in db.t私廚
                       join u in db.t會員 on c.fUID equals u.fUID
                       where c.fCID == fCID
                       select new v私廚資訊VM
                       {
                           私廚姓名 = u.f姓名,
                           私廚照片 = u.f會員照片,
                           私廚評級 = c.f私廚評級 == null ? 0 : (int)c.f私廚評級,
                           電子郵件 = u.f電子郵件,
                           服務地區 = c.f服務地區,
                           餐飲風格 = c.f風格,
                           服務種類 = c.f服務種類,
                           私廚簡介 = c.f私廚簡介,
                           項目清單 = chefProp.ToList()
                       };

            var chefinfo = linq.FirstOrDefault();

            return View(chefinfo);
        }

        public ActionResult clientInfo(int fUID)
        {
            var user = db.t會員.FirstOrDefault(u => u.fUID == fUID);
            if (user != null)
            {
                var 客戶資訊 = new v客戶資訊VM
                {
                    客戶姓名 = user.f姓名,
                    客戶暱稱 = user.f暱稱,
                    客戶照片 = user.f會員照片,
                    電子郵件 = user.f電子郵件,
                    電話 = user.f電話
                };
                return View(客戶資訊);
            }
            return View();
        }

        public ActionResult evaluate(int fOID)
        {
            //if (Session[CDictionary.SK_LOGINED_USER_ID] == null)
            //{
            //    return RedirectToAction("login");
            //}
            
            var linq = from o in db.t訂單
                       join p in db.t販售項目 on o.fPID equals p.fPID
                       join k in db.t服務種類 on p.fKID equals k.fKID
                       join c in db.t私廚 on p.fCID equals c.fCID
                       join u in db.t會員 on c.fUID equals u.fUID
                       where o.fOID == fOID
                       select new v評價VM
                       {
                           預定日期 = o.f預定日期,
                           私廚名稱 = u.f姓名,
                           私廚照片 = u.f會員照片,
                           私廚評級 = c.f私廚評級 ?? 0,
                           項目名稱 = p.f項目名稱,
                           項目照片 = p.f項目照片,
                           價格 = p.f價格,
                           服務種類 = k.f服務種類,

                           fOID = fOID
                       };

            return View(linq.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult evaluate(v評價VM vm)
        {
            var order = db.t訂單.FirstOrDefault(o => o.fOID == vm.fOID);

            if (order != null)
            {
                order.f評級 = vm.評級;
                order.f評價內容 = vm.評價內容;
                order.f評價日期 = DateTime.Now.ToString("g");

                order.f狀態 = e訂單狀態.客戶確認_完成評價.GetHashCode();

                db.SaveChanges();

                var chef = (from c in db.t私廚
                            join p in db.t販售項目 on c.fCID equals p.fCID
                            where p.fPID == order.fPID
                            select c).FirstOrDefault();

                //var linq = from c in db.t私廚
                //           join p in db.t販售項目 on c.fCID equals p.fCID
                //           join o in db.t訂單 p.fPID equals o.fPID
                //           where c.fCID == chef.fCID && o.f狀態 == 3
                //           select c; 
                
            }
            return RedirectToAction("transaction");
        }

        public ActionResult salesItem(int fUID, int fPID)
        {

            return View();
        }


        //=========================================================

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