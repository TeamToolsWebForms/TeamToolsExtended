using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
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
