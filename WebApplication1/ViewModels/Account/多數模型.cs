using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels.Account
{
    public class 多數模型vm
    {

        public t會員 member { get; set; }
        public t私廚 chef { get; set; }
    }
}