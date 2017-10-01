using ChopChop.Bridg.IBridg;
using ChopChop.ViewModel.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChopChop.Web.Areas.Vendor.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor/Vendor
        IMasterRestaurentStyleBridg _masterRestaurentStyleBridg;
        IVendorBridg _vendorBridg;
        public VendorController(IMasterRestaurentStyleBridg masterRestaurentStyleBridg, IVendorBridg vendorBridg)
        {
            this._masterRestaurentStyleBridg = masterRestaurentStyleBridg;
            this._vendorBridg = vendorBridg;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VendorList()
        {
            if (Session["UserId"] != null && (string)Session["UserName"] == "Admin")
                return View();

            return RedirectToAction("Login", "Login", new { Area = "Account" });

        }

        public ActionResult AddVendor()
        {
            if (Session["UserId"] != null && (string)Session["UserName"] == "Admin")
            {

                ViewBag.Styles = _masterRestaurentStyleBridg.GetAll();

                var enumWeakDay = from Utility.Enums.WeakDays e in Enum.GetValues(typeof(Utility.Enums.WeakDays))
                                  select new
                                  {
                                      ID = (int)e,
                                      Day = e.ToString()
                                  };
                ViewBag.EnumListWeakDays = new SelectList(enumWeakDay, "ID", "Day");

                var enumWeakEnd = from Utility.Enums.WeakEnd e in Enum.GetValues(typeof(Utility.Enums.WeakEnd))
                                  select new
                                  {
                                      ID = (int)e,
                                      Day = e.ToString()
                                  };
                ViewBag.EnumListWeakEnd = new SelectList(enumWeakEnd, "ID", "Day");
                return View();
            }


            return RedirectToAction("Login", "Login", new { Area = "Account" });

        }

        public JsonResult SaveVendor(VendorViewModel vendorViewModel, HttpPostedFileBase[] files)
        {

            string[] filePath = new string[6];
            for (int iCount = 0; iCount < 3; iCount++)
            {
                if (Request.Files[iCount] != null)
                {
                    var file = Request.Files[iCount];

                    if (file != null && file.ContentLength > 0)
                    {
                        string pic = Path.GetFileName(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/Image/"), pic);
                        file.SaveAs(path);
                        filePath[iCount]=path;
                       
                    }
                }
            }

           
            if (ModelState.IsValid)
            {
                vendorViewModel.MainImagePath = filePath[0];
                vendorViewModel.OtherImagePath = filePath[1];
                vendorViewModel.LogoPath = filePath[2];
                _vendorBridg.InsertVendor(vendorViewModel);
                return Json("", JsonRequestBehavior.AllowGet);

            }




            return Json("", JsonRequestBehavior.AllowGet);


        }
    }
}
