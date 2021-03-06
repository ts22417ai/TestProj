﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

// === Matadata ===


namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [MetadataType(typeof(t會員MD))]
    public partial class t會員
    {
        public class t會員MD
        {
            // DatabaseGeneratedAttribute
            // https://stackoverflow.com/questions/5341238/entity-framework-generates-values-for-not-null-columns-which-has-default-defined

            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int fUID { get; set; }

            [Display(Name = "帳號")]
            public string f帳號 { get; set; }


            [Display(Name = "密碼")]
            public string f密碼 { get; set; }

            // 電子郵件 EmailAddress RegularExpression 
            // https://stackoverflow.com/questions/5342375/regex-email-validation

            [Display(Name = "電子郵件")]
            public string f電子郵件 { get; set; }

            [Display(Name = "姓名")]
            public string f姓名 { get; set; }

            [Display(Name = "暱稱")]
            public string f暱稱 { get; set; }

            [Display(Name = "電話")]
            public string f電話 { get; set; }

            [Display(Name = "生日")]
            public string f生日 { get; set; }

            [Display(Name = "詳細地址")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public string f詳細地址 { get; set; }

            [Display(Name = "居住縣市")]
            [Compare("f詳細地址", ErrorMessage = "居住縣市 is Not Matching 詳細地址")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public string f居住縣市 { get; set; }

            [Display(Name = "會員照片")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public string f會員照片 { get; set; }

            [Display(Name = "點數")]
            public int f點數 { get; set; }

            [Display(Name = "權限")]
            public int f權限 { get; set; }

        }
    }
}
