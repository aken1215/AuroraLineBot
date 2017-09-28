using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AuroraLineAPI.AuroraLine.ViewModels;
using AuroraLineAPI.Models;
using AuroraLineAPI.ViewModels.AuroraLineBot;

namespace AuroraLineAPI.Services.AuroraLineBot
{
    public interface IAuroraLineBotService
    {
        Task CreateLineUserInfo(AuroraLineViewModel model);

        Task UpdateLineUserInfo(AuroraLineViewModel model);

        Task<AuroraLineViewModel> GetLineUserInfo(string id);



        Task AddPendingRequest(string id);

        Task<int> ClosePendingRequest(string id);

        Task EngageRequest(string pendingId);

        Task<string> GetEngageRequest(string id);

        Task<int> GetUserStatus(string id);

        Task UpdateUserStatus(string id, UserInfoStatus status);
        Task<IEnumerable<AuroraLineViewModel>> GetAllUserInfo();
        Task PostConversation(ConversationViewModel model);
    }
}