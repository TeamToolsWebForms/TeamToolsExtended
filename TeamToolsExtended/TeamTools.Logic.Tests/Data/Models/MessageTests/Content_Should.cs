using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
{
    [TestFixture]
    public class Content_Should
    {
        [TestCase("test")]
        [TestCase("more test")]
        public void SetContent_Correct(string content)
        {
            var message = new Message();

            message.Content = content;

            Assert.AreEqual(content, message.Content);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var message = new Message();

            var property = message.GetType().GetProperty("Content");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
