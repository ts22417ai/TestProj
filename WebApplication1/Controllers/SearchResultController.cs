﻿using System;
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
    
        
        public ActionResult SearchByCondition(CSearchResult vm)
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
                list.f地區 = (new CSearchResultFactory()).Add地區SelectListItem();

                //設定時段 SelectListItem
                list.f時段 = (new CSearchResultFactory()).Add時段SelectListItem();

                //設定風格 SelectListItem
                list.f風格 = (new CSearchResultFactory()).Add風格SelectListItem();

                //設定服務種類 SelectListItem
                list.f服務種類 = (new CSearchResultFactory()).Add服務種類SelectListItem();

                return View("SearchByCondition", list);
            }
            else {
                var list = new CSearchResult
                {

                };

                //設定地區 SelectListItem
                list.f地區 = (new CSearchResultFactory()).Add地區SelectListItem();

                //設定時段 SelectListItem
                list.f時段 = (new CSearchResultFactory()).Add時段SelectListItem();

                //設定風格 SelectListItem
                list.f風格 = (new CSearchResultFactory()).Add風格SelectListItem();

                //設定服務種類 SelectListItem
                list.f服務種類 = (new CSearchResultFactory()).Add服務種類SelectListItem();

                return View("SearchByCondition",list);
            }
        }
      
        public ActionResult SearchByKeyWord(CSearchResult vm)
        {
            string keyWord = vm.txtkeyword;
            if (keyWord != null)
            {
                List<SearchProduct> Productlist = new List<SearchProduct>();
                Productlist = (new CSearchResultFactory()).GetCSearchResultsByKeyWord(keyWord);
                var list = new CSearchResult
                {
                    搜尋結果 = Productlist,
                    txtkeyword = keyWord
                };
                //設定地區 SelectListItem
                list.f地區 = (new CSearchResultFactory()).Add地區SelectListItem();

                //設定時段 SelectListItem
                list.f時段 = (new CSearchResultFactory()).Add時段SelectListItem();

                //設定風格 SelectListItem
                list.f風格 = (new CSearchResultFactory()).Add風格SelectListItem();

                //設定服務種類 SelectListItem
                list.f服務種類 = (new CSearchResultFactory()).Add服務種類SelectListItem();

                return View("SearchByKeyWord", list);
            }

            else
            {
                var list = new CSearchResult
                {

                };

                //設定地區 SelectListItem
                list.f地區 = (new CSearchResultFactory()).Add地區SelectListItem();

                //設定時段 SelectListItem
                list.f時段 = (new CSearchResultFactory()).Add時段SelectListItem();

                //設定風格 SelectListItem
                list.f風格 = (new CSearchResultFactory()).Add風格SelectListItem();

                //設定服務種類 SelectListItem
                list.f服務種類 = (new CSearchResultFactory()).Add服務種類SelectListItem();
                return View("SearchByKeyWord", list);
            }
        }
    }
}
