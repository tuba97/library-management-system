//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp7
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kayitlar
    {
        public int kayit_id { get; set; }
        public Nullable<int> kullanici_id { get; set; }
        public Nullable<int> kitap_id { get; set; }
        public Nullable<System.DateTime> alis_tarihi { get; set; }
        public Nullable<System.DateTime> son_tarih { get; set; }
        public Nullable<bool> durum { get; set; }
    
        public virtual Kaynaklar Kaynaklar { get; set; }
        public virtual kullanıcılar kullanıcılar { get; set; }
    }
}
