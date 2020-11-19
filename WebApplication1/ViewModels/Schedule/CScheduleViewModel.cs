using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Schedule
{
    public class CScheduleViewModel
    {      
        public List<string> ArrEnable { get; set; }
        public List<string> ArrUnable { get; set; }
        public List<string> ArrGetNewTime { get; set; }
        public List<string> ArrGetDeletedTime { get; set; }
    }
}