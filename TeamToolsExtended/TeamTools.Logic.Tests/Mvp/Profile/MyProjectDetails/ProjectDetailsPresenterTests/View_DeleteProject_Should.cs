using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;

namespace TeamTools.Logic.Tests.Mvp.Profile.MyProjectDetails.ProjectDetailsPresenterTests
{
    [TestFixture]
    public class View_DeleteProject_Should
    {
        [Test]
        public void CallProjectService_DeleteOnce()
        {
            var mockedView = new Mock<IProjectDetailsView>();
            var mockedProjectService = new Mock<IProjectService>();

            var presenter = new ProjectDetailsPresenter(mockedView.Object, mockedProjectService.Object);
            int id = 34;

            mockedView.Raise(x => x.DeleteProject += null, new ProjectDetailsEventArgs(id));

            mockedProjectService.Verify(x => x.Delete(It.Is<int>(i => i == id)), Times.Once);
        }
    }
}
