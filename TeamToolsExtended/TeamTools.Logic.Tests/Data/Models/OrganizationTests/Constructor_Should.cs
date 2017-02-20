using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfOrganization_WithCorrectSetPropeties()
        {
            string name = "Some name";
            string description = "some description";
            var mockedOrganizationLogo = new Mock<OrganizationLogo>();
            string creator = "someone";
            string logoUrl = "url.com";

            var organization = new Organization(name, description, mockedOrganizationLogo.Object, creator, logoUrl);

            Assert.AreEqual(name, organization.Name);
            Assert.AreEqual(description, organization.Description);
            Assert.AreEqual(mockedOrganizationLogo.Object, organization.OrganizationLogo);
            Assert.AreEqual(creator, organization.CreatorName);
            Assert.AreEqual(logoUrl, organization.OrganizationLogoUrl);
            Assert.IsInstanceOf<Organization>(organization);
        }
    }
}
