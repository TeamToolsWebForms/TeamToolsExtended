using NUnit.Framework;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Data.Models.Enums;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
{
    [TestFixture]
    public class Status_Should
    {
        [TestCase(TaskType.Done)]
        [TestCase(TaskType.Started)]
        public void SetStatus_Correct(TaskType taskType)
        {
            var projectTask = new ProjectTask();

            projectTask.Status = taskType;

            Assert.AreEqual(taskType, projectTask.Status);
        }
    }
}
