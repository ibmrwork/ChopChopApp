using ChopChop.IBridg;
using ChopChop.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChopChop.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IAdminBridg _adminBridg;
        public HomeController(IAdminBridg adminBridg)  
        {
            this._adminBridg = adminBridg;  
        }  
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

       
    }
}