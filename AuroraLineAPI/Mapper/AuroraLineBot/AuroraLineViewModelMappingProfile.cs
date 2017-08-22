using AuroraLineAPI.AuroraLine.ViewModels;
using AuroraLineAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.Mapper.AuroraLineBot
{
    public class AuroraLineViewModelMappingProfile:Profile
    {
        public AuroraLineViewModelMappingProfile()
        {
            this.CreateMap<AuroraLineViewModel, UserInfo>();
            this.CreateMap<UserInfo, AuroraLineViewModel>();
        }
    }
}