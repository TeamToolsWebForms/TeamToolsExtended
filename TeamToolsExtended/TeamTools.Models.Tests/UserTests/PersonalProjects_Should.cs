using System.Collections.Generic;
using NUnit.Framework;

namespace TeamTools.Models.Tests.UserTests
{
    [TestFixture]
    public class PersonalProjects_Should
    {
        [Test]
        public void SetPersonalProjects_Correct()
        {
            var personalProjects = new HashSet<Project>();
            var user = new User();

            user.PersonalProjects = personalProjects;

            Assert.AreSame(personalProjects, user.PersonalProjects);
        }

        [Test]
        public void BeVirtual()
        {
            var user = new User();

            bool isVirtual = user.GetType().GetProperty("PersonalProjects").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
