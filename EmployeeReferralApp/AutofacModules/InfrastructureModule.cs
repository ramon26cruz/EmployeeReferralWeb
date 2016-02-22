using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using EmployeeReferralApp.Infrastructure.Services;

namespace EmployeeReferralApp.AutofacModules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<JWTTokenGenerator>()
              .As<ITokenGenerator>()
              .InstancePerDependency();
        }
    }
}