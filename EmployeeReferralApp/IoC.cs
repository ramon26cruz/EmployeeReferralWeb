using Autofac;
using Autofac.Integration.Mvc;
using EmployeeReferralApp.AutofacModules;

namespace EmployeeReferralApp
{
    public class IoC
    {
        public static IContainer LetThereBeIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new MvcModule()); // Required by MVC. 

            builder.RegisterAssemblyModules(typeof(ContainerConfig).Assembly);
            builder.RegisterModule(new AutofacWebTypesModule());

            return builder.Build();
        }
    }
}