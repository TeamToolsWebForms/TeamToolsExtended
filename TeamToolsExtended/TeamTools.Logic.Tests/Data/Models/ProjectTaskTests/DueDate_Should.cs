using System;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
{
    [TestFixture]
    public class DueDate_Should
    {
        [TestCase("01/20/2012")]
        public void TestDate(DateTime dt)
        {
            Assert.That(dt, Is.EqualTo(new DateTime(2012, 01, 20)));
        }

        [TestCase("01/20/2012")]
        [TestCase("10/01/2017")]
        public void SetDueDate_Correct(DateTime dueDate)
        {
            var projectTask = new ProjectTask();

            projectTask.DueDate = dueDate;

            Assert.AreEqual(dueDate, projectTask.DueDate);
        }
    }
}
