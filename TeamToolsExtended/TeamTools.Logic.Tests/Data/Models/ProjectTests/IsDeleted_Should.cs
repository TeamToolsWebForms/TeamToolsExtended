using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
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
