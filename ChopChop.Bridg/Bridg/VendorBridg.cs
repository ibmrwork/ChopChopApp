
using ChopChop.IBridg;
using ChopChop.Service.IServices;
using ChopChop.Service.Services;
using ChopChop.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.Bridg  
{
    public class VendorBridg : IVendorBridg       
    {
        IVendorService _vendorService;
          public VendorBridg(){
              _vendorService = new VendorService(); 
          }
        public VendorBridg(IVendorService IVendorService)
        {
            _vendorService = IVendorService;
        }
        public List<ResultSearchRestaurants> SearchRestaurants(SearchResturant searchResturant)     
        {
          return _vendorService.SearchRestaurants(searchResturant);
        }
    }
}
