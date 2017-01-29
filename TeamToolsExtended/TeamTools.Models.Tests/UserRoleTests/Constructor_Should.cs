using NUnit.Framework;

namespace TeamTools.Models.Tests.UserRoleTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotBeNull_WhenCalled()
        {
            var role = new UserRole();

            Assert.IsNotNull(role);
        }

        [Test]
        public void SetName_WhenCalled()
        {
            string roleName = "admin";

            var role = new UserRole(roleName);

            Assert.AreEqual(roleName, role.Name);
        }
    }
}
