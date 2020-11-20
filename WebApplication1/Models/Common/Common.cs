using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Common
{

    /// <summary>
    /// SESSION KEY OR ... 
    /// </summary>
    public class CDictionary
    {
        public static readonly string SK_PRODUCTS_PUSHED_SHOPPING_LIST = "SK_PRODUCTS_PUSHED_SHOPPING_LIST";
        public static readonly string SK_LOGINED_USER = "SK_LOGINED_USER";
        public static readonly string SK_AUTHTICATION_CODE = "SK_AUTHTICATION_CODE";

    }

    /// <summary>
    /// [t私廚可預訂時間]
    ///  的狀態
    /// </summary>
    public enum e私廚可預訂時間_狀態
    {
        可預訂時間 = 1,
        已被預訂_不可修改 = 3
    }

    public enum e私廚可預訂時間_時段
    {
        午餐 = 1,
        晚餐 = 2
    }

    /// <summary>
    /// [t訂單]
    /// [狀態]
    /// </summary>
    public enum e訂單狀態
    {
        客戶預訂 = 1,
        私廚確認_開放評價 = 2,
        客戶確認_客戶評價 = 3
    }

    public class Func
    {
        public string 照片處理(HttpPostedFileBase httpPostedFile)
        {
            // 取得 . 的位置
            int point = httpPostedFile.FileName.IndexOf(".");
            // 取得 附檔名 *.jpg
            string estention = httpPostedFile.FileName
                .Substring(point, httpPostedFile.FileName.Length - point);
            // 不重複16位檔名
            string photoName = Guid.NewGuid().ToString() + estention;
            string location = @"~/Content/" + photoName;
            httpPostedFile.SaveAs(location);

            return location;
        }
    }
    

}