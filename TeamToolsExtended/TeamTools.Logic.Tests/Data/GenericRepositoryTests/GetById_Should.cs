using System;
using System.Linq;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.GenericRepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnCorrect_RecordWhenValidIntIdIsPassed()
        {
            int id = 1;
            var mockedDbSet = new Mock<IDbSet<Note>>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(new Note() { Id = id });
            var mockedContext = new Mock<ITeamToolsDbContext>();
            mockedContext.Setup(x => x.Set<Note>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<Note>(mockedContext.Object);

            var record = repo.GetById(id);

            Assert.IsNotNull(record);
            Assert.IsInstanceOf<Note>(record);
            Assert.AreEqual(id, record.Id);
        }

        [Test]
        public void ReturnCorrect_RecordWhenValidStringIdIsPassed()
        {
            string id = "abcd-some";
            var mockedDbSet = new Mock<IDbSet<User>>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<string>())).Returns(new User() { Id = id });
            var mockedContext = new Mock<ITeamToolsDbContext>();
            mockedContext.Setup(x => x.Set<User>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<User>(mockedContext.Object);

            var record = repo.GetById(id);

            Assert.IsNotNull(record);
            Assert.IsInstanceOf<User>(record);
            Assert.AreEqual(id, record.Id);
        }

        [Test]
        public void ReturnNull_WhenRecordIsNotFoundWithIntParameter()
        {
            int[] ids = new int[] { 1, 2, 3, 4 };
            var mockedDbSet = new Mock<IDbSet<Note>>();
            mockedDbSet.Setup(x => x.Find(It.Is<int>(id => ids.Contains(id))))
                .Returns(new Note());
            var mockedContext = new Mock<ITeamToolsDbContext>();
            mockedContext.Setup(x => x.Set<Note>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<Note>(mockedContext.Object);

            var record = repo.GetById(10);

            Assert.IsNull(record);
        }

        [Test]
        public void ReturnNull_WhenRecordIsNotFoundWithStringParameter()
        {
            string[] ids = new string[] { "absc-asdf", "absc-fdasf", "dfas-asdf", "absc-gfd" };
            var mockedDbSet = new Mock<IDbSet<User>>();
            mockedDbSet.Setup(x => x.Find(It.Is<string>(id => ids.Contains(id))))
                .Returns(new User());
            var mockedContext = new Mock<ITeamToolsDbContext>();
            mockedContext.Setup(x => x.Set<User>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<User>(mockedContext.Object);

            var record = repo.GetById("hha-skk");

            Assert.IsNull(record);
        }

        [Test]
        public void Throw_WhenIdLessThanZeroIsPassed()
        {
            int testId = -10;
            var mockedContext = new Mock<ITeamToolsDbContext>();
            var repo = new GenericRepository<Note>(mockedContext.Object);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => repo.GetById(testId));
            Assert.That(ex.Message.Contains("Id"));
        }

        [Test]
        public void Throw_WhenIdIsNull()
        {
            string testId = null;
            var mockedContext = new Mock<ITeamToolsDbContext>();
            var repo = new GenericRepository<User>(mockedContext.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => repo.GetById(testId));
            Assert.That(ex.Message.Contains("Id"));
        }
    }
}
