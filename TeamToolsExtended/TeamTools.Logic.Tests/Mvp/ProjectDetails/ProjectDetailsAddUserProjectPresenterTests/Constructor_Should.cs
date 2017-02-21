using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsAddUserProjectPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IProjectDetailsAddUserProjectView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDetailsAddUserProjectPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("Project Service"));
        }

        [Test]
        public void ReturnInstanceOfProjectDetailsAddUserProjectPresenter_Correct()
        {
            var mockedView = new Mock<IProjectDetailsAddUserProjectView>();
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new ProjectDetailsAddUserProjectPresenter(
                mockedView.Object,
                mockedProjectService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProjectDetailsAddUserProjectPresenter>(presenter);
        }
    }
}
