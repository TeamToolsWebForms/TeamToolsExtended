using System.Collections.Generic;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.UserTests
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
