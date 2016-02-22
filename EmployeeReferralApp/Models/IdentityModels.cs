using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using EmployeeReferral.Domain.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EmployeeReferralApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public Employee Employee { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbConnectionString", throwIfV1Schema: false)
        {
        }

        public ApplicationDbContext(string connectionString)
            :base(connectionString)
        {
            
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobRequisition> JobRequisitions { get; set; }
        public DbSet<Referral> Referrals { get; set; }

    }
}