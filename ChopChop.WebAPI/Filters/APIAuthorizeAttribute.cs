using ChopChop.Bridg;
using ChopChop.Bridg.IBridg;
using ChopChopApi.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ChopChop.Filters
{
    public class APIAuthorizeAttribute : AuthorizeAttribute
    {
       // private DatabaseContext db = new DatabaseContext();
        IUserBridg _userBridg;
        public APIAuthorizeAttribute() {
            this._userBridg = new UserBridg();
        }
       
        //public APIAuthorizeAttribute(IUserBridg userBridg)
        //{
        //    this._userBridg = userBridg;
        //}
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                var encodedString = actionContext.Request.Headers.GetValues("Token").First();

                bool validFlag = false;

                if (!string.IsNullOrEmpty(encodedString))
                {
                    var key = EncryptionLibrary.DecryptText(encodedString);

                    string[] parts = key.Split(new char[] { ':' });

                    int userId = Convert.ToInt32(parts[0].ToString());
                    var user = _userBridg.GetUser(userId);

                    if (user != null && user.UserID == userId)
                   {
                       validFlag = true;
                   }
                   else
                   {
                       validFlag = false;
                   }

                 
                }
                return validFlag;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}