using NUnit.Framework;
using Moq;

namespace TeamTools.Models.Tests.ProjectTests
{
    [TestFixture]
    public class Creator_Should
    {
        [Test]
        public void SetCreator_Correct()
        {
            var user = new Mock<User>();
            var project = new Project();

            project.Creator = user.Object;

            Assert.AreSame(user.Object, project.Creator);
        }

        [Test]
        public void BeVirtual()
        {
            var project = new Project();

            bool isVirtual = project.GetType().GetProperty("Creator").GetGetMethod().IsVirtual;

            Assert.IsTrue(isVirtual);
        }
    }
}
