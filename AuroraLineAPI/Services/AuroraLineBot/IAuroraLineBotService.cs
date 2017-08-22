using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AuroraLineAPI.AuroraLine.ViewModels;

namespace AuroraLineAPI.Services.AuroraLineBot
{
    public interface IAuroraLineBotService
    {
        Task CreateLineUserInfo(AuroraLineViewModel model);
        Task UpdateLineUserInfo(AuroraLineViewModel model);
        Task<AuroraLineViewModel> GetLineUserInfo(string id);
    }
}