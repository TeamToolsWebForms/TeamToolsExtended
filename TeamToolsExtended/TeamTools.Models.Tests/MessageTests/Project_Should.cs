using NUnit.Framework;
using Moq;

namespace TeamTools.Models.Tests.MessageTests
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
