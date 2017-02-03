using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationLogoTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(15)]
        [TestCase(1200)]
        public void SetId_Correct(int id)
        {
            var organizationLogo = new OrganizationLogo();

            organizationLogo.Id = id;

            Assert.AreEqual(id, organizationLogo.Id);
        }
    }
}
