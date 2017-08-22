using AuroraLineAPI.Mapper.AuroraLineBot;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.Modules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register(componentContext =>
            {
                var auroraLineMapperProfile = new AuroraLineViewModelMappingProfile();

                var config = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.AddProfile(auroraLineMapperProfile);
                    });
                var mapper = config.CreateMapper();

                return mapper;
            }).As<IMapper>();
        }
    }
}