using System;
using NUnit.Framework;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.DateServiceTests
{
    [TestFixture]
    public class GetCurrentTime_Should
    {
        [Test]
        public void ReturnCurrentTime()
        {
            var dateService = new DateService();

            var result = dateService.GetCurrentTime();

            Assert.IsInstanceOf<DateTime>(result);
        }
    }
}
