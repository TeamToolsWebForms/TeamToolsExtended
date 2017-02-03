using System.Collections.Generic;
using NUnit.Framework;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.ProjectTests
{
    [TestFixture]
    public class Messages_Should
    {
        [Test]
        public void SetProjectMembers_Correct()
        {
            var messages = new HashSet<Message>();
            var project = new Project();

            project.Messages = messages;

            Assert.AreSame(messages, project.Messages);
        }

        [Test]
        public void BeVirtual()
        {
            var project = new Project();

            bool isVirtual = project.GetType().GetProperty("Messages").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
