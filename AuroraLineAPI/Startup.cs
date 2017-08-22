using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(AuroraLineAPI.Startup))]

namespace AuroraLineAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);
        }

        private void ConfigureAutofac(IAppBuilder app)
        {
            var config = new ConfigurationBuilder();

            //參數是與root路徑相對的位置
            config.AddJsonFile("Modules/Settings/AutofacModule.json");

            //透過Config產生Module
            var module = new ConfigurationModule(config.Build());

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //將Module註冊到Container內
            builder.RegisterModule(module);

            var autofacResolver = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(autofacResolver);

            var container = builder.Build();
            autofacResolver.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}