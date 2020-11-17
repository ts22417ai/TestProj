using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.SearchResult;

namespace WebApplication1.Controllers
{
    public class SearchResultController : Controller
    {
        // GET: SearchResult
        public ActionResult Search()
        {
            string k風格 = Request.Form["txt風格"];//Search bar attr1
            string k地區 = Request.Form["txt地區"];//Search bar attr2
            string k服務種類 = Request.Form["txt服務種類"];//Search bar attr3
            string k時段 = Request.Form["txt時段"];//Search bar attr4
            string k日期 = Request.Form["txt日期"];//Search bar attr5

            List<CSearchResult> list = new List<CSearchResult>();
            list = (new CSearchResultFactory()).GetCSearchResults(k風格, k地區, k服務種類, k日期, k時段);
            return View(list);
        }
    }
}