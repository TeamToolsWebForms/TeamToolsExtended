using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationTests
{
    [TestFixture]
    public class OrganizationLogo_Should
    {
        [Test]
        public void SetOrganizationLogo_Correct()
        {
            var organizationLogo = new Mock<OrganizationLogo>();
            var organization = new Organization();

            organization.OrganizationLogo = organizationLogo.Object;

            Assert.AreSame(organizationLogo.Object, organization.OrganizationLogo);
        }

        [Test]
        public void BeVirtual()
        {
            var organization = new Organization();

            bool isVirtual = organization.GetType().GetProperty("OrganizationLogo").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
