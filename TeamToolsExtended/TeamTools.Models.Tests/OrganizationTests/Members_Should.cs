using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.OrganizationTests
{
    [TestFixture]
    public class Members_Should
    {
        [Test]
        public void SetMembers_Correct()
        {
            var members = new HashSet<User>();
            var organization = new Organization();

            organization.Members = members;

            Assert.AreSame(members, organization.Members);
        }

        [Test]
        public void BeVirtual()
        {
            var organization = new Organization();

            bool isVirtual = organization.GetType().GetProperty("Members").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
