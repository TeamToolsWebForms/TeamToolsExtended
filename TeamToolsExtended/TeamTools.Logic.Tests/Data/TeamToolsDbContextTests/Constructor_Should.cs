using NUnit.Framework;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeTeamToolsDbContext_Correct()
        {
            var context = new TeamToolsDbContext();

            Assert.IsNotNull(context);
        }
    }
}
