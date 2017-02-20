using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Tests.Services.MessageServiceTests
{
    [TestFixture]
    public class GetAllProjectMessages_Should
    {
        [Test]
        public void CallProjectRepository_GetByIdOnce()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);
            
            int id = 12;

            messageService.GetAllProjectMessages(id);

            mockedProjectRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetProjectMessages()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            var message = new Message();
            project.Messages = new List<Message>()
            {
                message,
                message,
                message
            };

            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            mockedMapper.Setup(x => x.MapObject<MessageDTO>(It.Is<Message>(m => m == message))).Returns(It.IsAny<MessageDTO>());
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);

            int id = 12;

            var result = messageService.GetAllProjectMessages(id);

            Assert.AreEqual(project.Messages.Count, result.Count());
        }
    }
}
