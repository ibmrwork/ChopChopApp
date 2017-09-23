using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using ChopChop.Service.IServices;
using ChopChop.Service;
using ChopChop.IBridg;
using ChopChop.Bridg;
using ChopChop.Bridg.IBridg;
namespace ChopChop.Web.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<IAdminBridg, AdminBridg>(new PerThreadLifetimeManager());
            container.RegisterType<IAdminService, AdminService>(new PerThreadLifetimeManager());
            container.RegisterType<IUserBridg, UserBridg>(new PerThreadLifetimeManager());
            container.RegisterType<IUserService, UserService>(new PerThreadLifetimeManager());
            container.RegisterType<IVendorService, IVendorService>(new PerThreadLifetimeManager());
            container.RegisterType<IVendorBridg, VendorBridg>(new PerThreadLifetimeManager());
            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }  
    }
}