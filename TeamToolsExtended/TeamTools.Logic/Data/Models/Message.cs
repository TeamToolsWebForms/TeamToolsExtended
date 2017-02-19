using System;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Logic.Data.Models
{
    public class Message
    {
        public Message()
        {
        }

        public Message(DateTime created, string creator, string content)
        {
            this.Created = created;
            this.Creator = creator;
            this.Content = content;
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public DateTime Created { get; set; }

        public string Creator { get; set; }

        [MaxLength(300)]
        public string Content { get; set; }
    }
}
