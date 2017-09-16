using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.Utility
{
    public class GlobalConstant
    {
        public const string ErrorPath = "\\ErrorLog";
        public const int PageSize = 10;
    }
    public class GlobalMessages
    {
        public const string PasswordNotExist = "Current password not existed";
        public const string InvalidUser = "Invalid user";
        public const string InvalidUserPassword = "Invalid email or password";
    }

    public static class GlobalPageTitle
    {
        public const string CompanyProfile = "Company Profile";
        public const string Proposals = "Proposals";
    }
}
