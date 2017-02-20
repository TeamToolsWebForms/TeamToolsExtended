using NUnit.Framework;
using TeamTools.Logic.Data.Migrations;

namespace TeamTools.Logic.Tests.Data.ConfigurationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfConfiguration()
        {
            var config = new Configuration();

            Assert.IsTrue(config.AutomaticMigrationsEnabled);
            Assert.IsTrue(config.AutomaticMigrationDataLossAllowed);
            Assert.IsInstanceOf<Configuration>(config);
        }
    }
}
