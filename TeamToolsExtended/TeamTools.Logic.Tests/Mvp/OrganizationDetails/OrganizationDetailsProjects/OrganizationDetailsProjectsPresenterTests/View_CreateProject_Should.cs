using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsProjects;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsProjects.OrganizationDetailsProjectsPresenterTests
{
    [TestFixture]
    public class View_CreateProject_Should
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
            string title = "test title";
            string description = "test description";
            string creator = "test";

            mockedView.Raise(x => x.CreateProject += null, new OrganizationDetailsProjectsEventArgs(id, title, description, creator));

            mockedProjectService.Verify(x => x.CreateOrganizationProject(
                It.Is<int>(i => i == id),
                It.Is<string>(t => t == title),
                It.Is<string>(d => d == description),
                It.Is<string>(c => c == creator)), Times.Once);
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
            string title = "test title";
            string description = "test description";
            string creator = "test";

            mockedView.Raise(x => x.CreateProject += null, new OrganizationDetailsProjectsEventArgs(id, title, description, creator));

            mockedOrganizationService.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
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
            string title = "test title";
            string description = "test description";
            string creator = "test";

            mockedView.Raise(x => x.CreateProject += null, new OrganizationDetailsProjectsEventArgs(id, title, description, creator));

            Assert.AreSame(mockedView.Object.Model.Organization, organizationDTO);
        }
    }
}
