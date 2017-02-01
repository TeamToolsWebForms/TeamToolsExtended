using System;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public DateTime Created { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [MaxLength(300)]
        public string Content { get; set; }
    }
}
