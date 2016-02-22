using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using EmployeeReferralApp.Data;
using EmployeeReferralApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EmployeeReferralApp.Infrastructure.Migrations
{
    public class ApplicationDbContextFactory
    {
        private readonly ApplicationDbContextPopulator _dataBasePopulator;
        private readonly object _mutex = new object();
        private readonly List<string> _migrationExecuted = new List<string>();

        public ApplicationDbContextFactory(ApplicationDbContextPopulator dataBasePopulator)
        {
            _dataBasePopulator = dataBasePopulator;
        }

        public ApplicationDbContext Create(string connectionString, bool runMigration)
        {
            if (runMigration) EnsureMigrationsExecuted(connectionString);
            return new ApplicationDbContext(connectionString);
        }

        private void EnsureMigrationsExecuted(string connectionString)
        {
            if (_migrationExecuted.Contains(connectionString)) return;
            lock (_mutex)
            {
                if (_migrationExecuted.Contains(connectionString)) return;

                var configuration = new ApplicationDbConfiguration
                {
                    TargetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient")
                };

                var migrator = new DbMigrator(configuration);
                migrator.Update();
                _migrationExecuted.Add(connectionString);

                using (var context = new ApplicationDbContext(connectionString))
                {
                    _dataBasePopulator.Seed(context);
                    context.SaveChanges();
                }

            }
        }
    }

    public class ApplicationDbContextPopulator
    {
        private UserManager<ApplicationUser> _userManager;
        private string _password;
        private RoleManager<IdentityRole> _roleManager;

        public void Seed(ApplicationDbContext context)
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            _userManager.UserValidator = new UserValidator<ApplicationUser>(_userManager) { AllowOnlyAlphanumericUserNames = false };
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //Ensure admin account is there and has all roles
            //InitializeIdentityForEf();

            //only seed if database is empty
            //if (!context.Projects.Any())
            //{
            //    damTypesData = new DamTypeTestData();
            //    ProvisionUser();
            //    ProvisionDamTypes(context);
            //    ProvisionProject(context);
            //}
        }
    }
}