using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(32432)]
        public void SetId_Correct(int id)
        {
            var project = new Project();

            project.Id = id;

            Assert.AreEqual(id, project.Id);
        }
    }
}
