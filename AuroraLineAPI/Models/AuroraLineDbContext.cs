using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuroraLineAPI.Models
{
    public class AuroraLineDbContext : DbContext
    {
        public AuroraLineDbContext() : this("AuroraLine")
        {
        }

        public AuroraLineDbContext(string nameOrConnectionString)
                : base(nameOrConnectionString)
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<EngageRequest> EngageRequests { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<PendingRequest> PendingRequests { get; set; }

        public DbSet<Conversation> Conversations { get; set; }
    }
}