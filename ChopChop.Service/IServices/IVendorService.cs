using ChopChop.Entity.EntityFramework;
using ChopChop.ViewModel;
using ChopChop.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.Service.IServices
{
    public interface IVendorService
    {
        List<ResultSearchRestaurants> SearchRestaurants(SearchResturant searchResturant);
        Vendor Insert(Vendor vendor);
    }
}
