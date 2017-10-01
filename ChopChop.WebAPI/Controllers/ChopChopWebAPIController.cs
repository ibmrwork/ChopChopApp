using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChopChop.Bridg;
using ChopChopApi.Models;
using ChopChopApi.App_Start;
using System.Data.SqlClient;
using System.Configuration;
using ChopChop.ViewModel;
using ChopChop.IBridg;
using ChopChop.Bridg.IBridg;
using ChopChop.Utility;
using ChopChop.ViewModel.ViewModel;
using ChopChop.Bridg.Bridg;

namespace ChopChop.WebAPI.Controllers
{
    public class ChopChopWebAPIController : ApiController
    {
        IUserBridg userBridg;
        IVendorBridg vendorBridg;
        ISoldOutBridg soldOutBridg;
        ServiceResponseModel responseModel = new ServiceResponseModel();

        public ChopChopWebAPIController()
        {
            this.userBridg = new UserBridg();
            this.vendorBridg    = new VendorBridg();
            this.soldOutBridg = new SoldOutBridg();
        }
            
        //public bool Login(LoginModel model)
        //{
        //    return true;
        //}

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        //[HttpPost]
        [Route("api/ChopChopWebAPI/Login")]
        public ServiceResponseModel Login(LoginModel loginModel)
        {
            var encryptedPassword = HelperClass.base64Encode(loginModel.password);
            var validUser = userBridg.GetUserByUserNamePassword(loginModel.UserName, encryptedPassword,loginModel.deviceid);

            if (validUser != null && validUser.UserName.ToLower() == loginModel.Mobilenumber.ToLower())
            {
                var newToken = KeyGenerator.GenerateToken(validUser,loginModel.deviceid);
                userBridg.UpdateAccessToken(validUser.UserId, newToken);
                return new ServiceResponseModel() { Message = newToken, ResponseData=new LoginResponseModel
                {
                    AccessToken=newToken, UserDetailModel=validUser
                }, lsSuccess=true };
            }
            else
            {
                return new ServiceResponseModel() { Message = "Invalid username or password" };
            }
        }

        [Route("api/ChopChopWebAPI/SearchRestaurants")]
        [HttpPost]
        public ServiceResponseModel SearchRestaurants(SearchResturant searchResturant)     
        {
            ServiceResponseModel objServiceResponseModel = new ServiceResponseModel();
            try {
                objServiceResponseModel.lsSuccess = true;
               objServiceResponseModel.ResponseData= vendorBridg.SearchRestaurants(searchResturant);
               objServiceResponseModel.Message = "Success";
            }
            catch (Exception ex)
            {
                objServiceResponseModel.lsSuccess = false;
                objServiceResponseModel.Message = "Some error occur";
            }
            return objServiceResponseModel;
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        //[HttpPost]
        [Route("api/ChopChopWebAPI/GetSoldOutOptions")]
        public ServiceResponseModel GetSoldOutOptions(SoldOptionsRequest soldRequest)
        {
            var soldOutOptions = soldOutBridg.GetSoldOutMasterOptions().ToDictionary(x => x.TypeID, x => x.Name);

            return new ServiceResponseModel()
            {
                Message = "",
                ResponseData = new SoldOptionsResponse
                {
                    Success = 1,
                    SoldoutDataOptions = soldOutOptions
                },
                lsSuccess = true
            };

        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        //[HttpPost]
        [Route("api/Authenticate/SaveSoldOutOption")]
        public ServiceResponseModel SaveSoldOutOption(SaveSoldOptionsRequest soldRequest)
        {

            UserSoldOptionPref model = new UserSoldOptionPref
            {
                SoldOutItemType = soldRequest.SoldOutId,
                UserID = soldRequest.UserId,
            };
            int result = soldOutBridg.SaveSoldOutOption(model);
            return new ServiceResponseModel()
            {
                Message = "User SoldoutOption Preference saved successfully",
                ResponseData = "{'success':" + result + "}",
                lsSuccess = true
            };
        }
    }
}
