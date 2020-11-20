﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.SearchResult
{
    public class CSearchResult
    {
        [Key]
        public int fCID { get; set; }
        public string f項目名稱 { get; set; }
        public string f私廚姓名 { get; set; }
        public string f項目照片 { get; set; }
        public int f價格 { get; set; }
        public int f項目評級 { get; set; }
        public string f風格 { get; set; }
        public string f服務種類 { get; set; }
    }
}
