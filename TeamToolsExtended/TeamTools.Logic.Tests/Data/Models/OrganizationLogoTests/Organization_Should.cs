using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationLogoTests
{
    [TestFixture]
    public class Organization_Should
    {
        [Test]
        public void SetOrganization_Correct()
        {
            var organization = new Mock<Organization>();
            var organizationLogo = new OrganizationLogo();

            organizationLogo.Organization = organization.Object;

            Assert.AreSame(organization.Object, organizationLogo.Organization);
        }

        [Test]
        public void BeVirtual()
        {
            var organizationLogo = new OrganizationLogo();

            bool isVirtual = organizationLogo.GetType().GetProperty("Organization").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
