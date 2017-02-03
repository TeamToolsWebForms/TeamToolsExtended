using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(50)]
        public void SetId_Correct(int id)
        {
            var organization = new Organization();

            organization.Id = id;

            Assert.AreEqual(id, organization.Id);
        }
    }
}
