using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Tests.Data.Models.MessageTests
{
    [TestFixture]
    public class Project_Should
    {
        [Test]
        public void SetRelatedProject()
        {
            var relatedProject = new Mock<Project>();
            var message = new Message();

            message.Project = relatedProject.Object;

            Assert.AreSame(relatedProject.Object, message.Project);
        }

        [Test]
        public void BeVirtual()
        {
            var message = new Message();

            bool isVirtual = message.GetType().GetProperty("Project").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
