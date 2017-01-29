using NUnit.Framework;
using Moq;

namespace TeamTools.Models.Tests.OrganizationTests
{
    [TestFixture]
    public class Creator_Should
    {
        [Test]
        public void SetCreator_Correct()
        {
            var user = new Mock<User>();
            var organization = new Organization();

            organization.Creator = user.Object;

            Assert.AreSame(user.Object, organization.Creator);
        }

        [Test]
        public void BeVirtual()
        {
            var organization = new Organization();

            bool isVirtual = organization.GetType().GetProperty("Creator").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
