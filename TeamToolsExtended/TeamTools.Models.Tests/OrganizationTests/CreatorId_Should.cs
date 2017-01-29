using NUnit.Framework;

namespace TeamTools.Models.Tests.OrganizationTests
{
    [TestFixture]
    public class CreatorId_Should
    {
        [TestCase(1)]
        [TestCase(5010)]
        public void SetCreatorId_Correct(int id)
        {
            var organization = new Organization();

            organization.CreatorId = id;

            Assert.AreEqual(id, organization.CreatorId);
        }
    }
}
