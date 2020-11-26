using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Order
{
    public class 菜品
    {
        public string 菜品名稱 { get; set; }
        public string 菜色介紹 { get; set; }
        public string 菜品照片 { get; set; }

    }

    public class 顧客評價
    {
        public string 暱稱 { get; set; }
        public string 顧客照片 { get; set; }
        public string 顧客評級 { get; set; }
        public string 評價日期 { get; set; }
    }

    public class v項目訂購VM
    {
        #region 項目訂購

        public string 項目照片 { get; set; }
        public string 項目名稱 { get; set; }
        public string 服務種類 { get; set; }
        public string 風格 { get; set; }

        public string 私廚姓名 { get; set; }
        public string 私廚照片 { get; set; }

        public int 私廚評級 { get; set; }
        public string 服務地區 { get; set; }
        public string 私廚簡介 { get; set; }

        #endregion

        #region 菜品清單 顧客評價清單

        public List<菜品> 菜品清單 { get; set; }

        public List<顧客評價> 顧客評價清單 { get; set; }

        #endregion

        /// <summary>
        /// 用JS解析成兩層下拉式選單
        /// </summary>
        public string 私廚可預定日期_時段 { get; set; }

        public int fPID { get; set; }

        public int fUID { get; set; }

        public string 預定日期 { get; set; }

        public string 預定時段 { get; set; }

        public int 數量 { get; set; }


    }

}