using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTaskTests
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
