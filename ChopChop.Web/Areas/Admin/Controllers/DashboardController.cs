using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChopChop.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session["UserId"] != null && (string)Session["UserName"] == "Admin")
                return View();

            return RedirectToAction("Login", "Login",new{ Area ="Account" });
            
        }
    }
}