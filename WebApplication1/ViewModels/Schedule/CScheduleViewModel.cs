using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Schedule
{
    public class CScheduleViewModel
    {   public int fCid { get; set; }
        public List<string> ArrEnable { get; set; }
        public List<string> ArrUnable { get; set; }
        public string ArrGetNewTime { get; set; }
        public string ArrGetDeletedTime { get; set; }
    }
}