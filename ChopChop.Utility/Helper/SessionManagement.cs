
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http.Results;
using ChopChop.ViewModel;

namespace ChopChop.Utility
{
    public class SessionManagement
    {
        //set the login status in session for the current user.
        public static void setIsLoggedIn(bool value)
        {
            //value is true when the the usser logs in
            HttpContext.Current.Session["isLoggedIn"] = value;
            //value is false when the the usser logsout
            if (!value)
                HttpContext.Current.Session["isLoggedIn"] = null;
        }

        //check to see if the user is logged in

        public static bool isLoggedIn()

        {

            if (HttpContext.Current.Session["isLoggedIn"]==null)

                return false;

            else

                return true;

        }



        //set current employee in the sessoin

        public static void setCurrentUser(UserModel value)

        {

            HttpContext.Current.Session["UserProfile"] = value;

            if (value != null)

            {

                //following variables are set separately to be used in bindable control like

                //GridView, DataList etc..

                HttpContext.Current.Session["LogedUserID"] = value.UserID;

                HttpContext.Current.Session["LogedUsername"] = value.FirstName + " " + value.LastName;
                HttpContext.Current.Session["UserTypeID"] = value.UserTypeID;
                HttpContext.Current.Session["UserVerified"] = value.PaymentVerified;
                HttpContext.Current.Session["UserProfileImage"] = value.ProfileImagePath;
                // UserTypes userType = (UserTypes)Convert.ToInt32(HttpContext.Current.Session["UserTypeID"]);
                HttpContext.Current.Session["UserType"] = "";// userType.ToString();

                // saving common user info in session
                var profileData = new UserModel
                {
                    UserID = value.UserID,
                    Username = value.Username,
                    UserTypeID = value.UserTypeID,
                    
                    EmailID=value.EmailID,
                    FirstName=value.FirstName,
                    LastName=value.LastName
                };

                HttpContext.Current.Session["UserProfile"] = profileData;

            }

        }



        //get current employee fro the session

        public static UserModel getCurrentUser()

        {

            return (UserModel)HttpContext.Current.Session["UserProfile"];

        }

        public static int getCurrentUserID()
        {
            if (HttpContext.Current.Session["LogedUserID"] != null)
            {
                return (int)HttpContext.Current.Session["LogedUserID"];
            }
            else
                return 0;
        }

        //bonus functions – to be used on the pages where it is neccessary for the users to login

        public static void setRedirectUrl(string redirectURL)
        {
            HttpContext.Current.Session["redirectURL"] = redirectURL;
        }



        //bonus functions – once the users log in, they will be redirected back to the previously

        //stored url or redirected to the default page

        //public static string getRedirectUrl()

        //{

        //    if (object.Equals(HttpContext.Current.Session["redirectURL"], null))

        //        return new RedirectResult(Url.Action("Login", "Account", new { @area = "Account" }));

        //    else

        //    return HttpContext.Current.Session["redirectURL"].ToString();

        //}
    }
}