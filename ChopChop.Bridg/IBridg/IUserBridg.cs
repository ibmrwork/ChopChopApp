using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.Repository;
using ChopChop.ViewModel;
using ChopChop.Entity.EntityFramework;

namespace ChopChop.Bridg
{
    public interface IUserBridg
    {
        UserModel InsertUser(UserModel model);
        User GetUser(int userId);
        UserModel GetUserByUserNamePassword(string userName, string password);

        bool InsertOTP(string mobile, string OTP);

        bool VerifyOTP(string mobile, string OTP);

        //int UpdateUserToken(int userID, string token);

        bool UpdateDeviceDetailToken(int userID, string token);
    }
}
