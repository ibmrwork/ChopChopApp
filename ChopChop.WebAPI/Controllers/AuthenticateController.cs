using ChopChop.Filters;
using ChopChopApi.App_Start;
using ChopChopApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChopChop.Bridg;
using ChopChop.ViewModel;
using ChopChop.Bridg.IBridg;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ChopChopApi.Controllers
{
    // [APIAuthorizeAttribute]
    public class AuthenticateController : ApiController
    {
        //IAuthenticate _IAuthenticate;
        //public AuthenticateController()
        //{
        //    _IAuthenticate = new AuthenticateConcrete();
        //}

        // POST: api/Authenticate

        IUserBridg userBridg;
        
        ServiceResponseModel responseModel = new ServiceResponseModel();

        public AuthenticateController()
        {
            this.userBridg = new UserBridg();
        }

        // [APIAuthorizeAttribute]
        [HttpPost]
        public ServiceResponseModel Signup(SignupModel objSignupModel)
        {
            UserModel viewModel = new UserModel
            {
                PhoneNumber = objSignupModel.MobileNumber,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Password = objSignupModel.Password,
            };
            var userDetail = userBridg.InsertUser(viewModel);

            var newToken = KeyGenerator.GenerateToken(userDetail);

            if (userBridg.UpdateDeviceDetailToken(userDetail.UserID, newToken))
            {
                responseModel.lsSuccess = true;
                responseModel.Message = "200";
                responseModel.userid = Convert.ToString(userDetail.UserID);
                responseModel.authToken = newToken;
            }
            else
            {
                responseModel.lsSuccess = false;
                responseModel.Message = "100";
            }
            return responseModel;
        }



        //[System.Web.Http.AcceptVerbs("GET")]
        //[System.Web.Http.HttpGet]
        //public ServiceResponseModel Login(string userName, string password)
        //{
        //    var validUser = userBridg.GetUserByUserNamePassword(userName, password);
        //    if (validUser != null && validUser.UserName.ToLower() == userName.ToLower())
        //    {
        //        var newToken = KeyGenerator.GenerateToken(validUser);
        //        return new ServiceResponseModel() { Message = newToken };
        //    }
        //    else
        //    {
        //        return new ServiceResponseModel() { Message = "Invalid username or password" };
        //    }
        //}

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public ServiceResponseModel RequestOTP(string Mobilenumber)
        {

            var newOTP = KeyGenerator.generateOTP();


            var accountSid = "ACd1fbc9165a5a2ad6df57e01a9708b73b";
            // Your Auth Token from twilio.com/console
            var authToken = "f36bf5c18f293acd5bae1ff1f34d512b";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber(Mobilenumber    ),
                from: new PhoneNumber("+13219855413"),
                body: newOTP);

            userBridg.InsertOTP(Mobilenumber, newOTP);

            return new ServiceResponseModel() { lsSuccess=true };
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public ServiceResponseModel VerifyOTP(string Mobilenumber, string OTP)
        {
            bool isVerified = false;
            isVerified=userBridg.VerifyOTP(Mobilenumber, OTP);

            return new ServiceResponseModel() { lsSuccess = isVerified };
        }
    }
}
