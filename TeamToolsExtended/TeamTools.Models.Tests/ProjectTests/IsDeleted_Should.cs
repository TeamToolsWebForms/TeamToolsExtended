using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTests
{
    [TestFixture]
    public class IsDeleted_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetIsDeleted_Correct(bool isDeleted)
        {
            var project = new Project();

            project.IsDeleted = isDeleted;

            Assert.AreEqual(isDeleted, project.IsDeleted);
        }
    }
}
