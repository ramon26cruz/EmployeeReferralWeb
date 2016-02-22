using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using EmployeeReferralApp.Models;

namespace EmployeeReferralApp.Data
{
    public class ApplicationDbConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = typeof(ApplicationDbContext).Name;
            MigrationsDirectory = @"Data\Migrations";
        }
    }
}