using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AuroraLineAPI.Models;
using System.Data.Entity;

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
            this.AuroraLineDbContext.UserInfos.Attach(model);
            this.AuroraLineDbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;

            await this.AuroraLineDbContext.SaveChangesAsync();
        }

        public async Task<bool> GetUserInfoGiftState(string id)
        {
            var userInfo = await this.AuroraLineDbContext.UserInfos.Where(i => i.LineID == id).FirstOrDefaultAsync();

            if(userInfo != null)
            {
                var gotGift = userInfo.GotGift;
                if (!gotGift)
                {
                    userInfo.GotGift = true;
                    await this.AuroraLineDbContext.SaveChangesAsync();
                }

                return gotGift;
            }
            else
            {
                return true;
            }
        }
    }
}