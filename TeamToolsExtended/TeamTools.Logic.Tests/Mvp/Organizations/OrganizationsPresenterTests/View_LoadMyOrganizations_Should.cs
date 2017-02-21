using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Organizations.Contracts;
using TeamTools.Logic.Mvp.Organizations;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Mvp.Profile.MyOrganizations;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Organizations.OrganizationsPresenterTests
{
    [TestFixture]
    public class View_LoadMyOrganizations_Should
    {
        [Test]
        public void CallOrganizationService_GetOrganizationsOnce()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var viewModel = new OrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new OrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);

            mockedView.Raise(x => x.LoadMyOrganizations += null, new OrganizationsEventArgs("1"));

            mockedOrganizationService.Verify(x => x.GetOrganizations(), Times.Once);
        }

        [Test]
        public void SetViewViewModel_Correct()
        {
            var mockedView = new Mock<IOrganizationsView>();
            var viewModel = new OrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var organizations = new List<OrganizationDTO>()
            {
                new OrganizationDTO(),
                new OrganizationDTO(),
                new OrganizationDTO()
            };
            mockedOrganizationService.Setup(x => x.GetOrganizations()).Returns(organizations);
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new OrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);
            string id = "123-21312";

            mockedView.Raise(x => x.LoadMyOrganizations += null, new OrganizationsEventArgs(id));

            CollectionAssert.AreEquivalent(mockedView.Object.Model.Organizations, organizations);
        }
    }
}
