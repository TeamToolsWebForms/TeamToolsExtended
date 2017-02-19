using System;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Logic.Services.Contracts
{
    public interface IMessageFactory
    {
        Message CreateMessage(DateTime created, string creator, string content);
    }
}
