using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTests
{
    [TestFixture]
    public class CreatorId_Should
    {
        [TestCase(1)]
        [TestCase(1020)]
        public void SetCreatorId_Correct(int id)
        {
            var project = new Project();

            project.CreatorId = id;

            Assert.AreEqual(id, project.CreatorId);
        }
    }
}
