using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using ChopChop.ViewModel;


namespace ChopChop.Utility
{
    public class MemberAuthentication
    {
        public static HttpCookie GetAuthenticationCookie(UserModel model)
        {
            // userData storing data in ticktet and then cookie 
            JavaScriptSerializer js = new JavaScriptSerializer();
            DateTime utcNow = DateTime.UtcNow;

            DateTime utcExpires = model.RememberMe
                ? utcNow.AddDays(1)
                : utcNow.AddMinutes(20);
            var userData = js.Serialize(model);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                     1,
                     model.EmailID,
                     DateTime.UtcNow,
                     DateTime.Now.AddHours(1),
                     model.RememberMe,
                     userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            cookie.Expires = authTicket.Expiration; //must do it for cookie expiration 
            return cookie;
        }
        
    }
}