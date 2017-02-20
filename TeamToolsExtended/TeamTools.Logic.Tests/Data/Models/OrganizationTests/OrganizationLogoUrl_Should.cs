using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationTests
{
    [TestFixture]
    public class OrganizationLogoUrl_Should
    {
        [TestCase("someurl.com")]
        [TestCase("otherurl.bg")]
        public void SetOrganizationLogoUrl_Correct(string url)
        {
            var organization = new Organization();

            organization.OrganizationLogoUrl = url;

            Assert.AreEqual(url, organization.OrganizationLogoUrl);
        }
    }
}
