using ChopChop.IBridg;
using ChopChop.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.ViewModel;
using ChopChop.Entity.EntityFramework;
namespace ChopChop.Bridg
{
    public class AdminBridg : IAdminBridg
    {
        //readonly IAdminService _adminService;
        //public AdminBridg(IAdminService adminService)
        //{
        //    this._adminService = adminService; 
        //}

        ///// <summary>
        ///// Insert Admin detail in AdminUser table in database
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public int InsertAdmin(UserViewModel model)
        //{
        //    try
        //    {
        //        User entity = new User
        //        {
        //            CreatedDate = model.CreatedDate,
        //            ModifiedDate = model.ModifiedDate,
        //            Password = model.Password,
        //            UserName = model.UserName,
        //            IsActive = model.IsActive,
        //            IsDeleted = model.IsDeleted
        //        };

        //        _adminService.Add(entity);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
            
        //}
    }
}
