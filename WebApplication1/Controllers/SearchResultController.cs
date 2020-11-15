using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class SearchResultController : Controller
    {
        // GET: SearchResult
        public ActionResult List()
        {
            //var table = from p in (new Database1Entities()).tProductitem
            //            select p;
            //List<Cproductitem> list = new List<Cproductitem>();
            //foreach (tProductitem p in table)
            //    list.Add(new Cproductitem(p));
           return View();
        }
    }
}