using System;

namespace TeamTools.DataTransferObjects
{
    public class MessageDTO
    {
        public ProjectDTO Project { get; set; }

        public DateTime Created { get; set; }
        
        public UserDTO User { get; set; }
        
        public string Content { get; set; }
    }
}
