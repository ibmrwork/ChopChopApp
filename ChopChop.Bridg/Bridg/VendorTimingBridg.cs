using ChopChop.Bridg.IBridg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.ViewModel.ViewModel;
using ChopChop.Service.IServices;

namespace ChopChop.Bridg.Bridg
{
    public class VendorTimingBridg : IVendorTimingBridg
    {
        IVendorTimingService _iVendorTimingService;
        public VendorTimingBridg(IVendorTimingService iVendorTimingService)
        {
            this._iVendorTimingService = iVendorTimingService;
        }
        public int Insert(VendorViewModel vendorTimingModel)
        {
            return 1;
        }
    }
}
