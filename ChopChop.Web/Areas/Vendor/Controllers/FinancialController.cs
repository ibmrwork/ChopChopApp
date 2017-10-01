using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChopChop.Web.Areas.Vendor.Controllers
{
    public class FinancialController : Controller
    {
        // GET: Vendor/Financial
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FinancialView()
        {
            if (Session["UserId"] != null && ((string)Session["UserName"] == "Admin"))
                return RedirectToAction("Dashboard", "Dashboard", new { area = "Admin" });

            return View();
        }
    }
}