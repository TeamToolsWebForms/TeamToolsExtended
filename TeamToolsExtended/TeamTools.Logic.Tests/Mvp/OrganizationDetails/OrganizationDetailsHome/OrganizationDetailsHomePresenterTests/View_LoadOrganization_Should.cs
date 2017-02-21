using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.OrganizationDetails.OrganizationDetailsHome;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.OrganizationDetails.OrganizationDetailsHome.OrganizationDetailsHomePresenterTests
{
    [TestFixture]
    public class View_LoadOrganization_Should
    {
        [Test]
        public void CallOrganizationService_Once()
        {
            var mockedView = new Mock<IOrganizationDetailsHomeView>();
            var viewModel = new OrganizationDetailsHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();

            var presenter = new OrganizationDetailsHomePresenter(mockedView.Object, mockedOrganizationService.Object);
            int id = 12;

            mockedView.Raise(x => x.LoadOrganization += null, new OrganizationDetailsHomeEventArgs(id));

            mockedOrganizationService.Verify(x => x.GetById(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_CorrectValue()
        {
            var mockedView = new Mock<IOrganizationDetailsHomeView>();
            var viewModel = new OrganizationDetailsHomeViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var organizationDTO = new OrganizationDTO();
            mockedOrganizationService.Setup(x => x.GetById(It.IsAny<int>())).Returns(organizationDTO);

            var presenter = new OrganizationDetailsHomePresenter(mockedView.Object, mockedOrganizationService.Object);
            int id = 12;

            mockedView.Raise(x => x.LoadOrganization += null, new OrganizationDetailsHomeEventArgs(id));

            Assert.AreSame(mockedView.Object.Model.Organization, organizationDTO);
        }
    }
}
