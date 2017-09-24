using ChopChop.Bridg;
using ChopChop.Bridg.IBridg;
using ChopChop.Service;
using ChopChop.Utility;
using ChopChop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChopChop.Web.Areas.Account.Controllers
{

    public class LoginController : Controller
    {
        IUserBridg _iuserBridg = null;
        public LoginController(IUserBridg iuserBridg)
        {
            this._iuserBridg = iuserBridg;
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            try
            {
                if (Session["UserId"] != null && ((string)Session["UserName"] == "Admin"))
                    return RedirectToAction("Dashboard", "Dashboard", new { area = "Admin" });

                return View();
            }
            catch (Exception ex) {
                throw ex;
            }
           
        }
        [HttpPost]
        public JsonResult Login(UserModel user)
        {
            try
            {
                if (user.UserName != null && user.Password != null)
                {
                    HelperClass.base64Encode(user.Password);
                    string password = HelperClass.base64Encode(user.Password);
                    user.Password = password;
                    var _user = _iuserBridg.GetUserByUserNamePassword(user.UserName, user.Password);

                    if (_user.RoleID == 1 && _user.IsActive == true)
                    {
                        Session["UserId"] = _user.UserID;
                        Session["UserName"] = _user.UserName;
                        return Json(_user.UserName);
                    }


                }
                return Json("Please fill your details correctly");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login",new {Areas="Account" });
        }
    }
}