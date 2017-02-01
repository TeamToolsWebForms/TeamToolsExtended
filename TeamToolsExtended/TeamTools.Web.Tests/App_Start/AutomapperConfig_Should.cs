using AutoMapper;
using NUnit.Framework;
using TeamTools.Web.App_Start;

namespace TeamTools.Web.Tests.App_Start
{
    [TestFixture]
    public class AutomapperConfig_Should
    {
        [Test]
        public void MapObjectsCorrect()
        {
            AutomapperConfig.CreateMapper();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
