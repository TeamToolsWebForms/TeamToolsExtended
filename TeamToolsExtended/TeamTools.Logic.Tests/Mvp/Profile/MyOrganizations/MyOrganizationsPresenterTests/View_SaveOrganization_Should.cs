using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Services.Helpers.Contracts;
using TeamTools.Logic.Mvp.Profile.MyOrganizations.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyOrganizations;
using System.Drawing;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyOrganizations.MyOrganizationsPresenterTests
{
    [TestFixture]
    public class View_SaveOrganization_Should
    {
        [Test]
        public void CallImageHelper_GetImageOnce()
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
            string name = "test name";
            string description = "test description";
            string username = "test";
            string logoPath = "somepath";

            mockedView.Raise(x => x.SaveOrganization += null, new OrganizationsEventArgs(id, name, description, username, logoPath));

            mockedImageHelper.Verify(x => x.GetImage(It.Is<string>(p => p == logoPath)), Times.Once);
        }

        [Test]
        public void CallImageHelper_ByteArrayToImageUrlOnce()
        {
            var mockedView = new Mock<IMyOrganizationsView>();
            var viewModel = new MyOrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();
            byte[] imageContent = new byte[] { 12, 43, 5 };
            mockedImageHelper.Setup(x => x.ImageToByteArray(It.IsAny<Image>())).Returns(imageContent);

            var presenter = new MyOrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);
            string id = "123-21312";
            string name = "test name";
            string description = "test description";
            string username = "test";
            string logoPath = "somepath";

            mockedView.Raise(x => x.SaveOrganization += null, new OrganizationsEventArgs(id, name, description, username, logoPath));

            mockedImageHelper.Verify(x => x.ByteArrayToImageUrl(It.Is<byte[]>(a => a == imageContent)), Times.Once);
        }

        [Test]
        public void CallOrganizationLogoFactory_CreateOrganizationLogoOnce()
        {
            var mockedView = new Mock<IMyOrganizationsView>();
            var viewModel = new MyOrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();
            byte[] imageContent = new byte[] { 12, 43, 5 };
            mockedImageHelper.Setup(x => x.ImageToByteArray(It.IsAny<Image>())).Returns(imageContent);

            var presenter = new MyOrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);
            string id = "123-21312";
            string name = "test name";
            string description = "test description";
            string username = "test";
            string logoPath = "somepath";

            mockedView.Raise(x => x.SaveOrganization += null, new OrganizationsEventArgs(id, name, description, username, logoPath));

            mockedOrganizationLogoFactory.Verify(x => x.CreateOrganizationLogo(It.Is<byte[]>(a => a == imageContent)), Times.Once);
        }

        [Test]
        public void CallOrganizationFactory_CreateOrganizationLogoOnce()
        {
            var mockedView = new Mock<IMyOrganizationsView>();
            var viewModel = new MyOrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var organizationLogo = new OrganizationLogo();
            mockedOrganizationLogoFactory.Setup(x => x.CreateOrganizationLogo(It.IsAny<byte[]>())).Returns(organizationLogo);
            var mockedImageHelper = new Mock<IImageHelper>();
            byte[] imageContent = new byte[] { 12, 43, 5 };
            mockedImageHelper.Setup(x => x.ImageToByteArray(It.IsAny<Image>())).Returns(imageContent);
            string logoUrl = "someurl";
            mockedImageHelper.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns(logoUrl);

            var presenter = new MyOrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);
            string id = "123-21312";
            string name = "test name";
            string description = "test description";
            string username = "test";
            string logoPath = "somepath";

            mockedView.Raise(x => x.SaveOrganization += null, new OrganizationsEventArgs(id, name, description, username, logoPath));

            mockedOrganizationFactory.Verify(x => x.CreateOrganization(
                It.Is<string>(n => n == name),
                It.Is<string>(d => d == description),
                It.Is<OrganizationLogo>(l => l == organizationLogo),
                It.Is<string>(c => c == username),
                It.Is<string>(u => u == logoUrl)), Times.Once);
        }

        [Test]
        public void CallOrganizationService_CreateOnce()
        {
            var mockedView = new Mock<IMyOrganizationsView>();
            var viewModel = new MyOrganizationsViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedOrganizationService = new Mock<IOrganizationService>();
            var mockedOrganizationFactory = new Mock<IOrganizationFactory>();
            var organization = new Organization();
            mockedOrganizationFactory.Setup(x => x.CreateOrganization(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<OrganizationLogo>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(organization);
            var mockedOrganizationLogoFactory = new Mock<IOrganizationLogoFactory>();
            var mockedImageHelper = new Mock<IImageHelper>();

            var presenter = new MyOrganizationsPresenter(
                mockedView.Object,
                mockedOrganizationService.Object,
                mockedOrganizationFactory.Object,
                mockedOrganizationLogoFactory.Object,
                mockedImageHelper.Object);
            string id = "123-21312";
            string name = "test name";
            string description = "test description";
            string username = "test";
            string logoPath = "somepath";

            mockedView.Raise(x => x.SaveOrganization += null, new OrganizationsEventArgs(id, name, description, username, logoPath));

            mockedOrganizationService.Verify(x => x.Create(It.Is<Organization>(o => o == organization), It.Is<string>(i => i == id)), Times.Once);
        }

        [Test]
        public void CallOrganizationService_GetOrganizationsOnce()
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
            string name = "test name";
            string description = "test description";
            string username = "test";
            string logoPath = "somepath";

            mockedView.Raise(x => x.SaveOrganization += null, new OrganizationsEventArgs(id, name, description, username, logoPath));

            mockedOrganizationService.Verify(x => x.GetUserOrganizations(It.Is<string>(i => i == id)), Times.Once);
        }

        [Test]
        public void SetViewViewModel_Correct()
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
            string name = "test name";
            string description = "test description";
            string username = "test";
            string logoPath = "somepath";

            mockedView.Raise(x => x.SaveOrganization += null, new OrganizationsEventArgs(id, name, description, username, logoPath));

            CollectionAssert.AreEquivalent(mockedView.Object.Model.MyOrganizations, organizations);
        }
    }
}
