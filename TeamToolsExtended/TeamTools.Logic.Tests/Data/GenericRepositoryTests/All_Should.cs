using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.GenericRepositoryTests
{
    // all by expression
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
