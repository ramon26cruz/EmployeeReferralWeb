using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using ConfigInjector.Configuration;
using EmployeeReferralApp.ConfigurationSettings;

namespace EmployeeReferralApp.AutofacModules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var webAssembly = typeof(MvcApplication).Assembly;

            ConfigurationConfigurator.RegisterConfigurationSettings()
                .FromAssemblies(webAssembly)
                .RegisterWithContainer(configSetting => builder.RegisterInstance(configSetting)
                    .AsSelf()
                    .SingleInstance())
                .AllowConfigurationEntriesThatDoNotHaveSettingsClasses(true)
                .DoYourThing();

            builder.RegisterType<JwtSettings>()
                .AsSelf()
                .SingleInstance()
                .PropertiesAutowired();


        }
    }
}