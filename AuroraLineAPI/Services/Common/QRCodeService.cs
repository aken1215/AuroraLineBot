using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace AuroraLineAPI.Services.Common
{
    public class QRCodeService:IQRCodeService
    {
        public Bitmap GenerateQRCode(string url)
        {
            BarcodeWriter bw = new BarcodeWriter();
            bw.Format = BarcodeFormat.QR_CODE;
            bw.Options.Width = 260;
            bw.Options.Height = 237;
            Bitmap bitmap = bw.Write(url);
            return bitmap;

        }
    }
}