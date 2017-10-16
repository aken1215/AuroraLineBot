using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AuroraLineAPI.Models;
using System.Data.Entity;
using AuroraLineAPI.AuroraLine.ViewModels;

namespace AuroraLineAPI.Repositories.AuroraLineBot
{
    public class AuroraLineBotRepository : IAuroraLineBotRepository
    {
        private AuroraLineDbContext AuroraLineDbContext;

        public AuroraLineBotRepository()
        {
            this.AuroraLineDbContext = new AuroraLineDbContext();
        }

        public async Task CreateLineUserInfo(UserInfo model)
        {
            this.AuroraLineDbContext.UserInfos.Add(model);
            await this.AuroraLineDbContext.SaveChangesAsync();
        }

        public async Task<UserInfo> GetLineUserInfo(string id)
        {
           var result =  await this.AuroraLineDbContext.UserInfos.Where(i => i.LineID == id).FirstOrDefaultAsync();
           return result;
        }

        public async Task UpdateLineUserInfo(UserInfo model)
        {
            var userInfo = await this.AuroraLineDbContext.UserInfos.Where(i => i.LineID == model.LineID).FirstOrDefaultAsync();

            if (model.Name != null)
            {
                userInfo.Name = model.Name;
                userInfo.Status = (int)UserInfoStatus.Mobile;
            }

            if (model.Mobile != null)
            {
                userInfo.Mobile = model.Mobile;
                userInfo.Status = (int)UserInfoStatus.Done;
            }

            await this.AuroraLineDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsEngaged(string id)
        {
            var engaged = await this.AuroraLineDbContext.EngageRequests.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
            var result = engaged == null ? false : true;
            return result;
        }

        public async Task AddPendingRequest(string id)
        {
            var model = new PendingRequest()
            {
                CustomerId = id,
                IssusOpend = true
            };
            this.AuroraLineDbContext.PendingRequests.Add(model);

            await this.AuroraLineDbContext.SaveChangesAsync();
        }

        public async Task<int> ClosePendingRequest(string id)
        {
            var target = await this.AuroraLineDbContext.PendingRequests.Where(i => i.CustomerId == id).FirstOrDefaultAsync();
            target.IssusOpend = true;

            return await this.AuroraLineDbContext.SaveChangesAsync();
        }

        public async Task EngageRequest(string pendingId)
        {
            var model = new EngageRequest()
            {
                AgentId = "Ua334d5bb62b049d69d168774b380aaea",
                CustomerId = pendingId
            };
            this.AuroraLineDbContext.EngageRequests.Add(model);
            await this.AuroraLineDbContext.SaveChangesAsync();
        }

        public async Task<string> GetEngageRequest(string id)
        {
            var result = await this.AuroraLineDbContext.EngageRequests
                                                       .Where(i => i.CustomerId == id || i.AgentId == id)
                                                       .FirstOrDefaultAsync();
            if (result!=null)
            {
                if (result.AgentId == id)
                {
                    return result.CustomerId;
                }
                else 
                {
                    return result.AgentId;
                }
            }
            else
            {
                return "";
            }
        }

        public async Task<UserInfo> GetUserStatus(string id)
        {
            var result = await this.AuroraLineDbContext.UserInfos
                                                       .Where(i => i.LineID ==  id)
                                                       .FirstOrDefaultAsync();

            return result;
        }

        public async Task UpdateUserStatus(string id, UserInfoStatus status)
        {
            throw new  NotImplementedException();
        }

        public async Task<IEnumerable<UserInfo>> GetAllUserInfo()
        {
            var userinfoList = await this.AuroraLineDbContext.UserInfos.ToListAsync();

            return userinfoList;

        }

        /// <summary>
        /// 儲存對話內容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task PostConversation(Conversation model)
        {
            this.AuroraLineDbContext.Conversations.Add(model);
            await this.AuroraLineDbContext.SaveChangesAsync();
        }
    }
}