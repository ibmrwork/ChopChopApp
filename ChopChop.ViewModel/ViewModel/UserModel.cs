using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.ViewModel
{
    public class UserModel
    {
        public bool RememberMe { get; set; }
        public string EmailID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeID { get; set; }
        public bool PaymentVerified { get; set; }
        public string ProfileImagePath { get; set; }
        public string Username { get; set; }
    }
}
