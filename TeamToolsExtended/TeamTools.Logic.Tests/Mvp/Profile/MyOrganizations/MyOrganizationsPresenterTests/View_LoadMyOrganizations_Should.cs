using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using TeamTools.Logic.Mvp.Profile.MyOrganizations;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyOrganizations.MyOrganizationsPresenterTests
{
    [TestFixture]
    public class View_LoadMyOrganizations_Should
    {
        [Test]
        public void CallOrganizationService_GetUserOrganizationsOnce()
        {
            var mockedView = new Mock<IMyOrganizationsView>();
            var viewModel = new MyOrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new MyOrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);
            string id = "123-21312";

            mockedView.Raise(x => x.LoadMyOrganizations += null, new OrganizationsEventArgs(id));

            mockedOrganizationService.Verify(x => x.GetUserOrganizations(It.Is<string>(i => i == id)), Times.Once);
        }

        [Test]
        public void SetViewModelOrganizations_Correct()
        {
            var mockedView = new Mock<IMyOrganizationsView>();
            var viewModel = new MyOrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var organizations = new List<OrganizationDTO>()
            {
                new OrganizationDTO(),
                new OrganizationDTO(),
                new OrganizationDTO()
            };
            mockedOrganizationService.Setup(x => x.GetUserOrganizations(It.IsAny<string>())).Returns(organizations);

            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new MyOrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);
            string id = "123-21312";

            mockedView.Raise(x => x.LoadMyOrganizations += null, new OrganizationsEventArgs(id));

            CollectionAssert.AreEquivalent(mockedView.Object.Model.MyOrganizations, organizations);
        }
    }
}
