using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTaskTests
{
    [TestFixture]
    public class ProjectId_Should
    {
        [TestCase(1)]
        [TestCase(211)]
        public void SetProjectId_Correct(int id)
        {
            var projectTask = new ProjectTask();

            projectTask.ProjectId = id;

            Assert.AreEqual(id, projectTask.ProjectId);
        }
    }
}
