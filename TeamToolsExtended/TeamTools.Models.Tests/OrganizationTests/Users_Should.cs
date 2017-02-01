using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.OrganizationTests
{
    [TestFixture]
    public class Users_Should
    {
        [Test]
        public void SetMembers_Correct()
        {
            var members = new HashSet<User>();
            var organization = new Organization();

            organization.Users = members;

            Assert.AreSame(members, organization.Users);
        }

        [Test]
        public void BeVirtual()
        {
            var organization = new Organization();

            bool isVirtual = organization.GetType().GetProperty("Users").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
