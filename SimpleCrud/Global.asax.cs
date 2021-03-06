﻿using Ninject;
using SimpleCrud.Controllers;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using SimpleCrud.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleCrud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var kernel = new StandardKernel();
            AddBindings(kernel);
            
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void AddBindings(IKernel kernel)
        {
            kernel.Bind<IValidator<AddUserModel>>().To<AddUserModelValidator>();
            kernel.Bind<IValidator<EditUserModel>>().To<EditUserModelValidator>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<PersonController>().To<PersonController>();
        }
    }
}
