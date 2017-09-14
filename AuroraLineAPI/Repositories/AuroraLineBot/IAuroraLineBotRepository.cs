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

        Task<bool> IsEngaged(string id);

        Task AddPendingRequest(string id);

        Task<int> ClosePendingRequest(string id);

        Task EngageRequest(string pendingId);

        Task<string> GetEngageRequest(string id);

        Task<int> GetUserStatus(string id);

        Task UpdateUserStatus(string id, UserInfoStatus status);

        Task<IEnumerable<UserInfo>> GetAllUserInfo();
    }
}