using ChopChop.Entity.EntityFramework;
using ChopChop.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.Bridg.IBridg
{
    public interface IUserBridg
    {
        UserModel InsertUser(UserModel model);
        User GetUser(int userId);
        UserModel GetUserByUserNamePassword(string userName, string password);
        UserDetailModel GetUserByUserNamePassword(string userName, string password, string deviceId);

        bool InsertOTP(string mobile, string OTP);

        bool VerifyOTP(string mobile, string OTP);

        //int UpdateUserToken(int userID, string token);

        bool UpdateDeviceDetailToken(int userID, string token);
        //List<ResultSearchRestaurants> SearchRestaurants(SearchResturant searchResturant);
        int UpdateAccessToken(int userId, string accessToken);
    }
}
