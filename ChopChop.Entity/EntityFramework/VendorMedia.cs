//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChopChop.Entity.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class VendorMedia
    {
        public int ID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public Nullable<int> MediaType { get; set; }
        public string OtherImagePath { get; set; }
        public string MediaPath { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual Vendor Vendor { get; set; }
    }
}
