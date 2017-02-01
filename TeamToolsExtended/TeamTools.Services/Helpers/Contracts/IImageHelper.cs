using System.Drawing;

namespace TeamTools.Services.Helpers.Contracts
{
    public interface IImageHelper
    {
        byte[] ImageToByteArray(Image imageIn);

        string ByteArrayToImageUrl(byte[] byteArrayIn);
    }
}
