using System;
using NUnit.Framework;

namespace TeamTools.Models.Tests.MessageTests
{
    [TestFixture]
    public class Created_Should
    {
        [Test]
        public void SetDate_Correct()
        {
            var date = DateTime.Now;
            var message = new Message();

            message.Created = date;

            Assert.AreEqual(date, message.Created);
        }
    }
}
