using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects.Contracts;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsProjects.OrganizationDetailsProjectsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhenOrganizationService_IsNull()
        {
            var mockedView = new Mock<IOrganizationDetailsProjectsView>();
            var mockedProjectService = new Mock<IProjectService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationDetailsProjectsPresenter(
                mockedView.Object,
                null,
                mockedProjectService.Object));
            Assert.That(ex.Message.Contains("Organization Service"));
        }

        [Test]
        public void ThrowsWhenProjectService_IsNull()
        {
            var mockedView = new Mock<IOrganizationDetailsProjectsView>();
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new OrganizationDetailsProjectsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                null));
            Assert.That(ex.Message.Contains("Project Service"));
        }

        [Test]
        public void ReturnInstanceOfOrganizationDetailsProjectsPresenter_Correct()
        {
            var mockedView = new Mock<IOrganizationDetailsProjectsView>();
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new OrganizationDetailsProjectsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedProjectService.Object);

            Assert.IsNotNull(presenter);
            Assert.IsInstanceOf<OrganizationDetailsProjectsPresenter>(presenter);
        }
    }
}
