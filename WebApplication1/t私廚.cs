//------------------------------------------------------------------------------
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
    
    public partial class t私廚
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t私廚()
        {
            this.t私廚可預訂時間 = new HashSet<t私廚可預訂時間>();
            this.t販售項目 = new HashSet<t販售項目>();
        }
    
        public int fCID { get; set; }
        public int fUID { get; set; }
        public string f服務地區 { get; set; }
        public string f私廚簡介 { get; set; }
        public Nullable<int> f私廚評級 { get; set; }
        public string f風格 { get; set; }
        public string f服務種類 { get; set; }
    
        public virtual t會員 t會員 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t私廚可預訂時間> t私廚可預訂時間 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t販售項目> t販售項目 { get; set; }
    }
}
