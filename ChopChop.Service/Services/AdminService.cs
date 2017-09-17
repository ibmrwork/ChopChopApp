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
    public class AdminService : GenericRepository<User>, IAdminService
    {
        IGenericRepository<User> repoAdmin = new GenericRepository<User>();
        /// <summary>
        /// Function to Insert data into Admin table in database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //public bool InsertAdmin(Admin entity)
        //{
        //    bool isInserted = false;
        //    try
        //    {
        //        repoAdmin.Add(entity);
        //        isInserted = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        isInserted = false;
        //    }

        //    return isInserted;
        //}
        /// <summary>
        /// Get List of all Admin
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllAdmin()
        {
            return repoAdmin.GetAll().ToList();
        }
    }
}
