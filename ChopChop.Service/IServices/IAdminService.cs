using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.EntityFramework;
using ChopChop.Entity.Repository;
namespace ChopChop.Service.IServices
{
    public interface IAdminService : IGenericRepository<Admin>
    {
    }
}
