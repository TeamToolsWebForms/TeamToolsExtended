using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectDetailsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IProjectDetailsView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDetailsPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("Project service"));
        }

        [Test]
        public void ReturnInstanceOfProjectDetailsPresenter_Correct()
        {
            var mockedView = new Mock<IProjectDetailsView>();
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new ProjectDetailsPresenter(mockedView.Object, mockedProjectService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProjectDetailsPresenter>(presenter);
        }
    }
}
