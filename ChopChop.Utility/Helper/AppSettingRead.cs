using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;

namespace ChopChop.Utility
{
    public static class AppSettingRead
    {
        public static string SiteUrl
        {
            get {
                string host = HttpContext.Current.Request.Url.Host;
                string siteUrl = "";
                if(host.ToLower()=="localhost")
                {
                    siteUrl= ConfigurationManager.AppSettings["SiteUrlLocal"].ToString();
                }else
                if (host.ToLower() == "stagingwin")
                {
                    siteUrl = ConfigurationManager.AppSettings["SiteUrlStaging"].ToString();
                }
                else
                {
                    siteUrl = ConfigurationManager.AppSettings["SiteUrlLive"].ToString();
                }
                return siteUrl;
            }
        }
    }
}
