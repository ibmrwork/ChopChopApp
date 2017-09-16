using ChopChop.IBridg;
using ChopChop.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ChopChop.Bridg
{
    public class AdminBridg : IAdminBridg
    {
        readonly IAdminService _adminService;
        public AdminBridg(IAdminService adminService)
        {
            this._adminService = adminService; 
        }
    }
}
