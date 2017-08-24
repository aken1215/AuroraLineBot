using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace AuroraLineAPI.Controllers.api
{
    public class ImageController : ApiController
    {
        // GET: api/Image/5
        public HttpResponseMessage Get(string id)
        {
            //資料庫讀取的範例
            //var imageStorage = this.AuroraBotContext.ImageStorages.FirstOrDefault();
            //var stream = new StreamContent(new MemoryStream(imageStorage.Content));

            //這邊先放在App_Data資料夾下就可以測試
            //之後要改成從資料庫取得二進位資料
            var fullPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/170723093548.png");
            var fileStream = new FileStream(fullPath, FileMode.Open);
            var stream = new StreamContent(fileStream);

            var resp = new HttpResponseMessage()
            {
                Content = stream
            };

            resp.StatusCode = HttpStatusCode.OK;
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            resp.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            resp.Content.Headers.ContentDisposition.FileName = "avatar.png";

            return resp;
        }
        // POST: api/Image
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Image/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Image/5
        public void Delete(int id)
        {
        }
    }
}
