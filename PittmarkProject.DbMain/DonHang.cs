//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PittmarkProject.DbMain
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonHang
    {
        public int Id { get; set; }
        public Nullable<int> Id_product { get; set; }
        public Nullable<int> Id_customer { get; set; }
        public string Note { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Delete_YMD { get; set; }
        public Nullable<System.DateTime> Insert_YMD { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> Update_YMD { get; set; }
        public Nullable<int> Update_user_id { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual Status Status1 { get; set; }
    }
}
