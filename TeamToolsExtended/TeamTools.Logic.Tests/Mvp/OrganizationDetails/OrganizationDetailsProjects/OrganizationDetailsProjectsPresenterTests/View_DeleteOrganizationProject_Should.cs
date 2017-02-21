using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsProjects.OrganizationDetailsProjectsPresenterTests
{
    [TestFixture]
    public class View_DeleteOrganizationProject_Should
    {
        [Test]
        public void CallProjectService_Once()
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

            mockedView.Raise(x => x.DeleteOrganizationProject += null, new OrganizationDetailsProjectsEventArgs(id));

            mockedProjectService.Verify(x => x.Delete(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallOrganizationService_Once()
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
            int organizationId = 13;

            mockedView.Raise(x => x.DeleteOrganizationProject += null, new OrganizationDetailsProjectsEventArgs(id, "", organizationId));

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
            int organizationId = 13;

            mockedView.Raise(x => x.DeleteOrganizationProject += null, new OrganizationDetailsProjectsEventArgs(id, "", organizationId));

            Assert.AreSame(mockedView.Object.Model.Organization, organizationDTO);
        }
    }
}
