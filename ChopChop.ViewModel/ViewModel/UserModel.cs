using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.ViewModel
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public string EmailAddress { get; set; }
        public bool RememberMe { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeID { get; set; }
        public bool PaymentVerified { get; set; }
        public string ProfileImagePath { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
       
        public int deviceid { get; set; }
        public int deviceType { get; set; }
        public string AppVersion { get; set; }
        public int OSVersion { get; set; }
        public int langID { get; set; }
        public int OTPCode { get; set; }


    }

    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
        public UserDetailModel UserDetailModel { get; set; }

    }
    public class UserDetailModel
    {
        public string FullName { get; set; }
        public int UserId { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string ProfilePic { get; set; }
        public List<AddressModel> UserAddress { get; set; }
        public int UserPreference { get; set; }
        public string LanguagePreference { get; set; }
        public List<SoldOptions> SoldOptions { get; set; }
        public string UserName { get; set; }

    }
    public class AddressModel
    {
        public string City { get; set; }
        public string AddressDetail { get; set; }
    }
    public class SoldOptions
    {
        public int SoldId { get; set; }
        public string Title { get; set; }
    }

    public class UserSoldOptionPref
    {
        public int UserID { get; set; }
        public int? SoldOutItemType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
