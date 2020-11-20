using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Order
{
    public class BuyPointVM
    {
        [Key]
        public int fDID { get; set; }

        public int fUID { get; set; }

        [Display(Name = "點數")]
        public int f點數 { get; set; }

        [Display(Name = "建立時間")]
        public System.DateTime f建立時間 { get; set; }
    }


}