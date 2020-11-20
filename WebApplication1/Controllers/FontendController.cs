using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class FontendController : Controller
    {
        // GET: Fontend

        // 儲值點數
        public ActionResult buypoint()
        {
            return View();
        }

        // 儲值成功
        public ActionResult buypointsuccess()
        {
            return View();
        }

        // 編輯私廚簡介
        public ActionResult chefedit()
        {
            return View();
        }

        // 私廚簡介
        public ActionResult chefinfo()
        {
            return View();
        }

        // 客戶資訊
        public ActionResult clientinfo()
        {
            return View();
        }

        // 新增 - 販售項目 - 菜色
        public ActionResult dishesinfo()
        {
            return View();
        }

        // 填寫評價
        public ActionResult evaluate()
        {
            return View();
        }

        // 編輯基本資料
        public ActionResult memberinfo()
        {
            return View();
        }

        // 新增販售項目
        public ActionResult productinfo()
        {
            return View();
        }

        // 註冊
        public ActionResult register()
        {
            return View();
        }

        // 註冊成功
        public ActionResult registersuccess()
        {
            return View();
        }

    }
}