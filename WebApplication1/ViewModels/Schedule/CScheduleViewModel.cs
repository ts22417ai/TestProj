using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Schedule
{
    public class CScheduleViewModel
    {      
        public int fTID { get; set; }
        public int fCID { get; set; }
        public string f日期 { get; set; }
        public int f午餐 { get; set; }
        public int f晚餐 { get; set; }        
    }
}