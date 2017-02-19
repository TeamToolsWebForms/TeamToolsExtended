using Microsoft.AspNet.SignalR;
using System;
using Microsoft.AspNet.Identity;
using TeamTools.Logic.Services.Contracts;
using Bytes2you.Validation;

namespace TeamTools.Web.Hubs
{
    public class Chat : Hub
    {
        private readonly IMessageService messageService;

        public Chat(IMessageService messageService)
        {
            Guard.WhenArgument(messageService, "Message Service").IsNull().Throw();

            this.messageService = messageService;
        }

        public void SendMessage(string message, string projectId)
        {
            var username = this.Context.User.Identity.GetUserName();
            try
            {
                int projectIdParsed = int.Parse(projectId);
                var newMessage = this.messageService.Create(message, username, projectIdParsed);
                Clients.Group(projectId).addMessage(newMessage);
            }
            catch (Exception ex)
            {
                Clients.Caller.parseError(ex.Message);
            }
        }

        public void JoinProject(string projectId)
        {
            this.Groups.Add(this.Context.ConnectionId, projectId);
        }
    }
}