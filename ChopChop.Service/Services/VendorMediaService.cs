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
    public class VendorMediaService : GenericRepository<VendorMedia>, IVendorMediaService
    {
        IGenericRepository<VendorMedia> repoUser = new GenericRepository<VendorMedia>();
        public VendorMedia InsertVendorMedia(VendorMedia vendorMedia)
        {
            //bool isInserted = false;
            try
            {
                repoUser.Add(vendorMedia);
                //isInserted = true;
            }
            catch (Exception ex)
            {
                throw ex;
                //isInserted = false;
            }

            return vendorMedia;
        }
    }
}
