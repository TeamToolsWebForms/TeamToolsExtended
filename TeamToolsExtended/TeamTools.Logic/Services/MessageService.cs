using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamTools.Logic.Data.Contracts;
using TeamTools.Logic.Data.Models;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Logic.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> messageRepository;
        private readonly IRepository<Project> projectRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapperService mapperService;
        private readonly IMessageFactory messageFactory;

        public MessageService(
            IRepository<Message> messageRepository,
            IRepository<Project> projectRepository,
            IUnitOfWork unitOfWork,
            IMapperService mapperService,
            IMessageFactory messageFactory)
        {
            Guard.WhenArgument(messageRepository, "Message Repository").IsNull().Throw();
            Guard.WhenArgument(projectRepository, "Project Repository").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "UnitOfWork").IsNull().Throw();
            Guard.WhenArgument(mapperService, "Mapper Service").IsNull().Throw();
            Guard.WhenArgument(messageFactory, "Message Factory").IsNull().Throw();

            this.messageRepository = messageRepository;
            this.projectRepository = projectRepository;
            this.unitOfWork = unitOfWork;
            this.mapperService = mapperService;
            this.messageFactory = messageFactory;
        }

        public MessageDTO Create(string content, string username, int projectId)
        {
            var project = this.projectRepository.GetById(projectId);
            var message = this.messageFactory.CreateMessage(DateTime.Now, username, content);
            this.messageRepository.Add(message);
            project.Messages.Add(message);
            this.unitOfWork.Commit();
            var mappedMessage = this.mapperService.MapObject<MessageDTO>(message);
            return mappedMessage;
        }

        public IEnumerable<MessageDTO> GetAllProjectMessages(int projectId)
        {
            var project = this.projectRepository.GetById(projectId);
            var mappedMessages = project.Messages.Select(x => this.mapperService.MapObject<MessageDTO>(x));
            return mappedMessages;
        }
    }
}
