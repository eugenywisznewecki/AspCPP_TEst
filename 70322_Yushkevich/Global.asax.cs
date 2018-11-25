using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Ninject;                               //Lab4
using Ninject.Web.Common.WebHost;            //Lab4
using _70322_Yushkevich.DAL;                //Lab4
using _70322_Yushkevich.DAL.Interfaces;     //Lab4
using _70322_Yushkevich.DAL.Entities;       //Lab4
using _70322_Yushkevich.DAL.Repositories;   //Lab4


namespace _70322_Yushkevich
{ 
    public class MvcApplication : NinjectHttpApplication     //Lab4
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()            //Lab4
        {
            IKernel kernel = new StandardKernel();
            //kernel.Bind<IRepository<Dish>>().To<FakeRepository>();
            kernel
                .Bind<IRepository<Dish>>()
                .To<EFDishRepository>();    //Lab4
            return kernel;
        }
    }
}
