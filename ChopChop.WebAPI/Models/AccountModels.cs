using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ChopChopApi.Models
{
    public class SignupModel
    {
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public int deviceid { get; set; }
        public int deviceType { get; set; }
        public string AppVersion { get; set; }
        public int OSVersion { get; set; }
        public int langID { get; set; }
        public int OTPCode { get; set; }
        
    }

    public class LoginModel
    {
        public string Mobilenumber { get; set; }
        public string password { get; set; }
        public int deviceid { get; set; }
        public int deviceType { get; set; }
        public string AppVersion { get; set; }
        public string OSVersion { get; set; }
        public int langID { get; set; }
        
    }
}