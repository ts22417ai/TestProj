using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Common;
using WebApplication1.Models.SearchResult;
using WebApplication1.ViewModels.Home;

namespace WebApplication1.Controllers
{
    public class SearchResultController : Controller
    {
        // GET: SearchResult

        private Database1Entities db = new Database1Entities();
        public ActionResult SearchByCondition(PopularProductViewModel vm)
        {
            if (vm.風格 != null && vm.地區 != null && vm.服務種類 != null && vm.時段 != null && vm.f日期 != null)
            {
                string k風格 = vm.風格.ToString();//Search bar attr1
                string k地區 = vm.地區.ToString();//Search bar attr2
                string k服務種類 = vm.服務種類.ToString();//Search bar attr3
                string k時段 = vm.時段.ToString();//Search bar attr4
                string k日期 = vm.f日期.ToString();//Search bar attr5


                List<SearchProduct> Productlist = new List<SearchProduct>();
                Productlist = (new CSearchResultFactory()).GetCSearchResultsByCondition(k風格, k地區, k服務種類, k日期, k時段);          
                var list = new CSearchResult
                {
                    搜尋結果 = Productlist,  
                    f日期 = k日期
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
                    {
                        Text = x.ToString(),
                        Value = x.GetHashCode().ToString()
                    }));

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
                    Value = x.f服務種類.ToString(),
                    Text = x.f服務種類
                }).ToList();

                list.f時段 = 時段;
                list.f地區 = 地區預設;
                list.f風格 = 風格;
                list.f服務種類 = 服務種類;
                return View(list);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult SearchByKeyWord(PopularProductViewModel vm)
        {
            string keyWord = vm.txtkeyword;
            if (keyWord != null) { 
            List<SearchProduct> Productlist = new List<SearchProduct>();
            Productlist = (new CSearchResultFactory()).GetCSearchResultsByKeyWord(keyWord);
            var list = new CSearchResult
            {
                搜尋結果 = Productlist,  
                txtkeyword = keyWord
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
                {
                    Text = x.ToString(),
                    Value = x.GetHashCode().ToString()
                }));

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
                Value = x.f服務種類.ToString(),
                Text = x.f服務種類
            }).ToList();

            list.f時段 = 時段;
            list.f地區 = 地區預設;
            list.f風格 = 風格;
            list.f服務種類 = 服務種類;
        
            return View(list);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }     
    }
}
