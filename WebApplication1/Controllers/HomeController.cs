using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.SearchResult;
using WebApplication1.Models.Home;
using WebApplication1.ViewModels.Home;
using WebApplication1.Models.Common;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities db = new Database1Entities();
        public ActionResult Index()
        {   //取得熱門品項及熱門課程       
            var list_p = (new CHomeFeaturesFactory()).GetPopularProduct();
            var list_l = (new CHomeFeaturesFactory()).GetPopularLesson();
            var list = new PopularProductViewModel
            {
                熱門品項 = list_p,
                熱門課程 = list_l
            };

            //設定地區 SelectListItem
            var 地區預設 = new List<SelectListItem>();
            地區預設.Add(new SelectListItem { Text = "請選擇地區", Disabled = true, Selected = true });
            地區預設.AddRange(
                CDictionary.地區.Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = x
                }).ToArray()
            );

            //設定時段 SelectListItem
            var 時段 = new List<SelectListItem>();
            時段.AddRange(
                Enum.GetValues(typeof(e私廚可預訂_時段)).Cast<e私廚可預訂_時段>().Select(x => new SelectListItem
                { Text = x.ToString(), 
                  Value = x.GetHashCode().ToString() }));
            
            //設定風格 SelectListItem
            var 風格 = db.t風格.Select(x =>
            new SelectListItem
            {
                Text = x.f風格.ToString(),
                Value = x.f風格
            }).ToList();

            //設定服務種類 SelectListItem
            var 服務種類 = db.t服務種類.Select(x =>
            new SelectListItem
            {
                Value=x.f服務種類.ToString(),
                Text = x.f服務種類
            }).ToList();


            list.f時段 = 時段;
            list.f地區 = 地區預設;
            list.f風格 = 風格;
            list.f服務種類 = 服務種類;


            return View(list);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}