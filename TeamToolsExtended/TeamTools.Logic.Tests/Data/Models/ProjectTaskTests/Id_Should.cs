using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTaskTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(121)]
        public void SetId_Correct(int id)
        {
            var projectTask = new ProjectTask();

            projectTask.Id = id;

            Assert.AreEqual(id, projectTask.Id);
        }
    }
}
