using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class Commit_Should
    {
        [Test]
        public void CallSaveChanges_Once()
        {
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            unitOfWork.Commit();

            mockedDbContext.Verify(dbContext => dbContext.SaveChanges(), Times.Once);
        }
    }
}
