using AuroraLineAPI.Repositories.AuroraLineBot;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuroraLineAPI.AuroraLine.ViewModels;
using System.Threading.Tasks;
using System.Configuration;
using AuroraLineAPI.Models;

namespace AuroraLineAPI.Services.AuroraLineBot
{
    public class AuroraLineBotService:IAuroraLineBotService
    {
        private IAuroraLineBotRepository AuroraLineBotRepository;
        private IMapper Mapper;

        public AuroraLineBotService(IAuroraLineBotRepository auroraLineBotRepository,IMapper mapper)
        {
            this.AuroraLineBotRepository = auroraLineBotRepository;

            this.Mapper = mapper;
        }

        public async Task CreateLineUserInfo(AuroraLineViewModel auroraLineViewModel)
        {
            var model = this.Mapper.Map<UserInfo>(auroraLineViewModel);
            await this.AuroraLineBotRepository.CreateLineUserInfo(model);
        }

        public async Task<AuroraLineViewModel> GetLineUserInfo(string id)
        {
            var model = await this.AuroraLineBotRepository.GetLineUserInfo(id);

            var result = this.Mapper.Map<AuroraLineViewModel>(model);

            return result;
        }

        public async Task UpdateLineUserInfo(AuroraLineViewModel auroraLineViewModel)
        {
            var model = this.Mapper.Map<UserInfo>(auroraLineViewModel);
            await this.AuroraLineBotRepository.UpdateLineUserInfo(model);
        }
    }
}