using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChopChopApi.Models
{
    public class ServiceResponseModel
    {
        public string Message { get; set; }
        public bool lsSuccess { get; set; }
        public object ErrorCode { get; set; }
        public object ResponseData { get; set; }
        public string userid { get; set; }
        public string authToken { get; set; }
    }
}