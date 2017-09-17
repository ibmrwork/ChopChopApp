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
        ServiceResponseModel responseModel= new ServiceResponseModel();
       
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
                //PhoneNumber = objSignupModel.MobileNumber,
                //CreatedDate = DateTime.Now,
                //ModifiedDate = DateTime.Now,
                //Password = objSignupModel.Password,
            };
            int userId=userBridg.InsertUser(viewModel);
            if (userId > 0)
            {
                responseModel.lsSuccess = true;
                responseModel.Message = "User Registered Successfully";
                
            }
            return responseModel;
        }

        

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public ServiceResponseModel Login(string userName,string password)
        {
            var validUser= userBridg.GetUserByUserNamePassword(userName, password);
            if (validUser != null && validUser.UserName.ToLower() == userName.ToLower())
            {
                var newToken = KeyGenerator.GenerateToken(validUser);
                return new ServiceResponseModel() { Message = newToken };
            }
            else
            {
                return new ServiceResponseModel() { Message = "Invalid username or password" };
            }
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public ServiceResponseModel RequestOTP(string Mobilenumber)
        {

                var newOTP = KeyGenerator.generateOTP();
                return new ServiceResponseModel() { Message = newOTP };
        }
    }
}
