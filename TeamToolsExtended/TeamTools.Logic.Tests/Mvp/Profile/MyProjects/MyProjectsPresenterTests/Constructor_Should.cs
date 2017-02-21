using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjects.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.Home;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjects.MyProjectsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IMyProjectsView>();
            var mockedUserService = new Mock<IUserService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new MyProjectsPresenter(
                mockedView.Object,
                null,
                mockedUserService.Object));
            Assert.That(ex.Message.Contains("Project Service"));
        }

        [Test]
        public void ThrowsWhenUserService_IsNull()
        {
            var mockedView = new Mock<IMyProjectsView>();
            var mockedProjectService = new Mock<IProjectService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new MyProjectsPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                null));
            Assert.That(ex.Message.Contains("User Service"));
        }

        [Test]
        public void ReturnInstanceOfMyProjectsPresenter_Correct()
        {
            var mockedView = new Mock<IMyProjectsView>();
            var mockedProjectService = new Mock<IProjectService>();
            var mockedUserService = new Mock<IUserService>();

            var presenter = new MyProjectsPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedUserService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<MyProjectsPresenter>(presenter);
        }
    }
}
