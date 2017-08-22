using AuroraLineAPI.AuroraLine.ViewModels;
using AuroraLineAPI.Services.AuroraLineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AuroraLineAPI.Controllers.api
{
    public class AuroraLineBotController : ApiController
    {
        private IAuroraLineBotService AuroraLineBotService;

        public AuroraLineBotController(IAuroraLineBotService auroraLineBotService)
        {
            this.AuroraLineBotService = auroraLineBotService;
        }

        // GET: api/AuroraLineBot
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AuroraLineBot/5
        public async Task<HttpResponseMessage> Get(string id)
        {
            var result = await this.AuroraLineBotService.GetLineUserInfo(id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/AuroraLineBot
        public async Task<HttpResponseMessage> Post([FromBody]AuroraLineViewModel model)
        {
            await this.AuroraLineBotService.CreateLineUserInfo(model);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // PUT: api/AuroraLineBot/5
        public async Task<HttpResponseMessage> Put([FromBody]AuroraLineViewModel model)
        {
            await this.AuroraLineBotService.UpdateLineUserInfo(model);

            return Request.CreateResponse(HttpStatusCode.OK,"Done");
        }

        // DELETE: api/AuroraLineBot/5
        public void Delete(int id)
        {
        }
    }
}
