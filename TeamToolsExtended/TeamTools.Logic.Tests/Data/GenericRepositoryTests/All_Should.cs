using System.Collections.Generic;
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
    public class All_Should
    {
        [Test]
        public void ReturnCorrect_AllRecords()
        {
            var data = new List<Note>()
            {
                new Note() { Title = "Some" },
                new Note() { Title = "Other" },
                new Note() { Title = "Another" },
                new Note() { Title = "Again" }
            };
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var queryableData = data.AsQueryable();
            var mockedDbSet = this.GetMockedDbSet<Note>(queryableData);
            
            mockedDbContext.Setup(x => x.Set<Note>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            var result = repo.All();

            Assert.AreEqual(data.Count, result.Count());
            CollectionAssert.AreEqual(data, result);
        }

        [Test]
        public void ReturnCorrect_AllRecordsFiltered()
        {
            var data = new List<Note>()
            {
                new Note() { IsImportant = true, Title = "Some" },
                new Note() { IsImportant = true, Title = "Other" },
                new Note() { IsImportant = true, Title = "Another" },
                new Note() { IsImportant = false, Title = "Again" }
            };
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var queryableData = data.AsQueryable();
            var mockedDbSet = this.GetMockedDbSet<Note>(queryableData);

            mockedDbContext.Setup(x => x.Set<Note>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            var result = repo.All(x => x.IsImportant == true);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void ReturnEmptyCollection_WhenNoElements()
        {
            var data = new List<Note>();
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var queryableData = data.AsQueryable();
            var mockedDbSet = this.GetMockedDbSet<Note>(queryableData);

            mockedDbContext.Setup(x => x.Set<Note>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            var result = repo.All();

            Assert.AreEqual(data.Count, result.Count());
            CollectionAssert.AreEqual(data, result);
        }

        [Test]
        public void ReturnEmptyCollection_WhenNoElementsMatchFilter()
        {
            var data = new List<Note>()
            {
                new Note() { IsImportant = true, Title = "Some" },
                new Note() { IsImportant = true, Title = "Other" },
                new Note() { IsImportant = true, Title = "Another" },
                new Note() { IsImportant = true, Title = "Again" }
            };
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var queryableData = data.AsQueryable();
            var mockedDbSet = this.GetMockedDbSet<Note>(queryableData);

            mockedDbContext.Setup(x => x.Set<Note>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            var result = repo.All(x => x.IsImportant == false);

            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void ReturnAscendingOrderedCollection_WhenIsAscendingSetToTrue()
        {
            var data = new List<Note>()
            {
                new Note() { IsImportant = true, Title = "Some" },
                new Note() { IsImportant = true, Title = "Other" },
                new Note() { IsImportant = true, Title = "Another" },
                new Note() { IsImportant = true, Title = "Again" }
            };
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var queryableData = data.AsQueryable();
            var mockedDbSet = this.GetMockedDbSet<Note>(queryableData);

            mockedDbContext.Setup(x => x.Set<Note>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            var result = repo.All(x => x.IsImportant == true, x => x.Title, true);
            var expected = data.OrderBy(x => x.Title);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnDescendingOrderedCollection_WhenIsAscendingSetToFalse()
        {
            var data = new List<Note>()
            {
                new Note() { IsImportant = true, Title = "Some" },
                new Note() { IsImportant = true, Title = "Other" },
                new Note() { IsImportant = true, Title = "Another" },
                new Note() { IsImportant = true, Title = "Again" }
            };
            var mockedDbContext = new Mock<ITeamToolsDbContext>();
            var queryableData = data.AsQueryable();
            var mockedDbSet = this.GetMockedDbSet<Note>(queryableData);

            mockedDbContext.Setup(x => x.Set<Note>()).Returns(mockedDbSet.Object);
            var repo = new GenericRepository<Note>(mockedDbContext.Object);

            var result = repo.All(x => x.IsImportant == true, x => x.Title, false);
            var expected = data.OrderByDescending(x => x.Title);

            CollectionAssert.AreEqual(expected, result);
        }

        private Mock<IDbSet<T>> GetMockedDbSet<T>(IQueryable<T> data)
            where T : class
        {
            var mockedDbSet = new Mock<IDbSet<T>>();
            mockedDbSet.As<IQueryable<T>>().Setup(m => m.Provider)
                    .Returns(data.Provider);
            mockedDbSet.As<IQueryable<T>>().Setup(m => m.Expression)
                    .Returns(data.Expression);
            mockedDbSet.As<IQueryable<T>>().Setup(m => m.ElementType)
                    .Returns(data.ElementType);
            mockedDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                    .Returns(data.GetEnumerator());

            return mockedDbSet;
        }
    }
}
