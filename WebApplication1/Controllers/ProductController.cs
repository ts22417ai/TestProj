using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        private Database1Entities db = new Database1Entities();

        public ActionResult List()
        {
            var table = db.t販售項目.Select(p => p);
            var list = table.ToList();

            return View(list);
        }

        public ActionResult Create()
        {
            // @Html.DropDownListFor(x => x.fSID, Model.style)
            // https://stackoverflow.com/questions/12985088/binding-dropdownlist-into-mvc-view

            var selectListStyle = db.t風格.Select(s =>
                new SelectListItem {
                    Text = s.f風格,
                    Value = s.fSID.ToString()
                }).ToList();
            var selectListKind = db.t服務種類.Select(k => 
                new SelectListItem {
                    Text = k.f服務種類,
                    Value = k.fKID.ToString()
                }).ToList();

            var productCreateVM = new ViewModels.Product.ProductCreateVM
            {
                style = selectListStyle,
                kind = selectListKind
            };

            return View(productCreateVM);
        }

        [HttpPost]
        public ActionResult Create(t販售項目 p)
        {
            using (var db = new Database1Entities())
            {
                db.t販售項目.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int fPID)
        {
            var prod = db.t販售項目.FirstOrDefault(p => p.fPID == fPID);

            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(t販售項目 modify)
        {
            var prod = db.t販售項目.FirstOrDefault(p => p.fPID == modify.fPID);

            if (prod != null)
            {
                prod.fPID = modify.fPID;
                prod.fCID = modify.fCID;
                prod.fSID = modify.fSID;
                prod.fKID = modify.fKID;
                prod.f項目名稱 = modify.f項目名稱;
                prod.f項目內容 = modify.f項目內容;
                prod.f項目照片 = modify.f項目照片;
                prod.f項目評級_ = modify.f項目評級_;
                prod.f價格 = modify.f價格;

                db.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(int fPID)
        {

            var prod = db.t販售項目.FirstOrDefault(p => p.fPID == fPID);
            if (prod != null)
            {
                db.t販售項目.Remove(prod);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }


        public ActionResult ListFromtChef (int fCID)
        {
            var table = db.t販售項目.Where(p => p.fCID == fCID);
            var list = table.ToList();

            return View(list);
        }

        public ActionResult 私廚可預訂時間(int fCID)
        {
            var table = db.t私廚可預訂時間.Select(t => t);
            var list = table.ToList();

            return View(list);
        }


    }


}