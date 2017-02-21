using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain.Contracts;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Mvp.ProjectDetails.ProjectDetailsMain;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Mvp.ProjectDetails.ProjectDetailsMainPresenterTests
{
    [TestFixture]
    public class View_LoadProjectMessages_Should
    {
        [Test]
        public void CallMessageService_GetAllProjectMessagesOnce()
        {
            var mockedView = new Mock<IProjectDetailsMainView>();
            var viewModel = new ProjectDetailsMainViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedMessageService = new Mock<IMessageService>();

            var presenter = new ProjectDetailsMainPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedMessageService.Object);
            int id = 32;

            mockedView.Raise(x => x.LoadProjectMessages += null, new ProjectDetailsMainEventArgs(id));

            mockedMessageService.Verify(x => x.GetAllProjectMessages(It.Is<int>(i => i == id)), Times.Once);
        }

        [Test]
        public void SetViewModelCorrect()
        {
            var mockedView = new Mock<IProjectDetailsMainView>();
            var viewModel = new ProjectDetailsMainViewModel();
            mockedView.Setup(x => x.Model).Returns(viewModel);
            var mockedProjectService = new Mock<IProjectService>();
            var mockedMessageService = new Mock<IMessageService>();
            var messages = new List<MessageDTO>()
            {
                new MessageDTO(),
                new MessageDTO(),
                new MessageDTO()
            };
            mockedMessageService.Setup(x => x.GetAllProjectMessages(It.IsAny<int>())).Returns(messages);

            var presenter = new ProjectDetailsMainPresenter(
                mockedView.Object,
                mockedProjectService.Object,
                mockedMessageService.Object);
            int id = 32;

            mockedView.Raise(x => x.LoadProjectMessages += null, new ProjectDetailsMainEventArgs(id));

            CollectionAssert.AreEquivalent(messages, mockedView.Object.Model.Messages);
        }
    }
}
