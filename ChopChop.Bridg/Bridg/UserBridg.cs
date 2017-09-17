using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.EntityFramework;
using ChopChop.Service;
using ChopChop.ViewModel;

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
        public int InsertUser(UserModel model)
        {
            try
            {
                User entity = new User
                {
                    //CreatedDate = model.CreatedDate,
                    //EmailAddress = model.EmailAddress,
                    //AccessToken = model.AccessToken,
                    //AccessLevel = model.AccessLevel,
                    //FirstName = model.FirstName,
                    //IsActive = model.IsActive,
                    //IsDeleted = model.IsDeleted,
                    //LastName = model.LastName,
                    //ModifiedDate = model.ModifiedDate,
                    //ModifiedBy = model.ModifiedBy,
                    //Password = model.Password,
                    //PhoneNumber = model.PhoneNumber,
                    //ProfileImagePath = model.ProfileImagePath,
                    //RoleID = model.RoleID,
                    //TimeZone = model.TimeZone,
                    //UserName = model.UserName,

                };

                _userService.InsertUser(entity);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
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
    }
}
