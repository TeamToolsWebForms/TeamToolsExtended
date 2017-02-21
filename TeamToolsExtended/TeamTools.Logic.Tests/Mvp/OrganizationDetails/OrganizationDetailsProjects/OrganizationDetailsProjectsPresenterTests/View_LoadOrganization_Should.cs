using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsProjects.OrganizationDetailsProjectsPresenterTests
{
    [TestFixture]
    public class View_LoadOrganization_Should
    {
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

            mockedView.Raise(x => x.LoadOrganization += null, new OrganizationDetailsProjectsEventArgs(id));

            mockedOrganizationService.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_Correct()
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

            mockedView.Raise(x => x.LoadOrganization += null, new OrganizationDetailsProjectsEventArgs(id));

            Assert.AreEqual(mockedView.Object.Model.Organization, organizationDTO);
        }
    }
}
