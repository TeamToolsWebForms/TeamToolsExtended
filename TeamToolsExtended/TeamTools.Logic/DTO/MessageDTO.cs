using System;

namespace TeamTools.Logic.DTO
{
    public class MessageDTO
    {
        public DateTime Created { get; set; }
        
        public string Content { get; set; }

        public string Creator { get; set; }
    }
}
