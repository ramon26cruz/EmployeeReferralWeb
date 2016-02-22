using System;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace EmployeeReferralApp
{
    public class ContainerConfig
    {
        private static IContainer _container;
        public static void Configure()
        {
            _container = IoC.LetThereBeIoC();
            //// Setup global sitemap loader
            //MvcSiteMapProvider.SiteMaps.Loader = _container.Resolve<ISiteMapLoader>();

            //// Check all configured .sitemap files to ensure they follow the XSD for MvcSiteMapProvider
            //var validator = _container.Resolve<ISiteMapXmlValidator>();
            //validator.ValidateXml(HostingEnvironment.MapPath("~/Mvc.sitemap"));

            //// Register the Sitemaps routes for search engines
            //XmlSiteMapController.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
        }
        public static void TearDown()
        {
            _container.Dispose();
        }
    }
}