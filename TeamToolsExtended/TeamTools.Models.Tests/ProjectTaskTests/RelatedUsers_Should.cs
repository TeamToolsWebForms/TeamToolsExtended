using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TeamTools.Models.Tests.ProjectTaskTests
{
    [TestFixture]
    public class RelatedUsers_Should
    {
        [Test]
        public void SetRelatedUsers_Correct()
        {
            var relatedUsers = new HashSet<User>();
            var projectTask = new ProjectTask();

            projectTask.RelatedUsers = relatedUsers;

            Assert.AreSame(relatedUsers, projectTask.RelatedUsers);
        }

        [Test]
        public void BeVirtual()
        {
            var projectTask = new ProjectTask();

            bool isVirtual = projectTask.GetType().GetProperty("RelatedUsers").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
