using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChopChop.Bridg;
using ChopChopApi.Models;
using ChopChopApi.App_Start;

namespace ChopChop.WebAPI.Controllers
{
    public class ChopChopWebAPIController : ApiController
    {
        IUserBridg userBridg;

        public ChopChopWebAPIController()
        {
           // this.userBridg = new UserBridg();
        }

        public bool Login(LoginModel model)
        {
            return true;
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public ServiceResponseModel Login(string userName, string password)
        {
            var validUser = userBridg.GetUserByUserNamePassword(userName, password);
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
    }
}
