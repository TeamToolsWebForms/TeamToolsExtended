using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsAddUserProject;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsAddUserProjectPresenterTests
{
    [TestFixture]
    public class View_CheckIsEmailValid_Should
    {
        [Test]
        public void CallProjectService_IsUserValidOnce()
        {
            var mockedView = new Mock<IProjectDetailsAddUserProjectView>();
            var viewModel = new ProjectDetailsAddUserProjectViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new ProjectDetailsAddUserProjectPresenter(
                mockedView.Object,
                mockedProjectService.Object);
            int organizationId = 4334;
            string email = "test";

            mockedView.Raise(x => x.CheckIsEmailValid += null, new ProjectDetailsAddUserProjectEventArgs(organizationId, email));

            mockedProjectService.Verify(x => x.IsUserValid(It.Is<int>(o => o == organizationId), It.Is<string>(u => u == email)), Times.Once);
        }

        [Test]
        public void SetViewModel_Correct()
        {
            var mockedView = new Mock<IProjectDetailsAddUserProjectView>();
            var viewModel = new ProjectDetailsAddUserProjectViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            mockedProjectService.Setup(x => x.IsUserValid(It.IsAny<int>(), It.IsAny<string>())).Returns(true);

            var presenter = new ProjectDetailsAddUserProjectPresenter(
                mockedView.Object,
                mockedProjectService.Object);
            int organizationId = 4334;
            string email = "test";

            mockedView.Raise(x => x.CheckIsEmailValid += null, new ProjectDetailsAddUserProjectEventArgs(organizationId, email));

            Assert.IsTrue(mockedView.Object.Model.IsEmailValid);
        }
    }
}
