using System;
using NUnit.Framework;
using Moq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.Services.Contracts;
using TeamTools.Logic.Services;

namespace TeamTools.Logic.Tests.Services.MessageServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_MessageRepositoryIsNull()
        {
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                null,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object));

            Assert.That(ex.Message.Contains("Message Repository"));
        }

        [Test]
        public void ThrowsWhen_ProjectRepositoryIsNull()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                mockedMessageRepository.Object,
                null,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object));

            Assert.That(ex.Message.Contains("Project Repository"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                null,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                mockedDateService.Object));

            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_MapperServiceIsNull()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMessageFactory = new Mock<IMessageFactory>();
            var mockedDateService = new Mock<IDateService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                null,
                mockedMessageFactory.Object,
                mockedDateService.Object));

            Assert.That(ex.Message.Contains("Mapper Service"));
        }

        [Test]
        public void ThrowsWhen_MessageFactoryIsNull()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedDateService = new Mock<IDateService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                null,
                mockedDateService.Object));

            Assert.That(ex.Message.Contains("Message Factory"));
        }

        [Test]
        public void ThrowsWhen_DateServiceIsNull()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMapper = new Mock<IMapperService>();
            var mockedMessageFactory = new Mock<IMessageFactory>();

            var ex = Assert.Throws<ArgumentNullException>(() => new MessageService(
                mockedMessageRepository.Object,
                mockedProjectRepository.Object,
                mockedUnitOfWork.Object,
                mockedMapper.Object,
                mockedMessageFactory.Object,
                null));

            Assert.That(ex.Message.Contains("Date Service"));
        }

        [Test]
        public void ReturnInstanceOfMessageService_Correct()
        {
            var mockedMessageRepository = new Mock<IRepository<Message>>();
            var mockedProjectRepository = new Mock<IRepository<Project>>();
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

            Assert.IsNotNull(messageService);
            Assert.IsInstanceOf<MessageService>(messageService);
        }
    }
}
