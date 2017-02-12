using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class GetState_Should
    {
        [Ignore("DbContext strange error")]
        [Test]
        public void CallStateFactory_Once()
        {
            var mockedFactory = new Mock<IStateFactory>();
            var context = new TeamToolsDbContext(mockedFactory.Object);
            var entity = new Note();

            context.GetState(entity);
            var entry = context.Entry(entity);

            mockedFactory.Verify(x => x.CreateState(entry), Times.Once());
        }

        [Ignore("DbContext strange error")]
        [Test]
        public void ReturnInstanceOf_EntryState()
        {
            var mockedState = new Mock<IEntryState<Note>>();
            var entity = new Note();
            var mockedFactory = new Mock<IStateFactory>();
            var context = new TeamToolsDbContext(mockedFactory.Object);
            mockedFactory.Setup(x => x.CreateState(context.Entry(entity))).Returns(mockedState.Object);
            
            var result = context.GetState(entity);

            Assert.IsInstanceOf<IEntryState<Note>>(result);
        }
    }
}
