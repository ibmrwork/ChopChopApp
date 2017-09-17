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
    
    public partial class Vendor
    {
        public Vendor()
        {
            this.Orders = new HashSet<Order>();
            this.UserFavoriteVendors = new HashSet<UserFavoriteVendor>();
            this.VendorCommisions = new HashSet<VendorCommision>();
            this.VendorMedias = new HashSet<VendorMedia>();
            this.VendorMenus = new HashSet<VendorMenu>();
            this.VendorRatings = new HashSet<VendorRating>();
        }
    
        public int VendorID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string VendorName { get; set; }
        public Nullable<int> VendorStyle { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string LogoPath { get; set; }
        public string VideoPath { get; set; }
        public string Blurb { get; set; }
        public string C360DegreePath { get; set; }
        public string ZipCode { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string FoodRating { get; set; }
        public string DeliveryRating { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserFavoriteVendor> UserFavoriteVendors { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<VendorCommision> VendorCommisions { get; set; }
        public virtual ICollection<VendorMedia> VendorMedias { get; set; }
        public virtual ICollection<VendorMenu> VendorMenus { get; set; }
        public virtual ICollection<VendorRating> VendorRatings { get; set; }
    }
}
