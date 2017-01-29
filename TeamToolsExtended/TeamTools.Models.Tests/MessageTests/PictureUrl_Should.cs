using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models.Tests.MessageTests
{
    [TestFixture]
    public class PictureUrl_Should
    {
        [TestCase("http://primerno.com")]
        [TestCase("http://neprimerno.com")]
        public void SetPictureUrl_Correct(string url)
        {
            var message = new Message();

            message.PictureUrl = url;

            Assert.AreEqual(url, message.PictureUrl);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var message = new Message();

            var property = message.GetType().GetProperty("PictureUrl");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveRegularExpression_Attribute()
        {
            var message = new Message();

            var property = message.GetType().GetProperty("PictureUrl");
            bool isDefined = Attribute.IsDefined(property, typeof(RegularExpressionAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
