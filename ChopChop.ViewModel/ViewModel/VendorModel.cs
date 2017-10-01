using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.ViewModel.ViewModel
{
   public class VendorModel
    {
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

        public string LunchTimeWeakDay { get; set; }
        public string LunchTimeWeakEnd { get; set; }
        public string DinnerTimeWeakDay { get; set; }
        public string DinnerTimeWeakEnd { get; set; }
        public Nullable<int> LunchWeakDays { get; set; }
        public Nullable<int> LunchWeakEnd { get; set; }
        public Nullable<int> DinnerWeakDays { get; set; }
        public Nullable<int> DinnerWeakEnd { get; set; }
    }

   public class SearchResturant
   {
       public decimal? Lat { get; set; }
       public decimal? Long { get; set; }
       public int? SortOptionId { get; set; }
       public int? StartIndex { get; set; }
       public int? EndIndex { get; set; }
       public int? LanguageId { get; set; }
       public string SearchText { get; set; }
       public int? TotalRows { get; set; }
   }
   public class ResultSearchRestaurants
   {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Describtion { get; set; }
       public string ThumbnailURL { get; set; }
       public decimal? Lat { get; set; }
       public decimal? Long { get; set; }
       public int? Distance { get; set; }
   }
}
