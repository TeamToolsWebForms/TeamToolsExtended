using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.UserTests
{
    [TestFixture]
    public class Organizations_Should
    {
        [Test]
        public void SetOrganizations_Correct()
        {
            var organizations = new HashSet<Organization>();
            var user = new User();

            user.Organizations = organizations;

            Assert.AreSame(organizations, user.Organizations);
        }

        [Test]
        public void BeVirtual()
        {
            var user = new User();

            bool isVirtual = user.GetType().GetProperty("Organizations").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
