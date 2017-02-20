using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.OrganizationLogoTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfOrganizationLogo_WithCorrectSetProperties()
        {
            byte[] content = new byte[] { 1, 123, 124, 12, 34, 54 };

            var orgLogo = new OrganizationLogo(content);

            CollectionAssert.AreEqual(content, orgLogo.Image);
            Assert.IsInstanceOf<OrganizationLogo>(orgLogo);
        }
    }
}
