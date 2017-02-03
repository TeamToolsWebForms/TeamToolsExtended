using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
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
