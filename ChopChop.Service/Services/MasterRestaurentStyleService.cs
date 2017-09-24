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
    public class MasterRestaurentStyleService : GenericRepository<MasterRestaurentStyle>, IMasterRestaurentStyleService
    {
        IGenericRepository<MasterRestaurentStyle> repoUser = new GenericRepository<MasterRestaurentStyle>();
        public IEnumerable<MasterRestaurentStyle> GetAll()
        {
            return repoUser.GetAll();
        }
    }
}
