using System;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
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
