using AuroraLineAPI.Services.Common;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace AuroraLineAPI.Controllers.api
{
    public class ImageController : ApiController
    {
        private IQRCodeService QRCodeService;

        public ImageController(IQRCodeService qrCodeService)
        {
            this.QRCodeService = qrCodeService;
        }

        // GET: api/Image/5
        public HttpResponseMessage Get(string id)
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            var url = string.Format("{0}/api/UserInfoGiftState/{1}", baseUrl, id);
            var m_Bitmap = this.QRCodeService.GenerateQRCode(url);

            MemoryStream ms = new MemoryStream();
            m_Bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            var resp = new HttpResponseMessage()
            {
                Content = new ByteArrayContent(ms.ToArray())
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
