using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChopChop.Web.Areas.Vendor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Vendor/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}