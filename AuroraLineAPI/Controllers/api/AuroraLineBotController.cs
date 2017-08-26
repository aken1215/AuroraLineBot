using AuroraLineAPI.AuroraLine.ViewModels;
using AuroraLineAPI.Services.AuroraLineBot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            var userInfo = await this.AuroraLineBotService.GetLineUserInfo(id);
            var result = userInfo == null ? false : true;

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("api/UserInfoGiftState/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> UpdateUserInfoGiftState(string id)
        {
            var gotGift = await this.AuroraLineBotService.GetUserInfoGiftState(id);
            var response = new HttpResponseMessage();
            var message = "";

            if (gotGift)
            {
                message = "<html><body>已領過小禮物</body></html>";
            }
            else
            {
                message = "<html><body>發送小禮物</body></html>";
            }

            response.Content = new StringContent(message);
            response.StatusCode = HttpStatusCode.OK;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            response.Content.Headers.ContentType.CharSet = "utf-8";

            return response;
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

            return Request.CreateResponse(HttpStatusCode.OK, "Done");
        }

        // DELETE: api/AuroraLineBot/5
        public void Delete(int id)
        {
        }
    }
}
