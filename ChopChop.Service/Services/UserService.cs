using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.Repository;
using ChopChop.Entity.EntityFramework;

namespace ChopChop.Service
{
    public class UserService: GenericRepository<User>, IUserService
    {
        IGenericRepository<User> repoUser = new GenericRepository<User>();
        IGenericRepository<DeviceLoginDetail> repoUserDeviceLoginDetail = new GenericRepository<DeviceLoginDetail>();
        IGenericRepository<SignUpOTP> repoOTP = new GenericRepository<SignUpOTP>();
        /// <summary>
        /// Function to Insert data into Admin table in database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertUser(User entity)
        {
            bool isInserted = false;
            try
            {
                repoUser.Add(entity);
                isInserted = true;
            }
            catch (Exception ex)
            {
                isInserted = false;
            }

            return isInserted;
        }

        public User Login(User entity)
        {
            return repoUser.GetAll().Where(x => x.UserName == entity.UserName && x.Password == entity.Password).FirstOrDefault();
        }

        /// <summary>
        /// Get List of all User
        /// </summary>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            return repoUser.GetAll().FirstOrDefault(x=>x.UserID==userId);
        }

        public DeviceLoginDetail GetDeviceDetail(int userId)
        {
            return repoUserDeviceLoginDetail.GetAll().FirstOrDefault(x => x.UserId == userId);
        }

        public User GetUserByUserNamePassword(string userName,string password)
        {
            return repoUser.GetAll().Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            //return repoUser.GetAll().FirstOrDefault(x => x.UserName == userName && x.Password == password && x.IsActive == true);
        }

        public bool InsertOTP(string mobile, string OTP)
        {
            bool isInserted = false;
            try
            {
                SignUpOTP objOTP = new SignUpOTP();
                objOTP.MobileNumber = mobile;
                objOTP.OTP = OTP;
                objOTP.IsVerified = false;
                repoOTP.Add(objOTP);

                isInserted = true;
            }
            catch (Exception ex)
            {
                isInserted = false;
            }

            return isInserted;
        }

        public bool VerifyOTP(string mobile, string OTPValue)
        {
            bool isVerified = false;
            try
            {
                var objRecord = repoOTP.FindBy(x => x.MobileNumber == mobile && x.OTP == OTPValue).FirstOrDefault();
                if (objRecord != null)
                {
                    isVerified = true;
                    objRecord.IsVerified = true;
                    repoOTP.Edit(objRecord);
                }
                else
                    isVerified = false;
            }
            catch (Exception ex)
            {
                isVerified = false;
            }

            return isVerified;
        }

        public bool InsertDeviceDetail(DeviceLoginDetail devicedetails)
        {
            bool isInserted = false;
            try
            {
                repoUserDeviceLoginDetail.Add(devicedetails);
                isInserted = true;
            }
            catch (Exception ex)
            {
                isInserted = false;
            }

            return isInserted;
        }

        public bool UpdateDeviceDetailToken(int userID, string token)
        {
            bool isUpdated = false;
            try
            {
                var objUser = repoUser.FindBy(x => x.UserID == userID).FirstOrDefault();
                objUser.AccessToken = token;
                repoUser.Edit(objUser);

                var deviceDetail = repoUserDeviceLoginDetail.FindBy(x => x.UserId == userID).FirstOrDefault();
                deviceDetail.AccessToken = token;
                repoUserDeviceLoginDetail.Edit(deviceDetail);

                isUpdated = true;

            }
            catch (Exception ex)
            {
                isUpdated = false;
            }

            return isUpdated;
        }
    }
}
