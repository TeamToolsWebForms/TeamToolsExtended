using NUnit.Framework;
using TeamTools.Models.Enums;

namespace TeamTools.Models.Tests.ProjectTaskTests
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
