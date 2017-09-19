using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.EntityFramework;
using ChopChop.Entity.Repository;

namespace ChopChop.Service
{
    public interface IUserService : IGenericRepository<User>
    {
        bool InsertUser(User entity);
        User Login(User entity);
        User GetUser(int userId);
        DeviceLoginDetail GetDeviceDetail(int userId);
        User GetUserByUserNamePassword(string userName, string password);
        bool InsertOTP(string mobile, string OTP);
        bool VerifyOTP(string mobile, string OTP);

        bool InsertDeviceDetail(DeviceLoginDetail devicedetails);

        bool UpdateDeviceDetailToken(int userID, string token);
    }
}
