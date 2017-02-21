using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectDetailsChartPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IProjectDetailsChartView>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ProjectDetailsChartPresenter(
                mockedView.Object,
                null));
            Assert.That(ex.Message.Contains("Project service"));
        }

        [Test]
        public void ReturnInstanceOfProjectDetailsChartPresenter_Correct()
        {
            var mockedView = new Mock<IProjectDetailsChartView>();
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new ProjectDetailsChartPresenter(mockedView.Object, mockedProjectService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<ProjectDetailsChartPresenter>(presenter);
        }
    }
}
