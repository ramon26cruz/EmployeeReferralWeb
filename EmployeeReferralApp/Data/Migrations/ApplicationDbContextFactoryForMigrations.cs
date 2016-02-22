using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using ConfigInjector.QuickAndDirty;
using EmployeeReferralApp.ConfigurationSettings;
using EmployeeReferralApp.Models;

namespace EmployeeReferralApp.Data.Migrations
{
    public class ApplicationDbContextFactoryForMigrations : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            var connectionString = DefaultSettingsReader.Get<ApplicationDbConnectionString>();
            return new ApplicationDbContext(connectionString);
        }
    }
}