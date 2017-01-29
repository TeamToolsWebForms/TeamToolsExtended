using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTaskTests
{
    [TestFixture]
    public class ExecutionCost_Should
    {
        [TestCase(15d)]
        [TestCase(2020d)]
        public void SetExecutionCost_Correct(decimal executionCost)
        {
            var projectTask = new ProjectTask();

            projectTask.ExecutionCost = executionCost;

            Assert.AreEqual(executionCost, projectTask.ExecutionCost);
        }
    }
}
