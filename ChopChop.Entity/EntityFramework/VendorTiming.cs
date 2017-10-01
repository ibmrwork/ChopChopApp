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
    
    public partial class VendorTiming
    {
        public int VendorTimingID { get; set; }
        public Nullable<int> VendorID { get; set; }
        public string LunchTimeWeakDay { get; set; }
        public string LunchTimeWeakEnd { get; set; }
        public string DinnerTimeWeakDay { get; set; }
        public string DinnerTimeWeakEnd { get; set; }
        public Nullable<int> LunchWeakDays { get; set; }
        public Nullable<int> LunchWeakEnd { get; set; }
        public Nullable<int> DinnerWeakDays { get; set; }
        public Nullable<int> DinnerWeakEnd { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual Vendor Vendor { get; set; }
    }
}
