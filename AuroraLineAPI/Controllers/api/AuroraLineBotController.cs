using AuroraLineAPI.AuroraLine.ViewModels;
using AuroraLineAPI.Services.AuroraLineBot;
using Newtonsoft.Json;
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



        // POST: api/AuroraLineBot
        public async Task<HttpResponseMessage> Post(AuroraLineViewModel model)
        {
            try
            {
                await this.AuroraLineBotService.CreateLineUserInfo(model);

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                var request = JsonConvert.SerializeObject(model);
                return Request.CreateResponse(HttpStatusCode.OK, request);
            }
        }

        // PUT: api/AuroraLineBot/5
        public async Task<HttpResponseMessage> Put(AuroraLineViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this.AuroraLineBotService.UpdateLineUserInfo(model);

                return Request.CreateResponse(HttpStatusCode.OK, "Done");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE: api/AuroraLineBot/5
        public void Delete(int id)
        {
        }

        // Get: api/UserState
        [HttpGet]
        [Route("api/UserStatus/{id}")]
        public async Task<HttpResponseMessage> GetUserStatus(string id)
        {
            var result = await this.AuroraLineBotService.GetUserStatus(id);


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [Route("api/ScanQrCode/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> ScanQrCode(string id)
        {
            var result = await this.AuroraLineBotService.GetUserStatus(id);
            var response = new HttpResponseMessage();
            var message = "";

            if (result ==(int) UserInfoStatus.GetGift)
            {
                message = "<html><body><h1>已領過小禮物<h1></body></html>";
            }
            else
            {
                await this.AuroraLineBotService.UpdateUserStatus(id, UserInfoStatus.GetGift);
                message = "<html><body><h1>發送小禮物<h1></body></html>";
            }

            response.Content = new StringContent(message);
            response.StatusCode = HttpStatusCode.OK;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            response.Content.Headers.ContentType.CharSet = "utf-8";

            return response;
        }

        [HttpPost]
        [Route("api/PendingRequest/{id}")]
        public async Task<HttpResponseMessage> PendingRequest(string id)
        {
            await this.AuroraLineBotService.AddPendingRequest(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/EngageRequest/{pendingId}")]
        public async Task<HttpResponseMessage> EngageRequest(string pendingId)
        {
            await this.AuroraLineBotService.EngageRequest(pendingId);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }


        [HttpGet]
        [Route("api/EngageRequest/{id}")]
        public async Task<HttpResponseMessage> GetEngageRequest(string id)
        {
            var result = await this.AuroraLineBotService.GetEngageRequest(id);

            return Request.CreateResponse(HttpStatusCode.OK,result);
        }
    }
}
