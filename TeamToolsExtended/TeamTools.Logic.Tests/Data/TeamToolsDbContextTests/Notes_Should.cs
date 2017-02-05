using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;
using System.Data.Entity;
using TeamTools.Logic.Data;

namespace TeamTools.Logic.Tests.Data.TeamToolsDbContextTests
{
    [TestFixture]
    public class Notes_Should
    {
        [Test]
        public void SetNotes_Correct()
        {
            var mockedDbSet = new Mock<IDbSet<Note>>();
            var context = new TeamToolsDbContext();

            context.Notes = mockedDbSet.Object;

            Assert.AreSame(mockedDbSet.Object, context.Notes);
        }

        [Test]
        public void IsVirtual()
        {
            var mockedDbSet = new Mock<IDbSet<Organization>>();
            var context = new TeamToolsDbContext();

            bool isVirtual = context.GetType().GetProperty("Notes").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
