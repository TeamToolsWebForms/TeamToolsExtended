using System;
using System.ComponentModel.DataAnnotations;

namespace TeamTools.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public virtual Project RelatedProject { get; set; }

        public DateTime Created { get; set; }

        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [MaxLength(300)]
        public string Content { get; set; }

        [MaxLength(300)]
        [RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$")]
        public string PictureUrl { get; set; }
    }
}
