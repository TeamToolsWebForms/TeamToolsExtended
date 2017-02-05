using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Contracts;

namespace TeamTools.Logic.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeUnitOfWork_Correct()
        {
            var mockedDbContext = new Mock<ITeamToolsDbContext>();

            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            Assert.IsNotNull(unitOfWork);
        }
    }
}
