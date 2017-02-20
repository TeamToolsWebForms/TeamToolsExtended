using System;
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
    public class Create_Should
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
            mockedDateService.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);

            string content = "content";
            string username = "somename";
            int id = 12;

            messageService.Create(content, username, id);

            mockedProjectRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CallDateService_Once()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();
            mockedDateService.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);

            string content = "content";
            string username = "somename";
            int id = 12;

            messageService.Create(content, username, id);

            mockedDateService.Verify(x => x.GetCurrentTime(), Times.Once);
        }

        [Test]
        public void CallMessageFactory_Once()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();
            mockedDateService.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);

            string content = "content";
            string username = "somename";
            int id = 12;

            messageService.Create(content, username, id);

            mockedMessageFactory.Verify(x => x.CreateMessage(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallMessageRepository_AddOnce()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedMessage = new Mock<Message>();
            mockedMessageFactory.Setup(x => x.CreateMessage(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>())).Returns(mockedMessage.Object);
            var mockedDateService = new Mock<IDateService>();
            mockedDateService.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);

            string content = "content";
            string username = "somename";
            int id = 12;

            messageService.Create(content, username, id);

            mockedMessageRepository.Verify(x => x.Add(It.Is<Message>(m => m == mockedMessage.Object)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_Once()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();
            mockedDateService.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);

            string content = "content";
            string username = "somename";
            int id = 12;

            messageService.Create(content, username, id);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void CallMapper_Once()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedMessage = new Mock<Message>();
            mockedMessageFactory.Setup(x => x.CreateMessage(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>())).Returns(mockedMessage.Object);
            var mockedDateService = new Mock<IDateService>();
            mockedDateService.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);

            string content = "content";
            string username = "somename";
            int id = 12;

            messageService.Create(content, username, id);

            mockedMapper.Verify(x => x.MapObject<MessageDTO>(It.Is<Message>(m => m == mockedMessage.Object)), Times.Once);
        }

        [Test]
        public void ReturnInstanceOfMessageDTO()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var project = new Project();
            mockedProjectRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(project);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageDTO = new Mock<MessageDTO>();
            mockedMapper.Setup(x => x.MapObject<MessageDTO>(It.IsAny<Message>())).Returns(mockedMessageDTO.Object);
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();
            mockedDateService.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);

            var messageService = new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object);

            string content = "content";
            string username = "somename";
            int id = 12;

            var result = messageService.Create(content, username, id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<MessageDTO>(result);
        }
    }
}
