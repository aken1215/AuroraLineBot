using AuroraLineAPI.Repositories.AuroraLineBot;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.Modules
{
    public class RepositoryModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AuroraLineBotRepository>().As<IAuroraLineBotRepository>().InstancePerRequest();
        }
    }
}