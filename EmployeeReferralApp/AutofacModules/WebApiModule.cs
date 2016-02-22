using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace EmployeeReferralApp.AutofacModules
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterApiControllers(ThisAssembly);

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            //builder.Register(c => new WebApiUnitOfWorkActionFilter())
            //    .AsWebApiActionFilterFor<ObservationController>()
            //    .PropertiesAutowired()
            //    .InstancePerRequest();
        }
    }
}