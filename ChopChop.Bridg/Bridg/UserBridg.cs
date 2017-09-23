using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.EntityFramework;
using ChopChop.Service;
using ChopChop.ViewModel;
using ChopChop.Utility;
using ChopChop.Bridg.IBridg;

namespace ChopChop.Bridg
{
    public class UserBridg : IUserBridg
    {
        readonly IUserService _userService;
        public UserBridg()
        {
            _userService = new UserService();
        }

        public UserBridg(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Insert Admin detail in AdminUser table in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserModel InsertUser(UserModel model)
        {
            try
            {
                var encryptedPassword = HelperClass.base64Encode(model.Password);
                User entity = new User
                {
                    CreatedDate = model.CreatedDate,
                    EmailAddress = model.EmailAddress,
                    //AccessToken = model.AccessToken,
                    //AccessLevel = model.AccessLevel,
                    FirstName = model.FirstName,
                    IsActive = true,
                    IsDeleted = false,
                    LastName = model.LastName,
                    ModifiedDate = model.ModifiedDate,
                    ModifiedBy = 1,
                    Password = encryptedPassword,
                    PhoneNumber = model.PhoneNumber,
                    RoleID = (int)ChopChop.Utility.Enums.UserTypes.Customer

                };

                _userService.InsertUser(entity);

                DeviceLoginDetail objDeviceDetail = new DeviceLoginDetail
                {
                    UserId=entity.UserID,
                    CreatedDate = model.CreatedDate,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedDate = model.ModifiedDate,
                    ModifiedBy = 1,
                    DeviceType=Convert.ToString(model.deviceType),
                    AppVersion=Convert.ToString(model.AppVersion),
                    OSVersion=Convert.ToString(model.OSVersion)

                };

                _userService.InsertDeviceDetail(objDeviceDetail);

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public bool UpdateDeviceDetailToken(int userID, string token)
        {
            try
            {
                return _userService.UpdateDeviceDetailToken(userID, token);
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //public List<UserPrefrence> GetUserPreference(UserViewModel model)
        //{
        //    List<UserPrefrence> lstUserPreference = new List<UserPrefrence>();
        //    foreach (var item in model.UserPrefrence)
        //    {
        //        UserPrefrence userPref = new UserPrefrence
        //        {
        //            PreferredAddress=model.UserPrefrence.PreferredAddress,
        //            CreatedBy=model.CreatedBy,
        //            CreatedDate=model.CreatedDate,
        //            IsActive=model.IsActive,
        //            IsDeleted=model.IsDeleted,
        //            //LanguageID
        //            ModifiedBy=model.ModifiedBy,
        //            ModifiedDate=model.ModifiedDate,
        //            PreferredVendor=model.UserPrefrence.PreferredVendor,
        //            UserID=model.UserID                   
        //        };

        //        lstUserPreference.Add(item);
        //    }
        //    return null;
        //}

        public User GetUser(int userId)
        {
            return _userService.GetUser(userId);
        }

        public UserModel GetUserByUserNamePassword(string userName, string password)
        {
            UserModel objUserModel = new UserModel();
            var user = _userService.GetUserByUserNamePassword(userName, password);
            objUserModel.UserID = user.UserID;
            objUserModel.UserName = user.UserName;
            return objUserModel;
        }

        public UserDetailModel GetUserByUserNamePassword(string userName, string password, string deviceId)
        {
            return _userService.GetUserByUserNamePassword(userName, password, deviceId);

        }

        public bool InsertOTP(string mobile, string OTP)
        {
            
            return _userService.InsertOTP(mobile, OTP);
        }

        public bool VerifyOTP(string mobile, string OTP)
        {

            return _userService.VerifyOTP(mobile, OTP);
        }

        public int UpdateAccessToken(int userId, string accessToken)
        {
            return _userService.UpdateAccessToken(userId, accessToken);

        }
    }
}
