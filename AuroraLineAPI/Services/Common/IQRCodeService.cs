using System.Drawing;

namespace AuroraLineAPI.Services.Common
{
    public interface IQRCodeService
    {
        Bitmap GenerateQRCode(string url);
    }
}