using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChopChop.Bridg;
using ChopChopApi.Models;

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


    }
}
