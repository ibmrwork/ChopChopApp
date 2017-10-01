using ChopChop.Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.Service.IServices
{
   public interface IVendorTimingService
    {
        VendorTiming Insert(VendorTiming vendorTimingEntity);
    }
}
