using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsProjects.OrganizationDetailsProjectsPresenterTests
{
    [TestFixture]
    public class View_UpdateOrganizationProject_Should
    {
        [Test]
        public void CallProjectService_UpdateOnce()
        {
            var mockedView = new Mock<IOrganizationDetailsProjectsView>();
            var viewModel = new OrganizationDetailsProjectsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new OrganizationDetailsProjectsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedProjectService.Object);
            int id = 12;
            int organizationId = 123;
            string title = "test";

            mockedView.Raise(x => x.UpdateOrganizationProject += null, new OrganizationDetailsProjectsEventArgs(id, title, organizationId));

            mockedProjectService.Verify(x => x.Update(It.Is<int>(i => i == id), It.Is<string>(t => t == title)), Times.Once);
        }

        [Test]
        public void CallOrganizationService_GetByIdOnce()
        {
            var mockedView = new Mock<IOrganizationDetailsProjectsView>();
            var viewModel = new OrganizationDetailsProjectsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new OrganizationDetailsProjectsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedProjectService.Object);
            int id = 12;
            int organizationId = 123;
            string title = "test";

            mockedView.Raise(x => x.UpdateOrganizationProject += null, new OrganizationDetailsProjectsEventArgs(id, title, organizationId));

            mockedOrganizationService.Verify(x => x.GetById(It.Is<int>(i => i == organizationId)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_CorrectValue()
        {
            var mockedView = new Mock<IOrganizationDetailsProjectsView>();
            var viewModel = new OrganizationDetailsProjectsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var organizationDTO = new OrganizationDTO();
            mockedOrganizationService.Setup(x => x.GetById(It.IsAny<int>())).Returns(organizationDTO);
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new OrganizationDetailsProjectsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedProjectService.Object);
            int id = 12;
            int organizationId = 123;
            string title = "test";

            mockedView.Raise(x => x.UpdateOrganizationProject += null, new OrganizationDetailsProjectsEventArgs(id, title, organizationId));

            Assert.AreEqual(mockedView.Object.Model.Organization, organizationDTO);
        }
    }
}
