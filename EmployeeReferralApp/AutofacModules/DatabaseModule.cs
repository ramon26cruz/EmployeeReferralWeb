using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Autofac;
using EmployeeReferralApp.ConfigurationSettings;
using EmployeeReferralApp.Infrastructure.Migrations;
using EmployeeReferralApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EmployeeReferralApp.AutofacModules
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            base.Load(builder);

            Database.SetInitializer(new NullDatabaseInitializer<ApplicationDbContext>());

            builder.RegisterType<ApplicationDbContextFactory>()
                .SingleInstance();

            builder.RegisterType<ApplicationDbContextPopulator>()
                .SingleInstance();

            builder.Register(c =>
            {
                var factory = c.Resolve<ApplicationDbContextFactory>();
                var connectionString = c.Resolve<ApplicationDbConnectionString>();
                return factory.Create(connectionString, false);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UserManager<ApplicationUser>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerLifetimeScope();
            builder.Register(delegate(IComponentContext c)
            {
                var context = c.Resolve<ApplicationDbContext>();
                return new UserStore<ApplicationUser>(context);
            })
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}