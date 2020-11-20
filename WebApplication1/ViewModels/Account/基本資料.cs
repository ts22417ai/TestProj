﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.ViewModels.Account
{
    public class 基本資料vm
    {
        public int fUID { get; set; }

        [Display(Name = "姓名")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "您必須輸入姓名！")]
        public string f姓名 { get; set; }


        [Display(Name = "暱稱")]
        [DataType(DataType.Text)]
        public string f暱稱 { get; set; }



        [Display(Name = "電話")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "您必須輸入電話！")]
        public string f電話 { get; set; }


        [Display(Name = "居住縣市：")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "您必須居住縣市！")]

        public string f居住縣市 { get; set; }


        [Display(Name = "詳細地址")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "您必須輸入地址！")]
        public string f詳細地址 { get; set; }


        [Required(ErrorMessage = "您必須輸入生日")]
        [Display(Name = "生日")]
        [DataType(DataType.Date, ErrorMessage = "請輸入正確日期")]
        public string f生日 { get; set; }


        [Display(Name = "電子信箱")]
        [Required(ErrorMessage = "您必須輸入Email")]
        [StringLength(300, MinimumLength = 6, ErrorMessage = "此欄位僅接受300個字")]
        [DataType(DataType.EmailAddress, ErrorMessage = "請輸入正確的電子信箱")]
        public string f電子郵件 { get; set; }


        public string f會員照片 { get; set; }
        public Nullable<int> f點數 { get; set; }

        public Nullable<int> f權限 { get; set; }

        public HttpPostedFileBase image { get; set; }

    }
}