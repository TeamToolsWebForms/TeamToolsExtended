using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class OrganizationId_Should
    {
        [TestCase(12)]
        [TestCase(null)]
        public void SetOrganizationId_Correct(int? id)
        {
            var project = new Project();

            project.OrganizationId = id;

            Assert.AreEqual(id, project.OrganizationId);
        }
    }
}
