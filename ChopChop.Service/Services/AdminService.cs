using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.Repository;
using ChopChop.Entity.EntityFramework;
using ChopChop.Service.IServices;
namespace ChopChop.Service
{
    public class AdminService : GenericRepository<Admin>, IAdminService
    {

    }
}
