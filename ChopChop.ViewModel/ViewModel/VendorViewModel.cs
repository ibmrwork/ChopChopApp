using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.ViewModel.ViewModel
{
    public class VendorViewModel
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public Nullable<int> VendorStyle { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string LogoPath { get; set; }
        public string VideoPath { get; set; }
        public string Blurb { get; set; }
        public string C360DegreePath { get; set; }
       
   
    
        public int VendorTimingID { get; set; }
        public string LunchTimeWeakDay { get; set; }

        public string LunchTimeWeakEnd { get; set; }
        public string DinnerTimeWeakDay { get; set; }
        public string DinnerTimeWeakEnd { get; set; }
        public Nullable<int> LunchWeakDays { get; set; }
        public Nullable<int> LunchWeakEnd { get; set; }
        public Nullable<int> DinnerWeakDays { get; set; }
        public Nullable<int> DinnerWeakEnd { get; set; }
       
     
        public int ID { get; set; }
        public Nullable<int> MediaType { get; set; }
        public List<Images> lstImages { get; set; }
        public string MediaPath { get; set; }
        
        public string MainImagePath { get; set; }
      
    }
    public class Images {
        public int ImageType { get; set; }
        public string ImagePath { get; set; }
    }

}
