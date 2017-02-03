using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserLogoTests
{
    [TestFixture]
    public class Image_Should
    {
        [TestCase(new byte[] { 1, 20, 67 })]
        [TestCase(new byte[] { 1, 127, 100, 122, 23, 13 })]
        public void SetImage_Correct(byte[] image)
        {
            var userLogo = new UserLogo();

            userLogo.Image = image;

            Assert.AreSame(image, userLogo.Image);
        }
    }
}
