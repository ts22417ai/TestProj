using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.ViewModels.Product
{
    public class ProductCreateVM
    {
        public int fPID { get; set; }

        [Display(Name = "[私廚][fCID]")]
        public int fCID { get; set; }

        [Display(Name = "[風格][fSID]")]
        public int fSID { get; set; }

        public List<SelectListItem> style { get; set; }

        [Display(Name = "[種類][fKID]")]
        public int fKID { get; set; }

        public List<SelectListItem> kind { get; set; }

        [Display(Name = "項目名稱")]
        public string f項目名稱 { get; set; }

        [Display(Name = "項目內容")]
        public string f項目內容 { get; set; }

        [Display(Name = "價格")]
        public int f價格 { get; set; }

        [Display(Name = "項目照片")]
        public string f項目照片 { get; set; }

        [Display(Name = "項目評級")]
        public int f項目評級_ { get; set; }

        [Display(Name = "上架")]
        public bool f上架 { get; set; }

    }
}