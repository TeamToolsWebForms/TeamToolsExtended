using System;
using NUnit.Framework;
using TeamTools.Logic.Services.Helpers;

namespace TeamTools.Logic.Tests.Services.Helpers.ImageHelperTests
{
    [TestFixture]
    public class ByteArrayToImageUrl_Should
    {
        [Test]
        public void ReturnCorrectUrl()
        {
            byte[] content = new byte[] { 1, 2, 3, 67 };
            string base64String = Convert.ToBase64String(content, 0, content.Length);
            string expected = "data:image/jpg;base64," + base64String;

            var helper = new ImageHelper();

            var result = helper.ByteArrayToImageUrl(content);

            Assert.AreEqual(expected, result);
        }
    }
}
