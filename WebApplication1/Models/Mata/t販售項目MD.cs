﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [MetadataType(typeof(t販售項目MD))]
    public partial class t販售項目
    {
        public class t販售項目MD
        {

            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int fPID { get; set; }

            [Display(Name = "[私廚][fCID]")]
            public int fCID { get; set; }

            [Display(Name = "[風格][fSID]")]
            public int fSID { get; set; }

            [Display(Name = "[種類][fKID]")]
            public int fKID { get; set; }

            [Display(Name = "項目名稱")]
            public string f項目名稱 { get; set; }

            [Display(Name = "項目內容")]
            public string f項目內容 { get; set; }

            [Display(Name = "價格")]
            public int f價格 { get; set; }

            [Display(Name = "項目照片")]
            public string f項目照片 { get; set; }

            [Display(Name = "項目評級")]
            public int f項目評級_ { get; set; }

            [Display(Name = "上架")]
            public bool f上架 { get; set; }

        }
    }
}
