using NUnit.Framework;

namespace TeamTools.Models.Tests.OrganizationTests
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
