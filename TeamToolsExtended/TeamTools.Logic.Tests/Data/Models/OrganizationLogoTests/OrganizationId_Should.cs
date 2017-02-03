using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationLogoTests
{
    [TestFixture]
    public class OrganizationId_Should
    {
        [TestCase(15)]
        [TestCase(1)]
        public void SetOrganizationId_Correct(int id)
        {
            var organizationLogo = new OrganizationLogo();

            organizationLogo.OrganizationId = id;

            Assert.AreEqual(id, organizationLogo.OrganizationId);
        }
    }
}
