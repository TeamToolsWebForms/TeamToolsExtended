using System;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfMessage_WhenParameterless()
        {
            var message = new Message();

            Assert.IsInstanceOf<Message>(message);
        }

        [Test]
        public void ReturnInstanceOfMessage_WithCorrectSetPropeties()
        {
            DateTime date = DateTime.Now;
            string creator = "Someone";
            string content = "Content";
            var message = new Message(date, creator, content);

            Assert.AreEqual(date, message.Created);
            Assert.AreEqual(creator, message.Creator);
            Assert.AreEqual(content, message.Content);
            Assert.IsInstanceOf<Message>(message);
        }
    }
}
