using ChopChop.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.EntityFramework;
using ChopChop.Entity.Repository;

namespace ChopChop.Service.Services
{
    public class VendorTimingService : GenericRepository<VendorTiming>, IVendorTimingService
    {
        IGenericRepository<VendorTiming> repoUser = new GenericRepository<VendorTiming>();
        public VendorTiming Insert(VendorTiming vendorTimingEntity)
        {
           // bool isInserted = false;
            try
            {
                repoUser.Add(vendorTimingEntity);
                //isInserted = true;
            }
            catch (Exception ex)
            {
                throw ex;
                //isInserted = false;
            }

            return vendorTimingEntity;
        }
    }
}
