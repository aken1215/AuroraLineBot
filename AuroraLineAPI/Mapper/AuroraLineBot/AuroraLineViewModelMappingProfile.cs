using AuroraLineAPI.AuroraLine.ViewModels;
using AuroraLineAPI.Models;
using AuroraLineAPI.ViewModels.AuroraLineBot;
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
            this.CreateMap<ConversationViewModel, Conversation>();
            this.CreateMap<UserInfo, AuroraLineViewModel>().AfterMap((userinfo,auroraLine)=>
            {
                switch (userinfo.Status)
                {
                    case 0:
                        auroraLine.Status = "填寫姓名";
                        break;
                    case 1:
                        auroraLine.Status = "填寫電話";
                        break;
                    case 2:
                        auroraLine.Status = "填寫單位";
                        break;
                    case 3:
                        auroraLine.Status = "填寫信箱";
                        break;
                    case 4:
                        auroraLine.Status = "未領禮物";
                        break;
                    case 5:
                        auroraLine.Status = "已領取";
                        break;
                }

            });
        }
    }
}