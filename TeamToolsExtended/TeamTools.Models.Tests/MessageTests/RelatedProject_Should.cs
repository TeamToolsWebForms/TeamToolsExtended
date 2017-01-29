using NUnit.Framework;
using Moq;

namespace TeamTools.Models.Tests.MessageTests
{
    [TestFixture]
    public class RelatedProject_Should
    {
        [Test]
        public void SetRelatedProject()
        {
            var relatedProject = new Mock<Project>();
            var message = new Message();

            message.RelatedProject = relatedProject.Object;

            Assert.AreSame(relatedProject.Object, message.RelatedProject);
        }

        [Test]
        public void BeVirtual()
        {
            var message = new Message();

            bool isVirtual = message.GetType().GetProperty("RelatedProject").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
