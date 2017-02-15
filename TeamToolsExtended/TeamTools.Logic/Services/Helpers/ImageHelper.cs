using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TeamTools.Logic.Services.Helpers.Contracts;

namespace TeamTools.Logic.Services.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        public string ByteArrayToImageUrl(byte[] byteArrayIn)
        {
            string base64String = Convert.ToBase64String(byteArrayIn, 0, byteArrayIn.Length);
            string resultUrl = "data:image/jpg;base64," + base64String;
            return resultUrl;
        }

        public Image GetImage(string path)
        {
            return Image.FromFile(path);
        }
    }
}
