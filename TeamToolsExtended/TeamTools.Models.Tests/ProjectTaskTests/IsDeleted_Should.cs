using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTaskTests
{
    [TestFixture]
    public class IsDeleted_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetIsDeleted_Correct(bool isDeleted)
        {
            var projectTask = new ProjectTask();

            projectTask.IsDeleted = isDeleted;

            Assert.AreEqual(isDeleted, projectTask.IsDeleted);
        }
    }
}
