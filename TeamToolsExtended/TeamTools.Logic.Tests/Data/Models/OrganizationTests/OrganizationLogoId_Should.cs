using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationTests
{
    [TestFixture]
    public class OrganizationLogoId_Should
    {
        [TestCase(15)]
        [TestCase(11777)]
        public void SetOrganizationLogoId_Correct(int id)
        {
            var organization = new Organization();

            organization.OrganizationLogoId = id;

            Assert.AreEqual(id, organization.OrganizationLogoId);
        }
    }
}
