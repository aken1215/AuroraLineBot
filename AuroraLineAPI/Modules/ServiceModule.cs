using AuroraLineAPI.Services.AuroraLineBot;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.Modules
{
    public class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AuroraLineBotService>().As<IAuroraLineBotService>().InstancePerRequest();
        }
    }
}