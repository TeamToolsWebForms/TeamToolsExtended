using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
{
    [TestFixture]
    public class ExecutionTime_Should
    {
        [TestCase("1:55")]
        [TestCase("22:10")]
        public void SetExecutionTime_Correct(string executionTime)
        {
            var projectTask = new ProjectTask();

            projectTask.ExecutionTime = executionTime;

            Assert.AreEqual(executionTime, projectTask.ExecutionTime);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            var projectTask = new ProjectTask();

            var property = projectTask.GetType().GetProperty("ExecutionTime");
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            Assert.IsTrue(isDefined);
        }
    }
}
