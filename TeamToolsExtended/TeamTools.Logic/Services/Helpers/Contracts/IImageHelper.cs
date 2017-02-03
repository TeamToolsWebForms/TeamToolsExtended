using System.Drawing;

namespace TeamTools.Logic.Services.Helpers.Contracts
{
    public interface IImageHelper
    {
        byte[] ImageToByteArray(Image imageIn);

        string ByteArrayToImageUrl(byte[] byteArrayIn);
    }
}
