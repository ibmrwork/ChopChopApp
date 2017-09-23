using ChopChop.ViewModel;
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
    }
}
