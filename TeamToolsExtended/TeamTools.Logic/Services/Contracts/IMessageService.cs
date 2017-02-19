using System.Collections.Generic;
using TeamTools.Logic.DTO;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IMessageService
    {
        MessageDTO Create(string content, string username, int projectId);

        IEnumerable<MessageDTO> GetAllProjectMessages(int projectId);
    }
}
