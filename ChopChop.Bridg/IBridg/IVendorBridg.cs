﻿using ChopChop.Entity.EntityFramework;
using ChopChop.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.Bridg.IBridg
{
   public interface IVendorBridg
    {
        Vendor InsertVendor(VendorViewModel vendorModel);
        List<ResultSearchRestaurants> SearchRestaurants(SearchResturant searchResturant);
    }
}
