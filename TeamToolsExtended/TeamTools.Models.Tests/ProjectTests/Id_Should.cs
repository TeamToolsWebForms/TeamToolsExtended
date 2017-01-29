using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTests
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
