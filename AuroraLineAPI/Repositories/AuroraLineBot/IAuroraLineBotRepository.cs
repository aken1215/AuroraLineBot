using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AuroraLineAPI.AuroraLine.ViewModels;
using AuroraLineAPI.Models;

namespace AuroraLineAPI.Repositories.AuroraLineBot
{
    public interface IAuroraLineBotRepository
    {
        Task CreateLineUserInfo(UserInfo model);

        Task UpdateLineUserInfo(UserInfo model);

        Task<UserInfo> GetLineUserInfo(string id);

        Task<bool> GetUserInfoGiftState(string id);
    }
}